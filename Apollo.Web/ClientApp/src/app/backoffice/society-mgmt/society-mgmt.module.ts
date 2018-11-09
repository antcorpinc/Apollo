import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from '../../common/material/material.module';
import { BackofficeSharedModule } from '../common/backoffice-shared/backoffice-shared.module';
import { SocietyMgmtRoutingModule, routedSocietyComponents } from './society-mgmt-routing.module';

@NgModule({
  imports: [
    CommonModule,
    SocietyMgmtRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    BackofficeSharedModule,
  ],
  declarations: [routedSocietyComponents]
})
export class SocietyMgmtModule { }
