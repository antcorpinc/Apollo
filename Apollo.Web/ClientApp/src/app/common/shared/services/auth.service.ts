import { Injectable } from '@angular/core';
import {UserManager, User, WebStorageStateStore} from 'oidc-client';
import { ConfigurationService } from './configuration.service';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _userManager: UserManager;
  private _user: User;
  constructor(private configurationService: ConfigurationService) {
    const config = {
      authority: this.configurationService.config.baseUrls.sts,
      client_id: this.configurationService.config.identityClient.clientId,
      redirect_uri: `${this.configurationService.config.baseUrls.web}assets/oidc-login-redirect.html`,
      // TODO: Update the Scope as required
      scope: 'openid profile apollo.api.usermanagement',
      response_type: 'id_token token',
      post_logout_redirect_uri: `${this.configurationService.config.baseUrls.web}?postLogout=true`,
      userStore: new WebStorageStateStore({ store: window.localStorage}),
    };
    this._userManager = new UserManager(config);

    this._userManager.getUser().then(user => {
      if (user && !user.expired) {
        this._user = user;
      }
    });
  }

  login(): Promise<any> {
    return this._userManager.signinRedirect();
  }

  logout(): Promise<any> {
    return this._userManager.signoutRedirect();
  }

  isLoggedIn(): boolean {
    return this._user && this._user.access_token && !this._user.expired;
  }

  getAccessToken(): string {
    return this._user ? this._user.access_token : '';
  }

  signoutRedirectCallback(): Promise<any> {
    return this._userManager.signoutRedirectCallback();
  }

  // Todo: Actually we shouldn't be needing this since when we make call to API
  // this is already available in [sub] claim.BUt to keep it consistent addded this here
  getSubjectId(): string {
    return this._user ? this._user.profile.sub : '';
  }
}
