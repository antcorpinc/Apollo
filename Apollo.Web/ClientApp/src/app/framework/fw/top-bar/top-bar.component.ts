import { Component, OnInit } from '@angular/core';
import { FrameworkConfigService } from '../services/framework-config.service';
import { TopBarService } from '../services/top-bar.service';
import { AuthService } from '../../../common/shared/services/auth.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  currentApp: string;
  constructor(public frameworkConfigService: FrameworkConfigService ,
    private _authService: AuthService, public topBarService: TopBarService) { }

  ngOnInit() {
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
