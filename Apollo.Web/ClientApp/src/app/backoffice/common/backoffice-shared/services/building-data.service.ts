import { Injectable } from '@angular/core';
import { BuildingViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildingviewmodel';
import { Observable } from 'rxjs';
import { ConfigurationService } from 'src/app/common/shared/services/configuration.service';
import { AuthenticatedHttpService } from 'src/app/common/shared/services/authenticated-http.service';

@Injectable({
  providedIn: 'root'
})
export class BuildingDataService {

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService) { }

  getBuildingsInSociety(societyId: string): Observable<BuildingViewModel[]> {
    return this.authenticatedHttpService.get(
      `${this.configurationService.config.baseUrls.societyApi}api/societies/${societyId}/buildings`);
  }

  getBuildingInSociety(societyId: string, buildingId: string): Observable<BuildingViewModel> {
    return this.authenticatedHttpService.get(
      `${this.configurationService.config.baseUrls.societyApi}api/societies/${societyId}/buildings/${buildingId}`);
  }

  createBuildingInSociety(societyId: string, building: BuildingViewModel) {
    return this.authenticatedHttpService.post(
      `${this.configurationService.config.baseUrls.societyApi}api/societies/${societyId}/buildings`,
       building);
  }
  updateBuildingInSociety(societyId: string, buildingId: string, building: BuildingViewModel) {
    return this.authenticatedHttpService.put(
      `${this.configurationService.config.baseUrls.societyApi}api/societies/${societyId}/buildings/${buildingId}`,
       building
    );
  }
}
