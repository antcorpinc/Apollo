import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SocietyListViewModel } from 'src/app/backoffice/viewmodel/society-vm/societylistviewmodel';
import { ConfigurationService } from 'src/app/common/shared/services/configuration.service';
import { AuthenticatedHttpService } from 'src/app/common/shared/services/authenticated-http.service';
import { map } from 'rxjs/operators';
import { SocietyViewModel } from 'src/app/backoffice/viewmodel/society-vm/societyviewmodel';
import { Utilities } from 'src/app/common/utilities/utilities';

@Injectable({
  providedIn: 'root'
})
export class SocietyDataService {
  private _societyName: string;

  constructor(private authenticatedHttpService: AuthenticatedHttpService,
    private configurationService: ConfigurationService) { }

    // Todo - Refactor this - Need to remove map - here ref for B2
  getSocieties(): Observable<SocietyListViewModel[]> {
    return this.authenticatedHttpService.get(this.configurationService.config.baseUrls.societyApi
      + 'api/society/').pipe(map((data) => {
         data.forEach(item => {
     //     item.updatedBy = 'Roni';
        });
        return data;
      }));
  }

  createSociety(society: SocietyViewModel) {
    return this.authenticatedHttpService.post(this.configurationService.config.baseUrls.societyApi
      + 'api/society/create/', society);
  }

  updateSociety(society: SocietyViewModel) {
    return this.authenticatedHttpService.post(this.configurationService.config.baseUrls.societyApi
      + 'api/society/update/', society);
  }
  getSocietiesByCustomSearch(customSearch: string): Observable<SocietyListViewModel[]> {
    return this.authenticatedHttpService.get(
      `${this.configurationService.config.baseUrls.societyApi}api/society/custom?customSearch=${customSearch}`
      );
  }

  getSocietyById(societyId: string): Observable<SocietyViewModel> {
    return this.authenticatedHttpService.get(
      `${this.configurationService.config.baseUrls.societyApi}api/society/${societyId}`);
  }

  get SocietyName() {
    return this._societyName;
  }

  set SocietyName(value: string) {
    if (!Utilities.isNullOrEmpty(value) ) {
      this._societyName = value;
    }
  }
}
