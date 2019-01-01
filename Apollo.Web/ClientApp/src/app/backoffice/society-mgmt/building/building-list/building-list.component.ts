import { Component, OnInit, ViewChild } from '@angular/core';
import { BuildingViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildingviewmodel';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CONSTANTS } from 'src/app/common/constants';
import { SocietyDataService } from 'src/app/backoffice/common/backoffice-shared/services/society-data.service';
import { UserProfileService } from 'src/app/common/shared/services/user-profile.service';

@Component({
  selector: 'app-building-list',
  templateUrl: './building-list.component.html',
  styleUrls: ['./building-list.component.css']
})
export class BuildingListComponent implements OnInit {
  buildings: BuildingViewModel[] = [];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<BuildingViewModel>;
  displayedColumns = ['name', 'isActive', 'actions'];
  totalRecords: number;

  edit = CONSTANTS.operation.edit;
  create = CONSTANTS.operation.create;
  read = CONSTANTS.operation.read;
  operation: string;

  privileges: string[];
  deleteAction = false;
  createAction = false;
  readAction = false;

  constructor(private router: Router, private activatedRoute: ActivatedRoute,
    public societyDataService: SocietyDataService,
    private userProfileService: UserProfileService) { }

  ngOnInit() {
    this.getBuildings();
    this.getPrivileges();
  }

  getBuildings() {
    this.buildings = this.activatedRoute.snapshot.data['buildings'];
    this.dataSource = new MatTableDataSource<BuildingViewModel>(this.buildings);
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
  }
}
