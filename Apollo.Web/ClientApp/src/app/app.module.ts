import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FwModule } from './framework/fw/fw.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MaterialModule} from './common/material/material.module';
import {SharedModule} from './common/shared/shared.module';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FwModule,
    SharedModule,
    MaterialModule
    // Routing Module should be the last.
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
