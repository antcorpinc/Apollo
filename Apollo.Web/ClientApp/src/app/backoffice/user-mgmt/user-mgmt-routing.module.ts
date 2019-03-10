import { Routes, RouterModule } from '@angular/router';
import { SupportUserListComponent } from './support-user/support-user-list/support-user-list.component';
import { NgModule } from '@angular/core';
import { SupportUserInfoComponent } from './support-user/support-user-info/support-user-info.component';
import { ApplicationResolverService } from '../common/backoffice-shared/services/resolver/application-resolver.service';
import { SocietyUserListComponent } from './society-user/society-user-list/society-user-list.component';
import { SocietyUserInfoComponent } from './society-user/society-user-info/society-user-info.component';
import { SupportRoleListComponent } from './support-role/support-role-list/support-role-list.component';
import { SupportRoleInfoComponent } from './support-role/support-role-info/support-role-info.component';

export const userRoutes: Routes = [
  { path: 'supportusers', component: SupportUserListComponent },
  {
    path: 'supportuser/:id/:operation', component: SupportUserInfoComponent,
    resolve: {
      applications: ApplicationResolverService
    }
  },
  { path: 'societyusers', component: SocietyUserListComponent },
  { path: 'societyuser/society/:societyid/building/:buildingid/flat/:flatid/user/:id/:operation', component: SocietyUserInfoComponent },
  { path: 'backofficesupportroles', component: SupportRoleListComponent },
  { path: 'backofficesupportrole/:applicationId/:roleId/:operation',
    component: SupportRoleInfoComponent,
    resolve: {
      applications: ApplicationResolverService
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(userRoutes)],
  exports: [RouterModule]
})
export class UserMgmtRoutingModule { }

export const routedUserComponents = [
  SupportUserListComponent,
  SupportUserInfoComponent,
  SupportRoleListComponent
];
