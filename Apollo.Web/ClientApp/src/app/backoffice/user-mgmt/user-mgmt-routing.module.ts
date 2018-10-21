import { Routes, RouterModule } from '@angular/router';
import { SupportUserListComponent } from './support-user/support-user-list/support-user-list.component';
import { NgModule } from '@angular/core';
import { SupportUserInfoComponent } from './support-user/support-user-info/support-user-info.component';

export const userRoutes: Routes = [
  { path: 'supportusers', component: SupportUserListComponent },
  { path: 'supportuser/:id/:operation', component: SupportUserInfoComponent },
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
