import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { BuildingViewModel } from 'src/app/backoffice/viewmodel/society-vm/buildingviewmodel';
import { Observable } from 'rxjs';
import { BuildingDataService } from '../building-data.service';

@Injectable({
  providedIn: 'root'
})
export class BuildingsResolverService implements Resolve<BuildingViewModel[]> {

  constructor(private buildingDataService: BuildingDataService) { }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<BuildingViewModel[]> {
      const societyId = route.paramMap.get('id');
      return this.buildingDataService.getBuildingsInSociety(societyId);
    }
}
