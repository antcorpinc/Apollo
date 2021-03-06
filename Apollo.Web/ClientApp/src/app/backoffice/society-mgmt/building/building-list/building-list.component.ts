import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CONSTANTS } from 'src/app/common/constants';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { UserProfileService } from 'src/app/common/shared/services/user-profile.service';
import { BuildingListViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildinglistviewmodel';

@Component({
  selector: 'app-building-list',
  templateUrl: './building-list.component.html',
  styleUrls: ['./building-list.component.css']
})
export class BuildingListComponent implements OnInit {
  buildings: BuildingListViewModel[] = [];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<BuildingListViewModel>;
  displayedColumns = ['name', 'isActive', 'actions'];
  totalRecords: number;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;
  societyOperation: string;
  societyId: string;

  privileges: string[];
  deleteAction = false;
  createAction = false;
  readAction = false;

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    public societyDataService: SocietyDataService,
    private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.societyOperation = this.activatedRoute.snapshot.paramMap.get('operation');
    this.societyId = this.activatedRoute.snapshot.paramMap.get('id');

    this.getBuildings();
    this.getPrivileges();
  }

  getBuildings() {
    this.buildings = this.activatedRoute.snapshot.data['buildings'];
    this.dataSource = new MatTableDataSource<BuildingListViewModel>(this.buildings);
    this.dataSource.sort = this.sort;
    this.totalRecords = this.buildings.length;
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
  createBuilding() {
    this.router.navigate(['../building', CONSTANTS.create.id, this.create],
       { relativeTo: this.activatedRoute });
  }

  goToBuilding(value) {
    const val = value.split(':');
    const buildingId = val[0];
    this.operation = val[1];
 //    this.router.navigate(['../../society', this.societyId, this.societyOperation, 'building',
 //     buildingId, this.operation.trim().toLowerCase()], { relativeTo: this.activatedRoute });

    this.router.navigate(['/auth/bo/societymgmt/society', this.societyId,
     this.societyOperation, 'building', buildingId, this.operation], { relativeTo: this.activatedRoute });


  }
}
