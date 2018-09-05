import { NgModule, APP_INITIALIZER, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigurationService } from './services/configuration.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  declarations: [],
  providers: [
 // ConfigurationService, {
   {
 // Here we request that configuration loading be done at app-
 // initialization time (prior to rendering)
  provide: APP_INITIALIZER,
  useFactory: (configService: ConfigurationService) =>
   () => configService.loadConfigurationData(),
  deps: [ConfigurationService],
  multi: true
}
  ]
})
export class SharedModule {
  // Preventing importing this modules more than once
  // https://angular.io/guide/ngmodule-faq
  constructor(@Optional() @SkipSelf() parentModule: SharedModule) {
    if (parentModule) {
      throw new Error(
        'SharedModule is already loaded. Import it in the AppModule only');
    }
  }
}
