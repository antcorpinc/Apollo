import { NgModule } from '@angular/core';
import { FwModule } from './framework/fw/fw.module';
import { AppComponent } from './app.component';
import {SharedModule} from './common/shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { DashboardModule } from './common/dashboard/dashboard.module';
import { DefaultModule } from './common/default/default.module';
import { BackofficeSharedModule } from './backoffice/common/backoffice-shared/backoffice-shared.module';
import { SocietySharedModule } from './society/common/society-shared/society-shared.module';
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    FwModule,
    SharedModule,
    DashboardModule, // Todo - Remove this later.
    DefaultModule,
    BackofficeSharedModule,
    SocietySharedModule,
    // Routing Module should be the last.
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
