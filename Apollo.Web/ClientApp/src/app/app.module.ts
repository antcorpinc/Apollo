import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FwModule } from './framework/fw/fw.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FwModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
