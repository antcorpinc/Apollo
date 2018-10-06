import { NgModule, Optional, SkipSelf } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FrameworkBodyComponent } from './framework-body/framework-body.component';
import { ContentComponent } from './content/content.component';
import { TitleBarComponent } from './title-bar/title-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { StatusBarComponent } from './status-bar/status-bar.component';
import { MaterialModule } from '../../common/material/material.module';
import { MenuComponent } from './menus/menu/menu.component';
import { MenuItemComponent } from './menus/menu-item/menu-item.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SideNavComponent } from './menus/side-nav/side-nav.component';
import { SideNavItemComponent } from './menus/side-nav-item/side-nav-item.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    ReactiveFormsModule
  ],
  declarations: [FrameworkBodyComponent, ContentComponent, TitleBarComponent,
    TopBarComponent, StatusBarComponent, MenuComponent, MenuItemComponent,
    SideNavComponent, SideNavItemComponent],
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
