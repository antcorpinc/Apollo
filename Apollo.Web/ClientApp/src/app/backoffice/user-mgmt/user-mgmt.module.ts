import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserMgmtRoutingModule, routedUserComponents } from './user-mgmt-routing.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from '../../common/material/material.module';
import { BackofficeSharedModule } from '../common/backoffice-shared/backoffice-shared.module';
import { DialogsModule } from '../common/backoffice-shared/dialogs/dialogs.module';

@NgModule({
  imports: [
    CommonModule,
    UserMgmtRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    BackofficeSharedModule,
    DialogsModule,
  ],
  declarations: [ routedUserComponents]
})
export class UserMgmtModule { }
