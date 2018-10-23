import { Component, OnInit } from '@angular/core';
import { ApplicationViewModel } from '../../../../backoffice/viewmodel/user-mgmt-vm/applicationviewmodel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-support-user-info',
  templateUrl: './support-user-info.component.html',
  styleUrls: ['./support-user-info.component.css']
})
export class SupportUserInfoComponent implements OnInit {
  applicationList: ApplicationViewModel[];

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getApplications();
  }

  getApplications() {
    this.applicationList = this.activatedRoute.snapshot.data['applications'];
  //  console.log(this.applicationList);
  }

}
