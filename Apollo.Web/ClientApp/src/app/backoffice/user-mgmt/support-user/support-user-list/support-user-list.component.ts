import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import {Subscription} from 'rxjs';
import { SupportUserListViewModel } from '../../../viewmodel/user-mgmt-vm/supportuserlistviewmodel';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { CONSTANTS } from '../../../../common/constants';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-support-user-list',
  templateUrl: './support-user-list.component.html',
  styleUrls: ['./support-user-list.component.css']
})
export class SupportUserListComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<SupportUserListViewModel>;
  displayedColumns = ['firstName', 'email', 'isActive'];
  totalRecords: number;

  subscriptions: Subscription[] = [];
  userList: SupportUserListViewModel[];

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

 constructor(private router: Router, private activatedRoute: ActivatedRoute,
  private userDataService: UserDataService ) { }

  ngOnInit() {
    this.getSupportUserList();
  }

  getSupportUserList() {
    const subscription = this.userDataService.getSupportUsers()
      .subscribe((data) => {
        console.log('Users are ' + JSON.stringify(data));
        this.userList = data;
        this.dataSource = new MatTableDataSource<SupportUserListViewModel>(this.userList);
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

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

}
