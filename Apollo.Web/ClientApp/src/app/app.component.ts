import { Component, OnInit } from '@angular/core';
import { FrameworkConfigDataService } from './common/shared/services/framework-config-data.service';
import { MenuDataService } from './common/shared/services/menu-data.service';
import { AuthService } from './common/shared/services/auth.service';
import { Router } from '@angular/router';
import { defaultMenuItems } from './app.menu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private frameworkConfigDataService: FrameworkConfigDataService,
  private menuDataService: MenuDataService, private _authService: AuthService ,
   private _router: Router) {
    this.initialize();
  }

  ngOnInit(): void {
    if (window.location.href.indexOf('?postLogout=true') > 0) {
      this._authService.signoutRedirectCallback().then(() => {
        const url: string = this._router.url.substring(
          0,
          this._router.url.indexOf('?')
        );
        this._router.navigateByUrl(url);
      });
    }
    this.initialize();
  }

  initialize() {
    // Initialize the framework settings
    this.frameworkConfigDataService.configure();

    // Had to do since the it was showing change detection error - So dummy menus
    this.menuDataService.initializeNonLoggedInMenus(defaultMenuItems);

    // Route to default by always
    this._router.navigate(['/default']);
  }
}
