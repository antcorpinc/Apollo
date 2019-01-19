import { Component, OnInit, ViewChild } from '@angular/core';
import { FlatListViewModel } from 'src/app/backoffice/viewmodel/society-vm/flatlistviewmodel';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CONSTANTS } from 'src/app/common/constants';
import { Router, ActivatedRoute } from '@angular/router';

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

  constructor(private router: Router, private activatedRoute: ActivatedRoute, ) { }

  ngOnInit() {
    this.societyOperation = this.activatedRoute.snapshot.paramMap.get('societyoperation');
    this.societyId = this.activatedRoute.snapshot.paramMap.get('societyid');
    this.buildingOperation = this.activatedRoute.snapshot.paramMap.get('operation');
    this.buildingId = this.activatedRoute.snapshot.paramMap.get('id');
    this.getFlats();
  }

  getFlats() {
    this.flats = this.activatedRoute.snapshot.data['flats'];

    console.log('Flats' +  JSON.stringify(this.flats));

  }

}
