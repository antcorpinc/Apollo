import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CONSTANTS } from 'src/app/common/constants';
import { Subscription, Observable } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';
import { ApplicationViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/applicationviewmodel';
import { ApplicationRoleViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/applicationroleviewmodel';
import { FeatureViewModel, FeatureViewModelFlatNode, FeatureVM } from 'src/app/backoffice/viewmodel/user-mgmt-vm/featureviewmodel';
import { SelectionModel } from '@angular/cdk/collections';
import { FlatTreeControl } from '@angular/cdk/tree';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTreeFlatDataSource, MatTreeFlattener, MatSnackBar, MatSelect } from '@angular/material';
import { RoleDataService } from 'src/app/backoffice/common/backoffice-shared/services/role-data.service';
import { FeatureDataService } from 'src/app/backoffice/common/backoffice-shared/services/feature-data.service';

@Component({
  selector: 'app-support-roles-permission',
  templateUrl: './support-roles-permission.component.html',
  styleUrls: ['./support-roles-permission.component.css']
})
export class SupportRolesPermissionComponent implements OnInit {

  operation: string;
  edit = CONSTANTS.operation.edit;
  read = CONSTANTS.operation.read;
  create = CONSTANTS.operation.create;
  subscriptions: Subscription[] = [];
  permissionForm: FormGroup;
  applicationList: ApplicationViewModel[];
 // applicationRolesList$: Observable<ApplicationRoleViewModel[]>;
 applicationRolesList: Observable<ApplicationRoleViewModel[]>; 
  featureList: FeatureViewModel[];
  permissionExist = false;
  noFeatureAvailable: boolean;
  selectedOption: string;
  isRead = false;
  isSaveButtonDisabled = true;
  isCheckBoxChecked = false;
  isFormDirty = false;
  checklistSelectionViewAccess = new SelectionModel<FeatureViewModelFlatNode>(true);
  checklistSelectionFullAccess = new SelectionModel<FeatureViewModelFlatNode>(true);
  checklistSelectionAddAccess = new SelectionModel<FeatureViewModelFlatNode>(true);
  checklistSelectionEditAccess = new SelectionModel<FeatureViewModelFlatNode>(true);
  checklistSelectionDeleteAccess = new SelectionModel<FeatureViewModelFlatNode>(true);
  checklistSelectionApproveAccess = new SelectionModel<FeatureViewModelFlatNode>(true);
  appId: string;
  roleId: string;

  // rolePrivilegeList: RolePrivilegeInfoViewModel[];
  isPageLoaded: boolean;
  getLevel = (node: FeatureViewModelFlatNode) => node.level;
  hasChild = (_: number, node: FeatureViewModelFlatNode) => node.expandable;
  isFeatureAvailable: boolean;
  // errorStateMatcher = new CustomErrorStateMatcherForRoles();
  private transformer = (node: FeatureVM, level: number) => {
    return {
      expandable: !!node.subModule && node.subModule.length > 0,
      name: node.name,
      level: level,
      id: node.id,
      description: node.description,
      order: node.order,
      parentFeatureId: node.parentFeatureId,
      isActive: node.isActive,
      createdBy: node.createdBy,
      updatedBy: node.updatedBy,
      privileges: node.privileges,
      featurePrivileges: node.featurePrivileges,
      featureTypeRolePrivilegeId: node.featureTypeRolePrivilegeId,
      viewAccess: node.viewAccess,
      addAccess: node.addAccess,
      editAccess: node.editAccess,
      deleteAccess: node.deleteAccess,
      approveAccess: node.approveAccess,
      isRequired: node.isRequired,
      fullAccess: node.fullAccess
    };
  }
  treeControl = new FlatTreeControl<FeatureViewModelFlatNode>(node => node.level, node => node.expandable);
  treeFlattener = new MatTreeFlattener(this.transformer, node => node.level, node => node.expandable, node => node.subModule);
  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,
    private cd: ChangeDetectorRef,
    private roleDataService: RoleDataService,
    private featureDataService: FeatureDataService,
   // private backofficeLookupService: BackofficeLookupService,
   // private rolesPermissionDataService: RolesPermissionDataService,
   // private cancelPopupService: CancelPopupService,
   // private userProfileService: UserProfileService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  InitialiseForm() {
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.selectedOption = this.activatedRoute.snapshot.data['applications'].
    find(x => x.name.toLowerCase() === 
    CONSTANTS.application.backoffice.toLocaleLowerCase()).id;

    this.permissionForm = new FormGroup({
      userApplication: new FormControl(),
      userRole: new FormControl()
    });
    this.isFormDirty = false;
    this.isCheckBoxChecked = false;
    this.getApplications();
    this.permissionForm.get('userApplication').setValue(this.selectedOption);
    if (this.operation.toLowerCase().trim() === this.create) {
      this.getApplicationRoles(this.selectedOption);
     // this.getFeaturesByAppId(this.selectedOption);
    }
  }

  
  getApplications() {
    this.applicationList = this.activatedRoute.snapshot.data['applications'];
  }

  getApplicationRoles(applicationId: string) {
    this.isCheckBoxChecked = false;
    this.isSaveButtonDisabled = true;
    this.permissionForm.get('userRole').setValue('');

    this.applicationRolesList = this.roleDataService.getRolesByApplicationIdAndUserType(
      applicationId, CONSTANTS.userTypeId.supportUser);
    this.applicationRolesList.subscribe((data) => {
      console.log('App Roles -->' + JSON.stringify(data));
    });
  }



}
