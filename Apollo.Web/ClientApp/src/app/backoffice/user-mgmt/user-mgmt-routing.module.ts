import { Routes, RouterModule } from '@angular/router';
import { SupportUserListComponent } from './support-user/support-user-list/support-user-list.component';
import { NgModule } from '@angular/core';
import { SupportUserInfoComponent } from './support-user/support-user-info/support-user-info.component';
import { ApplicationResolverService } from '../common/backoffice-shared/services/resolver/application-resolver.service';
import { SocietyUserListComponent } from './society-user/society-user-list/society-user-list.component';
import { SocietyUserInfoComponent } from './society-user/society-user-info/society-user-info.component';

export const userRoutes: Routes = [
  { path: 'supportusers', component: SupportUserListComponent },
  { path: 'supportuser/:id/:operation', component: SupportUserInfoComponent ,
    resolve: {
      applications: ApplicationResolverService
    }
  },
  { path: 'societyusers', component: SocietyUserListComponent },
  { path: 'societyuser/:id/:operation', component: SocietyUserInfoComponent}
];

@NgModule({
  imports: [RouterModule.forChild(userRoutes)],
  exports: [RouterModule]
})
export class UserMgmtRoutingModule {}

export const routedUserComponents = [
  SupportUserListComponent,
  SupportUserInfoComponent
];
