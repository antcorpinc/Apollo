import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { ConfigurationService } from '../../../../common/shared/services/configuration.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService) { }

  getSupportUsers(): Observable<any> {
    return this.authenticatedHttpService.get(this.configurationService.config.baseUrls.userMgmtApi
      + 'api/supportuser/');
  }
}
