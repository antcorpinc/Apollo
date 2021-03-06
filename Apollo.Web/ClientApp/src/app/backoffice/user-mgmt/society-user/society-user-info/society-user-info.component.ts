import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CONSTANTS } from 'src/app/common/constants';
import { Subscription, Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog, MatSnackBar } from '@angular/material';
import { ObjectState } from 'src/app/common/enums';
import { SocietyListViewModel } from 'src/app/backoffice/viewmodel/society-vm/societylistviewmodel';
import { debounceTime } from 'rxjs/operators';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { Utilities } from 'src/app/common/utilities/utilities';
import { BuildingListViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildinglistviewmodel';
import { BuildingDataService } from 'src/app/backoffice/common/backoffice-shared/services/building-data.service';
import { FlatDataService } from 'src/app/backoffice/common/backoffice-shared/services/flat-data.service';
import { FlatListViewModel } from 'src/app/backoffice/viewmodel/society-vm/flatlistviewmodel';
import { RoleViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/roleviewmodel';
import { RoleDataService } from 'src/app/backoffice/common/backoffice-shared/services/role-data.service';
import { SocietyUserViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/societyuserviewmodel';
import { SocietyUser } from 'src/app/backoffice/viewmodel/user-mgmt-vm/societyuser';
import { UserDataService } from 'src/app/backoffice/common/backoffice-shared/services/user-data.service';
import { InfoMessages } from 'src/app/common/messages';
import { SocietyUserGetViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/societyusergetviewmodel';
import { SocietyUserUpdateViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/societyuserupdateviewmodel';
import { UserApplicationRoleViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/userapplicationroleviewmodel';
@Component({
  selector: 'app-society-user-info',
  templateUrl: './society-user-info.component.html',
  styleUrls: ['./society-user-info.component.css']
})
export class SocietyUserInfoComponent implements OnInit, AfterViewInit, OnDestroy {

  societyUserForm: FormGroup;
  societyList$: Observable<SocietyListViewModel[]>;

  userId: string;
  societyId: string;
  buildingId: string;
  buildings$: Observable<BuildingListViewModel[]>;
  flats$: Observable<FlatListViewModel[]>;
  roles$: Observable<RoleViewModel[]>;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  // This is one we get initially ,
  societyUserViewModel: SocietyUserGetViewModel = <SocietyUserGetViewModel>{};
  // This one is when we create in Db
  societyUserSaveViewModel: SocietyUserViewModel = <SocietyUserViewModel>{};

  // This one is when we update in Db
  societyUserUpdateViewModel: SocietyUserUpdateViewModel = <SocietyUserUpdateViewModel>{};

  subscriptions: Subscription[] = [];

  constructor(private activatedRoute: ActivatedRoute, private dialog: MatDialog,
    private snackBar: MatSnackBar, private societyDataService: SocietyDataService,
    private buildingDataService: BuildingDataService, private flatDataService: FlatDataService,
    private roleDataService: RoleDataService, private userDataService: UserDataService,
    private router: Router) { }

  ngOnInit() {
    // Read Route parameters
    this.userId = this.activatedRoute.snapshot.params['id'];
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.createFormModel();
  }
  ngAfterViewInit(): void {
    this.societyUserForm.get('societyName').valueChanges.pipe(
      debounceTime(1000)
    ).subscribe(value => this.getSocietyListBasedOnSearch(value));
  }

  createFormModel() {
    this.societyUserForm = new FormGroup({
      societyName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      buildingId: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      flatId: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      firstName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      email: new FormControl('', [Validators.required, Validators.maxLength(50), Validators.email]),
      phoneNumber: new FormControl('', [Validators.required, Validators.maxLength(15)]),
      roleId: new FormControl('', [Validators.required]),
      isActive: new FormControl(true),
      objectState: new FormControl(ObjectState.Unchanged),
    });

    if (this.operation.toLowerCase().trim() === this.edit) {
      // Get all the data for the drop downs
      this.societyId = this.activatedRoute.snapshot.params['societyid'];

      this.buildings$ = this.buildingDataService.getBuildingsInSociety(this.societyId);
      this.roles$ = this.roleDataService.getRolesInSociety(this.societyId);
      this.getSocietyUser(this.userId);
    }
  }

  getSocietyUser(userId: string) {
    const subscription = this.userDataService.getSocietyUserById(userId)
      .subscribe(data => {
        console.log('Society User -->' + JSON.stringify(data));
        this.societyUserViewModel = data;
        this.societyUserForm.get('firstName').setValue(this.societyUserViewModel.firstName);
        this.societyUserForm.get('lastName').setValue(this.societyUserViewModel.lastName);
        this.societyUserForm.get('email').setValue(this.societyUserViewModel.email);
        this.societyUserForm.get('phoneNumber').setValue(this.societyUserViewModel.phoneNumber);
        this.societyUserForm.get('societyName').setValue(this.societyUserViewModel.societyName);
        this.societyUserForm.get('societyName').disable({ emitEvent: false });
        this.societyUserForm.get('buildingId').setValue(this.societyUserViewModel.buildingId);
        this.societyUserForm.get('buildingId').disable({ emitEvent: false });
        this.societyUserForm.get('flatId').setValue(this.societyUserViewModel.flatId);
        this.societyUserForm.get('flatId').disable({ emitEvent: false });
        if (!Utilities.isNullOrEmpty(this.societyUserViewModel.userAppRoles) &&
          this.societyUserViewModel.userAppRoles.length) {
          this.societyUserForm.get('roleId').setValue(this.societyUserViewModel.userAppRoles[0].roleId);
        }
      });
  }

  getSocietyListBasedOnSearch(search: string) {
    if (!Utilities.isNullOrEmpty(search) && search.length > 2) {
      this.societyList$ = this.societyDataService.getSocietiesByCustomSearch(search);
    }
  }

  getBuildingsInSociety(event, data) {
    if (event.source.selected) {
      console.log('SocietyId -->' + data.id);
      this.societyId = data.id;
      this.buildings$ = this.buildingDataService.getBuildingsInSociety(this.societyId);
      this.roles$ = this.roleDataService.getRolesInSociety(this.societyId);
    }
  }
  getFlatsInSocietyBuilding(event, data) {
    if (event.source.selected) {
      console.log('Building -->' + data.id);
      this.flats$ = this.flatDataService.getFlatsInSocietyBuilding(this.societyId, data.id);
    }
  }

  onSubmit() {
    if (this.societyUserForm.valid) {
      this.updateSaveObjectState();
      if (this.operation === this.create) {
        console.log('SocietyUser -->' + JSON.stringify(this.societyUserSaveViewModel));
        const subscription = this.userDataService.createSocietyUser(this.societyUserSaveViewModel)
          .subscribe(data => {
            this.snackBar.open(InfoMessages.userCreationMessage, '', {
              duration: CONSTANTS.snackbar.timeout, verticalPosition: 'top',
              politeness: 'polite', panelClass: 'showSnackBar'
            });
            this.router.navigate(['/auth/bo/usermgmt/societyusers'],
              { relativeTo: this.activatedRoute });
          },
            (error) => {
              console.log('Error' + error);
            });
        this.subscriptions.push(subscription);
      } else if (this.operation === this.edit) {
        console.log('edit user model = ' + JSON.stringify(this.societyUserUpdateViewModel));
          const subscription = this.userDataService.updateSocietyUser(this.userId,
            this.societyUserUpdateViewModel)
            .subscribe(data => {

              this.snackBar.open(InfoMessages.userUpdationMessage, '', {
                duration: CONSTANTS.snackbar.timeout, verticalPosition: 'top',
                politeness: 'polite', panelClass: 'showSnackBar'
              });
              this.router.navigate(['/auth/bo/usermgmt/supportusers'],
                { relativeTo: this.activatedRoute });
            },
              (error) => {
                console.log('Error' + error);
              });
          this.subscriptions.push(subscription);
      }
    }
  }

  updateSaveObjectState() {
    if (this.operation === this.create) {
      this.societyUserSaveViewModel = new SocietyUserViewModel();
      this.societyUserSaveViewModel.firstName = this.societyUserForm.get('firstName').value;
      this.societyUserSaveViewModel.lastName = this.societyUserForm.get('lastName').value;
      this.societyUserSaveViewModel.email = this.societyUserForm.get('email').value;
      this.societyUserSaveViewModel.userName = this.societyUserSaveViewModel.email;
      this.societyUserSaveViewModel.phoneNumber = this.societyUserForm.get('phoneNumber').value;
      this.societyUserSaveViewModel.isActive = this.societyUserForm.get('isActive').value;
      this.societyUserSaveViewModel.userType = CONSTANTS.userTypeId.societyUser;

      this.societyUserSaveViewModel.societyUser = new SocietyUser();
      this.societyUserSaveViewModel.societyUser.societyId = this.societyId;
      this.societyUserSaveViewModel.societyUser.buildingId = this.societyUserForm.get('buildingId').value;
      this.societyUserSaveViewModel.societyUser.flatId = this.societyUserForm.get('flatId').value;
      this.societyUserSaveViewModel.societyUser.roleId = this.societyUserForm.get('roleId').value;

      this.societyUserSaveViewModel.objectState = ObjectState.Added;
      this.societyUserSaveViewModel.societyUser.objectState = ObjectState.Added;
    } else if (this.operation === this.edit) {
      this.societyUserUpdateViewModel = new SocietyUserUpdateViewModel();
      this.societyUserUpdateViewModel.id = this.societyUserViewModel.id;
      this.societyUserUpdateViewModel.firstName = this.societyUserForm.get('firstName').value;
      this.societyUserUpdateViewModel.lastName = this.societyUserForm.get('lastName').value;
      this.societyUserUpdateViewModel.email = this.societyUserForm.get('email').value;
      this.societyUserUpdateViewModel.userName = this.societyUserSaveViewModel.email;
      this.societyUserUpdateViewModel.phoneNumber = this.societyUserForm.get('phoneNumber').value;
      this.societyUserUpdateViewModel.isActive = this.societyUserForm.get('isActive').value;
      this.societyUserUpdateViewModel.userType = CONSTANTS.userTypeId.societyUser;

      if (this.societyUserUpdateViewModel.firstName !== this.societyUserViewModel.firstName ||
        this.societyUserUpdateViewModel.lastName !== this.societyUserViewModel.lastName ||
        this.societyUserUpdateViewModel.email !== this.societyUserViewModel.email ||
        this.societyUserUpdateViewModel.phoneNumber !== this.societyUserViewModel.phoneNumber ||
        this.societyUserUpdateViewModel.isActive !== this.societyUserViewModel.isActive) {
        this.societyUserUpdateViewModel.objectState = ObjectState.Modified;
      } else {
        this.societyUserUpdateViewModel.objectState = ObjectState.Unchanged;
      }
      this.societyUserUpdateViewModel.userApplicationRole = new UserApplicationRoleViewModel();
      this.societyUserUpdateViewModel.userApplicationRole.id = this.societyUserViewModel.userAppRoles[0].id;
      this.societyUserUpdateViewModel.userApplicationRole.applicationId = this.societyUserViewModel.userAppRoles[0].applicationId;
      this.societyUserUpdateViewModel.userApplicationRole.userId = this.societyUserViewModel.id;
      this.societyUserUpdateViewModel.userApplicationRole.roleId = this.societyUserForm.get('roleId').value;
      if (this.societyUserUpdateViewModel.userApplicationRole.roleId !==
        this.societyUserViewModel.userAppRoles[0].roleId) {
        this.societyUserUpdateViewModel.objectState = ObjectState.Modified;
      } else {
        this.societyUserUpdateViewModel.objectState = ObjectState.Unchanged;
      }
    }
  }
  ngOnDestroy(): void {

  }
}
