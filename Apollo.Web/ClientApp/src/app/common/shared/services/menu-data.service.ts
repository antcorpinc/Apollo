import { Injectable } from '@angular/core';
import { MenuService, IMenuItem } from '../../../framework/fw/services/menu.service';



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
export let initialMenuItems: Array<IMenuItem> = [
  {
    text: 'Dashboard',
    icon: 'fa fa-tachometer',
    route: 'dashboard',
    submenu: null
  },
  {
    text: 'Testing',
    icon: 'fa fa-pencil',
    route: 'test',
    submenu: null
  },
  /* {
    text: 'Contract Management',
    icon: 'fa fa-pencil',
    route: null,
    submenu: [
      {
          text: 'Dashboard',
          icon: '',
          route: 'hoteladmindashboard',
          submenu: null
      },
      {
        text: 'Contract',
        icon: '',
        route: 'createroomtype',
        submenu: null
    },
    {
      text: 'Clause Library',
      icon: '',
      route: 'createroomtype',
      submenu: null
    },
    {
      text: 'Templates',
      icon: '',
      route: 'createroomtype',
      submenu: null
    }
  ]
  },
  {
    text: 'Hotel Management',
    icon: 'fa fa-user',
    route: null,
    submenu: [
      {
        text: 'Dashboard',
        icon: '',
        route: '',
        submenu: null
    },
      {
          text: 'Hotel Profile',
          icon: '',
          route: '/hotelmgmt/hotels',
          submenu: null
      },
      {
        text: 'Reservation',
        icon: '',
        route: 'agentdashboard',
        submenu: null
    }
  ]
  },
  {
    text: 'Master Data',
    icon: 'fa fa-database',
    route: null,
    submenu: null
  },
  {
    text: 'Reports',
    icon: 'fa fa-file-text-o',
    route: null,
    submenu: null
  } */
];
