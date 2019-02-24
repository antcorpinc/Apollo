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
import { Router, ActivatedRoute } from '@angular/router';
import { UserProfileService } from 'src/app/common/shared/services/user-profile.service';

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
  displayedColumns = ['firstName', 'lastName',  'userAppRoles', 'societyName', 'buildingName',
   'flatName', 'isActive', 'actions'];
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

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    private societyDataService: SocietyDataService, private userDataService: UserDataService,
    private userProfileService: UserProfileService) { }
// Todo: Add Subscriptions
  ngOnInit() {
    this.getPrivileges();
    this.societyName.valueChanges.pipe(
      debounceTime(1000)
    ).subscribe(value => this.getSocietyListBasedOnSearch(value));
  }

  getSocietyListBasedOnSearch(search: string) {
    if (!Utilities.isNullOrEmpty(search) && search.length > 2 ) {
     this.societyList$ =  this.societyDataService.getSocietiesByCustomSearch(search);
    }
  }

  createSocietyUser() {
     this.router.navigate(['../societyuser/society', CONSTANTS.create.id,'building', CONSTANTS.create.id,
     'flat', CONSTANTS.create.id, 'user', CONSTANTS.create.id, this.create],
     { relativeTo: this.activatedRoute });
  }

  search(event, data) {
    if (event.source.selected) {
      // Get the Users for the society -- Do we also need to get the Building for society ??
      // May be no need since in users list we'll also get the building and flat and can sort by building?
      const subscription = this.userDataService.getUsersInSociety(data.id)
          .subscribe((resp) => {
            console.log('Society User List -->' + JSON.stringify(resp));
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
    const selectedUser = this.userList.filter(u => u.userId === userId)[0];
    console.log('Selected User -->' + JSON.stringify(selectedUser));
   // this.router.navigate(['../societyuser', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
   this.router.navigate(['../societyuser/society', selectedUser.societyId, 'building', selectedUser.buildingId,
   'flat', selectedUser.flatId, 'user', userId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }

  getPrivileges() {
    this.privileges = this.userProfileService.getUserPermissionsForFeature(
      CONSTANTS.application.backoffice,
      CONSTANTS.featuretypeid.Society
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
