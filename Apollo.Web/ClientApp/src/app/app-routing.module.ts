import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './common/dashboard/dashboard/dashboard.component';
import { TestComponent } from './common/dashboard/test/test.component';

export const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent},
  { path: 'test', component: TestComponent},
  { path: '', component: DashboardComponent },
  { path: '**', component: DashboardComponent },
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
