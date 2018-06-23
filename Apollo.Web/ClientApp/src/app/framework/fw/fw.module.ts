import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FrameworkBodyComponent } from './framework-body/framework-body.component';
import { ContentComponent } from './content/content.component';
import { TitleBarComponent } from './title-bar/title-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { StatusBarComponent } from './status-bar/status-bar.component';
import { MaterialModule } from '../../common/material/material.module';
import { MenuComponent } from './menus/menu/menu.component';
import { MenuItemComponent } from './menus/menu-item/menu-item.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [FrameworkBodyComponent, ContentComponent, TitleBarComponent, TopBarComponent, StatusBarComponent, MenuComponent, MenuItemComponent],
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
