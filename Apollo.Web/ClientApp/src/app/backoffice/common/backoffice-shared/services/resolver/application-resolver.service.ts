import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ApplicationViewModel } from '../../../../../backoffice/viewmodel/user-mgmt-vm/applicationviewmodel';
import { Observable } from 'rxjs';
import { BackOfficeLookupService } from '../lookup.service';

@Injectable({
  providedIn: 'root'
})
export class ApplicationResolverService implements Resolve<ApplicationViewModel[]> {

  constructor(private lookupService: BackOfficeLookupService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<ApplicationViewModel[]> {
      return this.lookupService.getApplications();
    }
}
