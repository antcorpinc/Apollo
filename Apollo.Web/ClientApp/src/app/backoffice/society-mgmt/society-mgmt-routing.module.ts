import { SocietyInfoComponent } from './society/society-info/society-info.component';
import { SocietyListComponent } from './society/society-list/society-list.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { StateResolverService } from 'src/app/common/shared/services/resolver/state-resolver.service';


export const societyRoutes: Routes = [
  { path: 'societies', component: SocietyListComponent },
  { path: 'society/:id/:operation', component: SocietyInfoComponent ,
    resolve: {
      states: StateResolverService
    }},
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
