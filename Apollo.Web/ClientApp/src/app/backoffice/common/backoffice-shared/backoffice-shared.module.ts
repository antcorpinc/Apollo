import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BackofficeDashboardComponent } from './backoffice-dashboard/backoffice-dashboard.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/common/material/material.module';
import { ConfirmDialogComponent } from './dialogs/confirm-dialog/confirm-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  declarations: [BackofficeDashboardComponent, ConfirmDialogComponent],
  entryComponents: [ConfirmDialogComponent]
})
export class BackofficeSharedModule { }
