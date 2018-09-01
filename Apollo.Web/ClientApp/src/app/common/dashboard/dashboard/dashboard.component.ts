import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../shared/services/configuration.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(public configService: ConfigurationService) { }

  ngOnInit() {
    console.log(this.configService.config.baseUrls.userMgmtApi);
  }



}
