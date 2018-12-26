import { Component, OnInit, ViewChild } from '@angular/core';
import { BuildingViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildingviewmodel';
import { ActivatedRoute } from '@angular/router';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

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

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getBuildings();
  }

  getBuildings() {
    this.buildings = this.activatedRoute.snapshot.data['buildings'];
    this.dataSource = new MatTableDataSource<BuildingViewModel>(this.buildings);
        this.dataSource.sort = this.sort;
        this.totalRecords = this.buildings.length;
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

}
