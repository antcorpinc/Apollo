import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import { Subscription } from 'rxjs';
import { SupportUserListViewModel } from '../../../viewmodel/user-mgmt-vm/supportuserlistviewmodel';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { CONSTANTS } from '../../../../common/constants';
import { Router, ActivatedRoute } from '@angular/router';
import { UserProfileService } from '../../../../common/shared/services/user-profile.service';

@Component({
  selector: 'app-support-user-list',
  templateUrl: './support-user-list.component.html',
  styleUrls: ['./support-user-list.component.css']
})
export class SupportUserListComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<SupportUserListViewModel>;
  displayedColumns = ['firstName', 'email', 'userApplicationRole', 'isActive', 'actions'];
  totalRecords: number;

  subscriptions: Subscription[] = [];
  userList: SupportUserListViewModel[];

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  privileges: string[];
  deleteAction = false;
  createAction = false;
  readAction = false;

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    private userDataService: UserDataService, private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.getSupportUserList();
    this.getPrivileges();
  }

  getSupportUserList() {
    const subscription = this.userDataService.getSupportUsers()
      .subscribe((data) => {
        console.log('Users are ' + JSON.stringify(data));
        this.userList = data;
        this.dataSource = new MatTableDataSource<SupportUserListViewModel>(this.userList);
        this.dataSource.sort = this.sort;
        this.totalRecords = this.userList.length;
      },
        (error) => {
          console.log('Error' + error);
        });
    this.subscriptions.push(subscription);
  }

  createSupportUser() {
    // this.router.navigate(['../supportuser', 0, this.create], { relativeTo: this.activatedRoute });
    this.router.navigate(['../supportuser', CONSTANTS.create.id, this.create], { relativeTo: this.activatedRoute });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  goToUser(value) {
    const val = value.split(':');
    const userId = val[0];
    this.operation = val[1];
    this.router.navigate(['../supportuser', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }

  getPrivileges() {
    this.privileges = this.userProfileService.getUserPermissionsForFeature(
      CONSTANTS.application.backoffice,
      CONSTANTS.featuretypeid.Support
    );
    if (this.privileges !== null) {
      for (const privilege of this.privileges) {
        if (privilege === 'VW') {
          this.readAction = true;
        } else if (privilege === 'CR') {
          this.createAction = true;
          this.readAction = true;
        } else if (privilege === 'DE') {
          this.deleteAction = true;
        }
      }
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

}
