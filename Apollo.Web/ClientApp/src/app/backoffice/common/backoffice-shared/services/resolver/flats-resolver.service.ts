import { Injectable } from '@angular/core';
import { FlatDataService } from '../flat-data.service';
import { FlatListViewModel } from 'src/app/backoffice/viewmodel/society-vm/flatlistviewmodel';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FlatsResolverService  implements Resolve<FlatListViewModel[]> {

  constructor(private flatDataService: FlatDataService) { }
  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<FlatListViewModel[]> {
      const societyId = route.paramMap.get('societyid');
      const buildingId = route.paramMap.get('id');
      return this.flatDataService.getFlatsInSocietyBuilding(societyId, buildingId);
    }
}
