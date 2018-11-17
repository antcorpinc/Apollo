import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { SocietyListViewModel } from 'src/app/backoffice/viewmodel/society-vm/societylistviewmodel';
import { Subscription } from 'rxjs';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CONSTANTS } from 'src/app/common/constants';
import { Router, ActivatedRoute } from '@angular/router';
import { UserProfileService } from 'src/app/common/shared/services/user-profile.service';

@Component({
  selector: 'app-society-list',
  templateUrl: './society-list.component.html',
  styleUrls: ['./society-list.component.css']
})
export class SocietyListComponent implements OnInit , OnDestroy {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<SocietyListViewModel>;
  displayedColumns = ['name', 'area', 'city', 'state', 'isActive', 'actions'];
  totalRecords: number;

  subscriptions: Subscription[] = [];
  societyList: SocietyListViewModel[];

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  privileges: string[];
  deleteAction = false;
  createAction = false;
  readAction = false;

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    private societyDataService: SocietyDataService, private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.getSocietyList();
    this.getPrivileges();
  }

  getSocietyList() {
    const subscription = this.societyDataService.getSocieties()
      .subscribe((data) => {
        console.log('Societies  are ' + JSON.stringify(data));
        this.societyList = data;
        this.dataSource = new MatTableDataSource<SocietyListViewModel>(this.societyList);
        this.dataSource.sort = this.sort;
        this.totalRecords = this.societyList.length;
      },
        (error) => {
          console.log('Error' + error);
        });
    this.subscriptions.push(subscription);
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  goToSociety(value) {
    const val = value.split(':');
    const societyId = val[0];
    this.operation = val[1];
    this.router.navigate(['../society', societyId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });
  }
  getPrivileges() {
    this.privileges = this.userProfileService.getUserPermissionsForFeature(
      CONSTANTS.application.backoffice,
      CONSTANTS.featuretypeid.SocietyProfile
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

    createSociety() {

    }
  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

}
