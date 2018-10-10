import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultComponent } from './default/default.component';
import { HomeComponent } from './home/home.component';
import { AuthenticatedUserComponent } from './authenticated-user/authenticated-user.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [DefaultComponent, HomeComponent, AuthenticatedUserComponent]
})
export class DefaultModule { }
