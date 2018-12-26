import { SocietyInfoComponent } from './society/society-info/society-info.component';
import { SocietyListComponent } from './society/society-list/society-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { StateResolverService } from 'src/app/common/shared/services/resolver/state-resolver.service';
import { BuildingListComponent } from './building/building-list/building-list.component';


export const societyRoutes: Routes = [
  { path: 'societies', component: SocietyListComponent },
  { path: 'society/:id/:operation', component: SocietyInfoComponent ,
    resolve: {
      states: StateResolverService
    }},
  {path: 'society/:id/:operation/buildings', component: BuildingListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(societyRoutes)],
  exports: [RouterModule]
})
export class SocietyMgmtRoutingModule {}

export const routedSocietyComponents = [
  SocietyListComponent,
  SocietyInfoComponent
];
