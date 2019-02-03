import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserMgmtRoutingModule, routedUserComponents } from './user-mgmt-routing.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from '../../common/material/material.module';
import { BackofficeSharedModule } from '../common/backoffice-shared/backoffice-shared.module';
import { ConfirmDialogComponent } from './dialogs/confirm-dialog/confirm-dialog.component';
import { SocietyUserListComponent } from './society-user/society-user-list/society-user-list.component';
import { SocietyUserInfoComponent } from './society-user/society-user-info/society-user-info.component';

@NgModule({
  imports: [
    CommonModule,
    UserMgmtRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    BackofficeSharedModule,

  ],
  declarations: [ routedUserComponents, ConfirmDialogComponent, SocietyUserListComponent, SocietyUserInfoComponent],
  entryComponents: [ConfirmDialogComponent]
})
export class UserMgmtModule { }
