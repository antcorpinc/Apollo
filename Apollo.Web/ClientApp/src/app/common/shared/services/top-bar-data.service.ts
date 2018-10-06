import { Injectable } from '@angular/core';
import { UserDetailsViewModel } from '../../viewmodels/userdetailsviewmodel';
import { ITopBarItem, IAppRole } from '../../../framework/fw/viewmodels/topbaritemviewmodel';
import { TopBarService } from '../../../framework/fw/services/top-bar.service';
import {Location} from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class TopBarDataService {
  private _userDetails: UserDetailsViewModel;
  private _topBarItem: ITopBarItem;

  constructor(private topBarService: TopBarService,
    private location: Location) { }

    initializeTopBarData(userDetails: UserDetailsViewModel) {
      this._userDetails = userDetails;
      this.transformTopBarData();
      this.topBarService.setTopBarItem(this._topBarItem);
    }

    private transformTopBarData() {
      const  topBarItemViewModel: ITopBarItem = { activeApplication: '',
      activeRole: '', applications: null, firstName: '', lastName: '', profilePictureUri: ''};
      topBarItemViewModel.firstName = this._userDetails.firstName;
      topBarItemViewModel.lastName = this._userDetails.lastName;
      topBarItemViewModel.profilePictureUri = this._userDetails.profilePictureUri;
      topBarItemViewModel.applications = new Array<IAppRole>();
      if (!this.location.path().length ) {
      this._userDetails.applicationPermissions.forEach(val =>
        topBarItemViewModel.applications.push({
          application: val.name,
          role: val.role
        })) ;
      } else {
        const appRoles = this.determineAppOrder();
        appRoles.forEach(val =>
          topBarItemViewModel.applications.push({
            application: val.appName,
            role: val.roleName
          }));
      }
      this._topBarItem = topBarItemViewModel;
    }

    private determineAppOrder() {
      const appRoles: AppRole[] = [];
       // Keep the default as is
          this._userDetails.applicationPermissions.forEach((val ) => {
                appRoles.push( {
                appName: val.name,
                roleName: val.role
              });
          });
        return appRoles;
    }
}

class AppRole {
  appName: string;
  roleName: string;
}
