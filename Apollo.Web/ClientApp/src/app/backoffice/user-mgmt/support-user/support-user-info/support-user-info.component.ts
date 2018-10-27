import { Component, OnInit, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ApplicationViewModel } from '../../../../backoffice/viewmodel/user-mgmt-vm/applicationviewmodel';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { CONSTANTS } from '../../../../common/constants';
import { RoleViewModel } from '../../../viewmodel/user-mgmt-vm/roleviewmodel';
import { Subscription } from 'rxjs';
import { BackOfficeLookupService } from '../../../common/backoffice-shared/services/lookup.service';
import { InfoMessages } from 'src/app/common/messages';

@Component({
  selector: 'app-support-user-info',
  templateUrl: './support-user-info.component.html',
  styleUrls: ['./support-user-info.component.css']
})
export class SupportUserInfoComponent implements OnInit , OnDestroy {

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

  subscriptions: Subscription[] = [];

  constructor(private activatedRoute: ActivatedRoute, private cd: ChangeDetectorRef,
    private backOfficeLookUpService: BackOfficeLookupService,
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
      Validators.pattern('^[\\w+]+(\\.[\\w+]+)*@[A-Za-z0-9]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z0-9]{2,4})$')]),
      isActive: new FormControl(true),
      userApplicationRole: new FormArray([])
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
   //   const subscribtion = this.dialogsService
   //   .confirm('Confirm', InfoMessages.applicationRoleDeletionMessage).subscribe(res => {
   //     if (res) {
          this.deleteAppRole(index);
       //   this.mgUserForm.get('userApplicationRole').markAsDirty();
       //   this.mgUserForm.get('userApplicationRole').markAsTouched();
       //   this.mgUserForm.get('userApplicationRole').updateValueAndValidity();
     //   } else {
        //  this.actions = null;
      //  }
     // },
     // (error) => console.error(`Error in deleting SupportUser-confirmDeleteAppRole(index: number). ${error}`));
     // this.subscriptions.push(subscribtion);
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

  onSubmit() {

  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
}
