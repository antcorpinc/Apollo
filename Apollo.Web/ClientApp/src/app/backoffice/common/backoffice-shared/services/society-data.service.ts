import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SocietyListViewModel } from 'src/app/backoffice/viewmodel/society-vm/societylistviewmodel';
import { ConfigurationService } from 'src/app/common/shared/services/configuration.service';
import { AuthenticatedHttpService } from 'src/app/common/shared/services/authenticated-http.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SocietyDataService {

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
}
