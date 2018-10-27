import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from '../../../../common/shared/services/authenticated-http.service';
import { ConfigurationService } from '../../../../common/shared/services/configuration.service';
import { ApplicationViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/applicationviewmodel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LookupService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService ) { }

    getApplications(): Observable<ApplicationViewModel[]> {
      return this.authenticatedHttpService.get(
        this.configurationService.config.baseUrls.userMgmtApi +
         'api/application/');
    }

    getRolesByApplicationIdAndUserType(applicationId, userType): Observable<any> {
      return this.authenticatedHttpService.get(this.configurationService.config.baseUrls.userMgmtApi +
         'api/Role/GetByApplicationId?applicationId=' + applicationId + '&userType=' + userType);
    }
}
