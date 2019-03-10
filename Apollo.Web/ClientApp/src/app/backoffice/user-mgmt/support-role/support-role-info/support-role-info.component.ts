import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CONSTANTS } from 'src/app/common/constants';

@Component({
  selector: 'app-support-role-info',
  templateUrl: './support-role-info.component.html',
  styleUrls: ['./support-role-info.component.css']
})
export class SupportRoleInfoComponent implements OnInit {
  operation: string;
  selectedOption: string;

  constructor(private activatedRoute: ActivatedRoute, ) { }

  ngOnInit() {
    this.operation = this.activatedRoute.snapshot.params['operation'];
    this.selectedOption = this.activatedRoute.snapshot.data['applications'].find(x =>
      x.name.toLowerCase()  ===  CONSTANTS.application.backoffice.toLocaleLowerCase()).id;

  }

}
