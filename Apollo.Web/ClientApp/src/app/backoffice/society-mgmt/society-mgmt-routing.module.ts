import { SocietyInfoComponent } from './society/society-info/society-info.component';
import { SocietyListComponent } from './society/society-list/society-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { StateResolverService } from 'src/app/common/shared/services/resolver/state-resolver.service';
import { BuildingListComponent } from './building/building-list/building-list.component';
import { BuildingsResolverService } from '../common/backoffice-shared/services/resolver/buildings-resolver.service';
import { BuildingInfoComponent } from './building/building-info/building-info.component';
import { FlatListComponent } from './flat/flat-list/flat-list.component';


export const societyRoutes: Routes = [
  { path: 'societies', component: SocietyListComponent },
  {
    path: 'society/:id/:operation', component: SocietyInfoComponent,
    resolve: {
      states: StateResolverService
    }
  },
  {
    path: 'society/:id/:operation/buildings', component: BuildingListComponent,
    resolve: { buildings: BuildingsResolverService }
  },
  {
    path: 'society/:societyid/:societyoperation/building/:id/:operation', component: BuildingInfoComponent,
  },
  {
    path: 'society/:societyid/:societyoperation/building/:id/:buildingoperation/flats', component: FlatListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(societyRoutes)],
  exports: [RouterModule]
})
export class SocietyMgmtRoutingModule { }

export const routedSocietyComponents = [
  SocietyListComponent,
  SocietyInfoComponent
];
