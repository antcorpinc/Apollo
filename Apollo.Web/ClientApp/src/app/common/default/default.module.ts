import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultComponent } from './default/default.component';
import { HomeComponent } from './home/home.component';
import { AuthenticatedUserComponent } from './authenticated-user/authenticated-user.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../material/material.module';

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    RouterModule,
    MaterialModule
  ],
  declarations: [DefaultComponent, HomeComponent, AuthenticatedUserComponent]
})
export class DefaultModule { }
