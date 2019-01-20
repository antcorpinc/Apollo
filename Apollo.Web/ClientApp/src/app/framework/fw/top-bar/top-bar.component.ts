import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { FrameworkConfigService } from '../services/framework-config.service';
import { TopBarService } from '../services/top-bar.service';
import { AuthService } from '../../../common/shared/services/auth.service';
import { MatMenuTrigger } from '@angular/material';
@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit , OnChanges {

  @ViewChild(MatMenuTrigger) trigger: MatMenuTrigger;
  currentApp: string;
  constructor(public frameworkConfigService: FrameworkConfigService ,
    private _authService: AuthService, public topBarService: TopBarService) { }

  ngOnInit() {
  }

  ngOnChanges() {
    console.log('On Changes being called');
  }

  login() {
    this._authService.login();
  }

  logout() {
    this._authService.logout();
  }

  isLoggedIn() {
    return this._authService.isLoggedIn();
  }

  onApplicationChange($event) {
    this.topBarService.onAppChange($event);
    this.currentApp = $event.target.value;
  }
}
