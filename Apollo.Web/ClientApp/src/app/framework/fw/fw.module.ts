import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FrameworkBodyComponent } from './framework-body/framework-body.component';
import { ContentComponent } from './content/content.component';
import { TitleBarComponent } from './title-bar/title-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [FrameworkBodyComponent, ContentComponent, TitleBarComponent, TopBarComponent],
  exports: [
    FrameworkBodyComponent
  ]
})
export class FwModule {
  // Preventing importing this modules more than once
  // https://angular.io/guide/ngmodule-faq

  constructor( @Optional() @SkipSelf() parentModule: FwModule) {
    if (parentModule) {
      throw new Error(
        'FwModule is already loaded. Import it in the AppModule only');
    }
  }
}
