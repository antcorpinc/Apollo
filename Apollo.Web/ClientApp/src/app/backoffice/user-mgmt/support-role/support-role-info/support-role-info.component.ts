import { Component, OnInit, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CONSTANTS } from 'src/app/common/constants';
import { ApplicationViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/applicationviewmodel';
import { ApplicationRoleViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/applicationroleviewmodel';
import { Observable, Subscription } from 'rxjs';
import { RoleDataService } from 'src/app/backoffice/common/backoffice-shared/services/role-data.service';
import { FeatureDataService } from 'src/app/backoffice/common/backoffice-shared/services/feature-data.service';
import { FeatureViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/featureviewmodel';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-support-role-info',
  templateUrl: './support-role-info.component.html',
  styleUrls: ['./support-role-info.component.css']
})
export class SupportRoleInfoComponent implements OnInit, AfterViewInit {
  operation: string;
  edit = CONSTANTS.operation.edit;
  read = CONSTANTS.operation.read;
  create = CONSTANTS.operation.create;
  selectedApplicationOption: string;
  applicationList: ApplicationViewModel[];
  applicationRolesList$: Observable<ApplicationRoleViewModel[]>;
  featureList: FeatureViewModel[];
  subscriptions: Subscription[] = [];

  permissionForm: FormGroup;

  constructor(private activatedRoute: ActivatedRoute, private roleDataService: RoleDataService,
    private featureDataService: FeatureDataService, private cd: ChangeDetectorRef, ) { }

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.selectedApplicationOption = this.activatedRoute.snapshot.data['applications'].find(x =>
      x.name.toLowerCase()  ===  CONSTANTS.application.backoffice.toLocaleLowerCase()).id;
      // Get Master Data
      this.applicationList = this.activatedRoute.snapshot.data['applications'];
      if (this.operation.toLowerCase().trim() === this.create) {
        this.getApplicationRoles(this.selectedApplicationOption);
        this.getFeaturesByAppId(this.selectedApplicationOption);
      }
      this.createFormModel();
  }

  ngAfterViewInit(): void {
    this.trackValueChanges();
  }

  trackValueChanges() {

  }
  getApplicationRoles(applicationId: string) {
    this.applicationRolesList$ = this.roleDataService.getRolesByApplicationIdAndUserType(
      applicationId, CONSTANTS.userTypeId.supportUser);
      this.applicationRolesList$.subscribe((data) => {
        console.log('App Roles -->' + JSON.stringify(data));
      });

  }

  getFeaturesByAppId(applicationId: string) {
    const subscription = this.featureDataService.getFeaturesInApplication(applicationId).subscribe
    (data => {
      if (data.length > 0) {
        this.featureList = data;
        console.log('Application Features -->' + JSON.stringify(this.featureList));
        for (const feature of this.featureList) {
          feature.isExpanded = true;
        }
     //   this.noFeatureAvailable = false;
     //   this.removeFeatureList();
     //   this.addFeatureList(this.featureList);
     //   this.permissionForm.controls.userRole.enable();

      } else {  // If no feature is associate with application set the fetureDetails to empty
     //   this.permissionForm.controls.featureDetails = new FormArray([]);
     //   this.noFeatureAvailable = true;
     //   this.permissionForm.get('userRole').setValue('');
     //   this.permissionForm.controls.userRole.disable();
      }
    },
    (error) => console.error(`Error in Getting UM-Roles&Permissions-getFeaturesByAppId(applicationId: string). ${error.friendlyMessage}`));
    //  this.cd.detectChanges();
     this.subscriptions.push(subscription);
  }

  createFormModel() {
    this.permissionForm = new FormGroup({
      userApplication: new FormControl(this.selectedApplicationOption),
      userRole: new FormControl(),
     // featureDetails: new FormArray([], validatePermissions),
  });
  }
}
