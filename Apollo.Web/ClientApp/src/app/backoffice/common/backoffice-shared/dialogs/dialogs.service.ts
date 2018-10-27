import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Observable } from 'rxjs';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class DialogsService {

  constructor(private dialog: MatDialog) { }

  confirm(title: string, message: string, buttonText?: string): Observable<boolean> {

    let dialogRef: MatDialogRef<ConfirmDialogComponent>;

    dialogRef = this.dialog.open(ConfirmDialogComponent);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;
    if (buttonText === undefined) {
      dialogRef.componentInstance.buttonText = 'OK';
    } else {
      dialogRef.componentInstance.buttonText = buttonText;
    }
    return dialogRef.afterClosed();
  }
}
