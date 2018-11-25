import { Injectable } from '@angular/core';
import { AuthenticatedHttpService } from './authenticated-http.service';
import { ConfigurationService } from './configuration.service';
import { Observable } from 'rxjs';
import { StateViewModel } from '../../viewmodels/stateviewmodel';
import { CityViewModel } from '../../viewmodels/cityviewmodel';

@Injectable({
  providedIn: 'root'
})
export class LookupMasterService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService ) { }

    getStates(): Observable<StateViewModel[]> {
      return this.authenticatedHttpService.get(
        this.configurationService.config.baseUrls.backOfficeApi +
         'api/state/');
    }

    getCitiesForState(stateId: number): Observable<CityViewModel[]> {
      return this.authenticatedHttpService.get(
         this.configurationService.config.baseUrls.backOfficeApi +
         'api/state/getcitiesforstate?stateId=' + stateId);
      // `${this.configurationService.config.baseUrls.backOfficeApi}api/state/getcitiesforstate/${stateId}`);
    }

    getAreasForCityState(stateId: number, cityId: number): Observable<CityViewModel[]> {
   //  return this.authenticatedHttpService.get(
   //   `${this.configurationService.config.baseUrls.backOfficeApi}api/state/getareasforcitystate?stateId=${stateId}&cityId=${cityId}`);
   return this.authenticatedHttpService.get(
     this.configurationService.config.baseUrls.backOfficeApi +
     'api/state/getareasforcitystate?stateId=' + stateId + '&cityId=' + cityId);
    }
}
