import { Component, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ApplicationViewModel } from '../../../../backoffice/viewmodel/user-mgmt-vm/applicationviewmodel';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { CONSTANTS } from '../../../../common/constants';
import { RoleViewModel } from '../../../viewmodel/user-mgmt-vm/roleviewmodel';
import { Subscription } from 'rxjs';
import { BackOfficeLookupService } from '../../../common/backoffice-shared/services/lookup.service';
import { InfoMessages, ErrorMessages } from 'src/app/common/messages';
import { MatDialog } from '@angular/material';
import { ConfirmDialogComponent } from '../../dialogs/confirm-dialog/confirm-dialog.component';
import { UserMgmtSupportUserSyncValidators } from './support-user-info.validator';
import { SupportUserViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/supportuserviewmodel';
import { ObjectState } from 'src/app/common/enums';
import { UserProfileService } from '../../../../common/shared/services/user-profile.service';

@Component({
  selector: 'app-support-user-info',
  templateUrl: './support-user-info.component.html',
  styleUrls: ['./support-user-info.component.css']
})
export class SupportUserInfoComponent implements OnInit, OnDestroy {

  supportUserForm: FormGroup;

  applicationList: ApplicationViewModel[];
  // For each app , the list of Roles
  appRolesListArray: Array<RoleViewModel[]>;
  isMaxLength: boolean;

  userId: string;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  // This is one we get initially ,
  supportUserViewModel: SupportUserViewModel = <SupportUserViewModel>{};
  // This one is when we update in Db
  supportUserSaveViewModel: SupportUserViewModel = <SupportUserViewModel>{};

  subscriptions: Subscription[] = [];

  constructor(private activatedRoute: ActivatedRoute, private cd: ChangeDetectorRef,
    private backOfficeLookUpService: BackOfficeLookupService,
    private dialog: MatDialog, private userProfileService: UserProfileService,
  ) { }

  ngOnInit() {
    // Read Route parameters
    this.userId = this.activatedRoute.snapshot.params['id'];
    this.operation = this.activatedRoute.snapshot.params['operation'];
    // Get all master Data
    this.getApplications();
    // Create Form Model
    this.createFormModel();
  }


  getApplications() {
    this.applicationList = this.activatedRoute.snapshot.data['applications'];
  }

  createFormModel() {
    this.supportUserForm = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      email: new FormControl('', [Validators.required, Validators.maxLength(50),
      // Validators.pattern('^[\\w+]+(\\.[\\w+]+)*@[A-Za-z0-9]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z0-9]{2,4})$')
      Validators.email
      ]),
      phoneNumber: new FormControl('', [Validators.required, Validators.maxLength(15)]),
      isActive: new FormControl(true),
      userApplicationRole: new FormArray([], [UserMgmtSupportUserSyncValidators.ApplicationRoleValidator] )
    });

    if (this.operation.toLowerCase().trim() === this.create) {
      this.addAppRole();
    }
  }

  get userApplicationRole(): FormArray {
    return <FormArray>this.supportUserForm.get('userApplicationRole');
  }

  isNullOrEmpty(value: any): boolean {
    return value === undefined || value === null || value === '';
  }

  confirmDeleteAppRole(index: number) {
    if (this.isNullOrEmpty(this.userApplicationRole.value[index].applicationId) &&
      this.isNullOrEmpty(this.userApplicationRole.value[index].roleId)) {
      this.deleteAppRole(index);
    } else {
      const dialogRef = this.dialog.open(ConfirmDialogComponent, {
        width: '450px',
        data: {
          title: 'Confirm Delete',
          content: InfoMessages.applicationRoleDeletionMessage
        }
      });
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.deleteAppRole(index);
        }
      },
        (error) => {
          console.log('Error' + error);
        });
    }
  }

  deleteAppRole(index: number) {
    this.userApplicationRole.removeAt(index);
    this.appRolesListArray.splice(index, 1);
    this.isMaxLength = false;
    this.cd.detectChanges();
  }

  addAppRole() {
    this.userApplicationRole.push(this.buildAppRole());
    if (this.appRolesListArray === null || this.appRolesListArray === undefined) {
      this.appRolesListArray = new Array<RoleViewModel[]>();
    } else {
      this.appRolesListArray.push([]);
    }

    if (this.userApplicationRole.length === this.applicationList.length) {

      this.isMaxLength = true;
    }
    this.cd.detectChanges();
  }

  buildAppRole(): FormGroup {
    let appRoleFormGroup: FormGroup;
    appRoleFormGroup = new FormGroup({
      applicationId: new FormControl({ value: '' }, Validators.required),
      roleId: new FormControl({ value: '' }, Validators.required)
    });
    return appRoleFormGroup;
  }

  getRolesForApplication(applicationId, applicationIndex) {
    if (applicationId !== null) {
      const subscription = this.backOfficeLookUpService.getRolesByApplicationIdAndUserType(applicationId,
        CONSTANTS.userTypeId.supportUser).subscribe(data => {
          this.appRolesListArray[applicationIndex] = data;
        },
          (error) => console.error(`Error in Suppport-User-getRolesForApplication. ${error}`));
      this.subscriptions.push(subscription);
    } else {
      this.userApplicationRole.controls[applicationIndex].get('roleId').setValue(null);
      this.appRolesListArray[applicationIndex] = [];
    }
  }

  hasErrors(controlName: string) {
    return (this.supportUserForm.get(controlName).dirty ||
     this.supportUserForm.get(controlName).touched) &&
     this.supportUserForm.get(controlName).errors !== null;
  }

  getValidationMessage(controlName: string): string {
    if (this.supportUserForm.get(controlName).hasError('required')) {
      return ErrorMessages.requiredFieldMessage;
    } else if (this.supportUserForm.get(controlName).hasError('ValidateAppRole')) {
      return ErrorMessages.validateAppRole;
    } else {
      return '';
    }
  }

  onSubmit() {
    if (this.supportUserForm.valid) {
      this.updateSaveObjectState();
      console.log('user= ' + JSON.stringify(this.supportUserSaveViewModel));
    }
  }

  updateSaveObjectState() {
    this.supportUserSaveViewModel = Object.assign({}, this.supportUserViewModel, this.supportUserForm.value);
      this.supportUserSaveViewModel.userName = this.supportUserSaveViewModel.email;
      // Todo :Do we need to Add updated by updated by?
      // Password for new users needs to be generated at API side using custom
      if (this.operation === this.create) {
          this.supportUserSaveViewModel.objectState = ObjectState.Added;
        this.supportUserSaveViewModel.createdBy = this.userProfileService.getBasicUserInfo().userName;
        this.supportUserSaveViewModel.userApplicationRole.forEach(item =>
        item.objectState = ObjectState.Added);
      }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
}
