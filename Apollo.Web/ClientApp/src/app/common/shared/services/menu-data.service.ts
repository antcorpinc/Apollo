import { Injectable } from '@angular/core';
import { MenuService, IMenuItem } from '../../../framework/fw/services/menu.service';
import { initialMenuItems } from '../../../app.menu';
import { UserDetailsViewModel } from '../../viewmodels/userdetailsviewmodel';

@Injectable({
  providedIn: 'root'
})
export class MenuDataService {
  _userDetails: UserDetailsViewModel;
  constructor(private menuService: MenuService) { }

  initializeNonLoggedInMenus(menuItems: IMenuItem[]) {
    this.menuService.items = this.initializeMenuData(menuItems);
  }

  initializeLoggedInMenus(userDetails: UserDetailsViewModel) {
    this._userDetails = userDetails;
    if (userDetails.applicationPermissions.length > 0) {
      // const app = userDetails.applicationPermissions[0].name;
   //   const app  = this.topBarService.getTopBarItem().applications[0].application;
   //    const translatedMenu = this.TransformMenuData(app);
   //   console.log('Translated Menus' + JSON.stringify(translatedMenu));
     }
  }

  // Todo:This is used for testing only
 private initializeTestMenuData(menuItems: Array<IMenuItem>) {
    const translatedMenus: Array<IMenuItem> = new Array<IMenuItem>();
    menuItems.forEach(item => {
      const tempMenuItem: IMenuItem = {icon: '', route: '', submenu: null, text: ''};
      tempMenuItem.icon = item.icon;
      tempMenuItem.route = item.route;
      tempMenuItem.text = item.text;
      if (item.submenu !== null) {
        tempMenuItem.submenu  = this.initializeTestMenuData(item.submenu);
      } else {
        tempMenuItem.submenu = null;
      }
      translatedMenus.push(tempMenuItem);
    });
    return translatedMenus;
  }

  private initializeMenuData(menuItems: Array<IMenuItem>) {
    const translatedMenus: Array<IMenuItem> = new Array<IMenuItem>();
    menuItems.forEach(item => {
      const tempMenuItem: IMenuItem = {icon: '', route: '', submenu: null, text: ''};
      tempMenuItem.icon = item.icon;
      tempMenuItem.route = item.route;
      tempMenuItem.text = item.text;
      if (item.submenu !== null) {
        tempMenuItem.submenu  = this.initializeMenuData(item.submenu);
      } else {
        tempMenuItem.submenu = null;
      }
      translatedMenus.push(tempMenuItem);
    });
    return translatedMenus;
  }
}
