import { Injectable } from '@angular/core';
import { ConfigurationService } from 'src/app/common/shared/services/configuration.service';
import { AuthenticatedHttpService } from 'src/app/common/shared/services/authenticated-http.service';
import { FeatureViewModel } from 'src/app/backoffice/viewmodel/user-mgmt-vm/featureviewmodel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeatureDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService) { }

    getFeaturesInApplication(applicationId: string): Observable<FeatureViewModel[]> {
      return this.authenticatedHttpService.get(this.configurationService.config.baseUrls.userMgmtApi +
        'api/features/getfeaturesinapplication?applicationId=' + applicationId);
    }
}
