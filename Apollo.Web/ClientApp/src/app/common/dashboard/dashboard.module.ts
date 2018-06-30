import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TestComponent } from './test/test.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [DashboardComponent, TestComponent]
})
export class DashboardModule { }
