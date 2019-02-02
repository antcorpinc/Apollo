import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { SocietyListViewModel } from 'src/app/backoffice/viewmodel/society-vm/societylistviewmodel';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { debounceTime } from 'rxjs/operators';
import { Utilities } from 'src/app/common/utilities/utilities';
import { UserDataService } from 'src/app/backoffice/common/backoffice-shared/services/user-data.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { SocietyUserListViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/societyuserlistviewmodel';
import { CONSTANTS } from 'src/app/common/constants';

@Component({
  selector: 'app-society-user-list',
  templateUrl: './society-user-list.component.html',
  styleUrls: ['./society-user-list.component.css']
})
export class SocietyUserListComponent implements OnInit, OnDestroy {
  societyName = new FormControl();
  societyList$: Observable<SocietyListViewModel[]>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<SocietyUserListViewModel>;
  displayedColumns = ['firstName', 'lastName',  'userAppRoles',
   'societyName',
  'buildingName', 'flatName', 'isActive'
//  , 'actions'
];
  totalRecords: number;

  subscriptions: Subscription[] = [];
  userList: SocietyUserListViewModel[];

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  privileges: string[];
  deleteAction = false;
  createAction = false;
  readAction = false;

  constructor(private societyDataService: SocietyDataService, private userDataService: UserDataService) { }
// Todo: Add Subscriptions
  ngOnInit() {
    this.societyName.valueChanges.pipe(
      debounceTime(1000)
    ).subscribe(value => this.getSocietyListBasedOnSearch(value));
  }

  getSocietyListBasedOnSearch(search: string) {
    if (!Utilities.isNullOrEmpty(search) && search.length > 2 ) {
     this.societyList$ =  this.societyDataService.getSocietiesByCustomSearch(search);
    }
  }

  search(event, data) {
    if (event.source.selected) {
      // Get the Users for the society -- Do we also need to get the Building for society ??
      // May be no need since in users list we'll also get the building and flat and can sort by building?
      const subscription = this.userDataService.getUsersInSociety(data.id)
          .subscribe((resp) => {
           // console.log(resp)
           this.userList = resp;
        this.dataSource = new MatTableDataSource<SocietyUserListViewModel>(this.userList);
        this.dataSource.sort = this.sort;
        this.totalRecords = this.userList.length;
          },
          (error) => {
            console.log('Error' + error);
          });
          this.subscriptions.push(subscription);
    }
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  goToUser(value) {
    const val = value.split(':');
    const userId = val[0];
    this.operation = val[1];
   // this.router.navigate(['../supportuser', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
}
