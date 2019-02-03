import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from 'src/app/common/shared/services/authenticated-http.service';
import { ConfigurationService } from 'src/app/common/shared/services/configuration.service';
import { Observable } from 'rxjs';
import { RoleViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/roleviewmodel';

@Injectable({
  providedIn: 'root'
})
export class RoleDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService ) { }

    getRolesInSociety(societyId: string): Observable<RoleViewModel[]> {
      return this.authenticatedHttpService.get(this.configurationService.config.baseUrls.userMgmtApi +
        'api/role/getrolesinsociety?societyId=' + societyId);
    }
}
