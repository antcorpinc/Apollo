import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './common/dashboard/dashboard/dashboard.component';
import { TestComponent } from './common/dashboard/test/test.component';
import { DefaultComponent } from './common/default/default/default.component';
import { HomeComponent } from './common/default/home/home.component';
import { UnauthorizedComponent } from './framework/fw/unauthorized/unauthorized.component';
import { AuthenticatedUserComponent } from './common/default/authenticated-user/authenticated-user.component';
import { BackofficeDashboardComponent } from './backoffice/common/backoffice-shared/backoffice-dashboard/backoffice-dashboard.component';
import { SocietyDashboardComponent } from './society/common/society-shared/society-dashboard/society-dashboard.component';

export const routes: Routes = [
  // { path: 'dashboard', component: DashboardComponent},
  { path: 'default', component: DefaultComponent},
  { path: 'home' , component: HomeComponent},
  { path: 'test', component: TestComponent}, // Todo - Need to remove this
  { path: 'unauthorized', component: UnauthorizedComponent },

  // Authenticated Routes
  { path: 'auth', component: AuthenticatedUserComponent,
        children: [
          // All Authenticated BackOffice Routes
          { path : 'backofficedashboard' , component: BackofficeDashboardComponent},

          // ~ All Authenticated BackOffice Routes

          // All Authenticated Society Routes
          { path : 'societydashboard' , component: SocietyDashboardComponent},
          // ~ All Authenticated Society Routes
        ]
},
  // ~ Authenticated Routes
  { path: '', component: DefaultComponent },
  { path: '**', component: DefaultComponent },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
