import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupportUserListComponent } from './support-user/support-user-list/support-user-list.component';
import { SupportUserInfoComponent } from './support-user/support-user-info/support-user-info.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [SupportUserListComponent, SupportUserInfoComponent]
})
export class UserMgmtModule { }
