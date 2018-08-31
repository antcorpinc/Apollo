import { Injectable } from '@angular/core';
import { MenuService, IMenuItem } from '../../../framework/fw/services/menu.service';
import { initialMenuItems } from '../../../app.menu';

@Injectable({
  providedIn: 'root'
})
export class MenuDataService {

  constructor(private menuService: MenuService) { }

  initialize() {
   const menuItems =  this.initializeTestMenuData(initialMenuItems);
   this.menuService.items = menuItems;
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

}
