import { Injectable } from '@angular/core';
import { ConfigurationService } from 'src/app/common/shared/services/configuration.service';
import { AuthenticatedHttpService } from 'src/app/common/shared/services/authenticated-http.service';
import { FlatListViewModel } from 'src/app/backoffice/viewmodel/society-vm/flatlistviewmodel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlatDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService) { }

    getFlatsInSocietyBuilding(societyId: string, buildingId: string): Observable<FlatListViewModel[]> {
      return this.authenticatedHttpService.get(
        `${this.configurationService.config.baseUrls.societyApi}api/societies/${societyId}/buildings/${buildingId}/flats`);
    }
}
