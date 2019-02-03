import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { BuildingDataService } from '../building-data.service';
import { BuildingListViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildinglistviewmodel';

@Injectable({
  providedIn: 'root'
})
export class BuildingsResolverService implements Resolve<BuildingListViewModel[]> {

  constructor(private buildingDataService: BuildingDataService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<BuildingListViewModel[]> {
      const societyId = route.paramMap.get('id');
      return this.buildingDataService.getBuildingsInSociety(societyId);
    }
}
