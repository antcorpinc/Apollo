import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from '../../common/material/material.module';
import { BackofficeSharedModule } from '../common/backoffice-shared/backoffice-shared.module';
import { SocietyMgmtRoutingModule, routedSocietyComponents } from './society-mgmt-routing.module';
import { BuildingInfoComponent } from './building/building-info/building-info.component';
import { BuildingListComponent } from './building/building-list/building-list.component';
import { FlatInfoComponent } from './flat/flat-info/flat-info.component';
import { FlatListComponent } from './flat/flat-list/flat-list.component';

@NgModule({
  imports: [
    CommonModule,
    SocietyMgmtRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    BackofficeSharedModule,
  ],
  declarations: [routedSocietyComponents, BuildingInfoComponent, BuildingListComponent, FlatInfoComponent, FlatListComponent]
})
export class SocietyMgmtModule { }
