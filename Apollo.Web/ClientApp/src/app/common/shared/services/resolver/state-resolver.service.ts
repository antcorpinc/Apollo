import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { StateViewModel } from 'src/app/common/viewmodels/stateviewmodel';
import { LookupMasterService } from '../lookup-master.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StateResolverService implements Resolve<StateViewModel[]> {

  constructor(private lookupService: LookupMasterService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<StateViewModel[]> {
      return this.lookupService.getStates();
    }
}
