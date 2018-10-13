import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TopBarService } from '../../../framework/fw/services/top-bar.service';
import {Location} from '@angular/common';
import { UserDetailsViewModel } from '../../viewmodels/userdetailsviewmodel';
import { CONSTANTS } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  private _userDetails: UserDetailsViewModel;
  constructor(private router: Router,
    private topBarService: TopBarService,
    private location: Location) {
       // Subscribe to the event when the top bar application changes
       this.topBarService.appChange$.subscribe((app) => this.updateApp(app));
     }

     initializeState(userDetails: UserDetailsViewModel) {
      this._userDetails = userDetails;
      if (userDetails.applicationPermissions.length > 0) {
        const app  = this.topBarService.getTopBarItem().applications[0].application;
        this.setAppState(app);
      }
    }
     updateApp(appName) {
      this.setAppState(appName);
     }
     setAppState(app: string, role?: string) {
      const appPermission = this._userDetails.applicationPermissions.find(x => x.name === app);
      if (appPermission != null) {
        const appRole = appPermission.role;
        if (app.toUpperCase() === CONSTANTS.application.society.toUpperCase()) {
             this.router.navigate(['/auth/societydashboard']);
        } else if (app.toUpperCase() === CONSTANTS.application.backoffice.toUpperCase()) {
                this.router.navigate(['/auth/backofficedashboard']);
        }
      }
    }
}
