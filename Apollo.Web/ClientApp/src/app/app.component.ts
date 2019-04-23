import { Component, OnInit } from '@angular/core';
import { FrameworkConfigDataService } from './common/shared/services/framework-config-data.service';
import { MenuDataService } from './common/shared/services/menu-data.service';
import { AuthService } from './common/shared/services/auth.service';
import { Router } from '@angular/router';
import { defaultMenuItems } from './app.menu';
import { ErrorService } from './framework/fw/services/error.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(
    private frameworkConfigDataService: FrameworkConfigDataService,
    private menuDataService: MenuDataService,
    private _authService: AuthService,
    private _router: Router,
    private errorService: ErrorService
  ) {
    this.initialize();
  }

  ngOnInit(): void {
    const cookieEnabled = window.navigator.cookieEnabled;
    if (cookieEnabled) {
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
    } else {
      let cookieEnableLink = '';
      const userAgent = window.navigator.userAgent;
      if (userAgent.indexOf('Chrome') > -1) {
        cookieEnableLink =
          'https://support.google.com/accounts/answer/61416?co=GENIE.Platform%3DDesktop&hl=en';
      } else if (userAgent.indexOf('Firefox') > -1) {
        cookieEnableLink =
          'https://support.mozilla.org/en-US/kb/websites-say-cookies-are-blocked-unblock-them';
      } else if (userAgent.indexOf('Edge') > -1) {
        // tslint:disable-next-line:max-line-length
        cookieEnableLink =
          'https://answers.microsoft.com/en-us/edge/forum/edge_other-edge_win10/enabling-cookies-for-microsoft-edge/7c583015-0cde-4ddc-a1ad-45cc9d24c9fc';
      }
      this.errorService.message = 'Please Enable Cookies on your browser ';
      this.errorService.link = cookieEnableLink;
      this._router.navigate(['/error']);
    }
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
