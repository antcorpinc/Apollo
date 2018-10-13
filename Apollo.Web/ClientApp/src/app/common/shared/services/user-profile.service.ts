import { Injectable } from '@angular/core';
import {AuthenticatedHttpService} from './authenticated-http.service';
import { ConfigurationService } from './configuration.service';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';
import { MenuDataService } from './menu-data.service';
import { initialMenuItems } from '../../../app.menu';
import { UserDetailsViewModel } from '../../viewmodels/userdetailsviewmodel';
import {UserInfoViewModel} from '../../viewmodels/userinfoviewmodel';
import { StateService } from './state.service';
import { TopBarDataService } from './top-bar-data.service';
@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  userDetailsDto: UserDetailsViewModel;
  basicUserInfo: UserInfoViewModel;

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService,
    private authService: AuthService, private _router: Router,
    private topBarDataService: TopBarDataService,
    private stateService: StateService,
    private menuDataService: MenuDataService) {
      this.userDetailsDto = new UserDetailsViewModel();
    }

  getUserProfile() {
    if (this.authService.isLoggedIn()) {
      // Todo --> No need to pass the UserId as it is already part of the token.
    this.authenticatedHttpService.get(this.configurationService.config.baseUrls.userMgmtApi
      + 'api/User/' + this.authService.getSubjectId()).subscribe((user ) => {
        this.userDetailsDto = user;

        if (this.userDetailsDto) {
          if (!this.userDetailsDto.isActive || this.userDetailsDto.applicationPermissions === undefined
              || this.userDetailsDto.applicationPermissions.length === 0) {
           this._router.navigate(['/unauthorized']);
         } else {
            this.setBasicUserInfo(this.userDetailsDto);
            // Give it all information that is needed to display the TopBar component
            this.topBarDataService.initializeTopBarData(this.userDetailsDto);
            // Give it all information that is needed to display the Menu component
            this.menuDataService.initializeLoggedInMenus(this.userDetailsDto);
            // Create a State Service to route to the right View
            this.stateService.initializeState(this.userDetailsDto);
            // Todo - Change the below add State Service
            // this._router.navigate(['/home']);

         }
        }
      },
      (error: any ) => {
        console.log(error);
      });
    } else {
      // Initialize Non Logged in Menu
      this.menuDataService.initializeNonLoggedInMenus(initialMenuItems);
      this._router.navigate(['/home']);
    }
  }

  setBasicUserInfo(userDetails: UserDetailsViewModel) {
    this.basicUserInfo = new UserInfoViewModel();
    this.basicUserInfo.firstName = userDetails.firstName;
    this.basicUserInfo.lastName = userDetails.lastName;
    this.basicUserInfo.userType = userDetails.userType;
    this.basicUserInfo.userName = userDetails.userName;
    this.basicUserInfo.email = userDetails.email;
    this.basicUserInfo.id = userDetails.id;
  }

  getBasicUserInfo() {
    return this.basicUserInfo;
  }

}
