import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { ConfigurationService } from '../../../../common/shared/services/configuration.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { SupportUserListViewModel } from '../../../viewmodel/user-mgmt-vm/supportuserlistviewmodel';
import { SupportUserViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/supportuserviewmodel';
@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService) { }

  getSupportUsers(): Observable<SupportUserListViewModel[]> {
    return this.authenticatedHttpService.get(this.configurationService.config.baseUrls.userMgmtApi
      + 'api/supportuser/');
  }

  createSupportUser(user: SupportUserViewModel) {
    return this.authenticatedHttpService.post(this.configurationService.config.baseUrls.userMgmtApi
      + 'api/supportuser/create/', user);
  }

  getSupportUserById(userId: string): Observable<SupportUserViewModel> {
    return this.authenticatedHttpService.get(this.configurationService.config.baseUrls.userMgmtApi
      + 'api/supportuser/getbyid?userId=' + userId);
  }
}
