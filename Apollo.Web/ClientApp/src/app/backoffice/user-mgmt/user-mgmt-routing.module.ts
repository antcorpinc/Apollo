import { Routes, RouterModule } from '@angular/router';
import { SupportUserListComponent } from './support-user/support-user-list/support-user-list.component';
import { NgModule } from '@angular/core';

export const userRoutes: Routes = [
  { path: 'supportusers', component: SupportUserListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(userRoutes)],
  exports: [RouterModule]
})
export class UserMgmtRoutingModule {}

export const routedUserComponents = [
  SupportUserListComponent
];
