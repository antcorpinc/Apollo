import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { ApplicationRoleViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/applicationroleviewmodel';
import { Subscription } from 'rxjs';
import { CONSTANTS } from 'src/app/common/constants';
import { RoleDataService } from 'src/app/backoffice/common/backoffice-shared/services/role-data.service';
@Component({
  selector: 'app-support-role-list',
  templateUrl: './support-role-list.component.html',
  styleUrls: ['./support-role-list.component.css']
})
export class SupportRoleListComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<ApplicationRoleViewModel>;
  displayedColumns = ['applicationName', 'roleName', 'actions'];
  totalRecords: number;
  subscriptions: Subscription[] = [];
  appRoleList: ApplicationRoleViewModel[];

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  privileges: string[];
  deleteAction = false;
  createAction = false;
  readAction = false;

  constructor(private roleDataService: RoleDataService) { }

  ngOnInit() {
    this.getApplicationRolesForSupportUsers();
  }

  getApplicationRolesForSupportUsers() {
    const subscription = this.roleDataService.getApplicationRolesForSupportUsers()
      .subscribe((data) => {
        console.log('Application Roles are ' + JSON.stringify(data));
        this.appRoleList = data;
        this.dataSource = new MatTableDataSource<ApplicationRoleViewModel>(this.appRoleList);
        this.dataSource.sort = this.sort;
        this.totalRecords = this.appRoleList.length;
      },
        (error) => {
          console.log('Error' + error);
        });
    this.subscriptions.push(subscription);
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
}


