import { Component, OnInit, ViewChild } from '@angular/core';
import { FlatListViewModel } from 'src/app/backoffice/viewmodel/society-vm/flatlistviewmodel';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CONSTANTS } from 'src/app/common/constants';
import { Router, ActivatedRoute } from '@angular/router';
import { UserProfileService } from 'src/app/common/shared/services/user-profile.service';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { BuildingDataService } from 'src/app/backoffice/common/backoffice-shared/services/building-data.service';

@Component({
  selector: 'app-flat-list',
  templateUrl: './flat-list.component.html',
  styleUrls: ['./flat-list.component.css']
})
export class FlatListComponent implements OnInit {
  flats: FlatListViewModel[] = [];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<FlatListViewModel>;
  displayedColumns = ['name', 'isActive', 'actions'];
  totalRecords: number;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  societyOperation: string;
  buildingOperation: string;
  societyId: string;
  buildingId: string;

  privileges: string[];
  deleteAction = false;
  createAction = false;
  readAction = false;

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    public societyDataService: SocietyDataService,
    public buildingDataService: BuildingDataService,
     private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.societyOperation = this.activatedRoute.snapshot.paramMap.get('societyoperation');
    this.societyId = this.activatedRoute.snapshot.paramMap.get('societyid');
    this.buildingOperation = this.activatedRoute.snapshot.paramMap.get('operation');
    this.buildingId = this.activatedRoute.snapshot.paramMap.get('id');
    this.getFlats();
    this.getPrivileges();
  }
  getFlats() {
    this.flats = this.activatedRoute.snapshot.data['flats'];
    this.dataSource = new MatTableDataSource<FlatListViewModel>(this.flats);
    this.dataSource.sort = this.sort;
    this.totalRecords = this.flats.length;
  }

  // Privileges are inherited from the top parent ie the one accessible from the Menus - in this
  // case the society profile - If user has access society then he has access to building as well
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
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  goToFlat(value) {
    const val = value.split(':');
    const flatId = val[0];
    this.operation = val[1];
     this.router.navigate(['/auth/bo/societymgmt/society', this.societyId, this.societyOperation,
      'building', this.buildingId, this.buildingOperation, 'flat', flatId, this.operation ]
      , { relativeTo: this.activatedRoute });
  }

  createFlat() {
     this.router.navigate(['../flat', CONSTANTS.create.id, this.create],
    { relativeTo: this.activatedRoute });
  }
}
