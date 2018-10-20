import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { UserDataService } from '../../../common/backoffice-shared/services/user-data.service';
import {Subscription} from 'rxjs';
import { SupportUserListViewModel } from '../../../viewmodel/user-mgmt-vm/supportuserlistviewmodel';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';

@Component({
  selector: 'app-support-user-list',
  templateUrl: './support-user-list.component.html',
  styleUrls: ['./support-user-list.component.css']
})
export class SupportUserListComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<SupportUserListViewModel>;
  displayedColumns = ['firstName', 'email'];
  totalRecords: number;

  subscriptions: Subscription[] = [];
  userList: SupportUserListViewModel[];

 constructor(private userDataService: UserDataService ) { }

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

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

}
