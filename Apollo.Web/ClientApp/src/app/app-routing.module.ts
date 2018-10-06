import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './common/dashboard/dashboard/dashboard.component';
import { TestComponent } from './common/dashboard/test/test.component';
import { DefaultComponent } from './common/default/default/default.component';
import { HomeComponent } from './common/default/home/home.component';

export const routes: Routes = [
  // { path: 'dashboard', component: DashboardComponent},
  { path: 'default', component: DefaultComponent},
  { path: 'home' , component: HomeComponent},
  { path: 'test', component: TestComponent},
 // { path: '', component: DashboardComponent },
 // { path: '**', component: DashboardComponent },

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
