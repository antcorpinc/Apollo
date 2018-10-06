import { IMenuItem } from './framework/fw/services/menu.service';

export let initialMenuItems: Array<IMenuItem> = [
  {
    text: 'Dashboard',
    icon: 'person',
    route: 'dashboard',
    submenu: null
  },
  {
    text: 'Testing',
    icon: 'person',
    route: 'test',
    submenu: null
  },
  {
    text: 'About',
    icon: 'person',
    route: 'test',
    submenu: [
      {
        text: 'Test2',
        icon: 'person',
        route: 'hoteladmindashboard',
        submenu: [
          {
            text: 'Test2-1',
            icon: 'person',
            route: 'hoteladmindashboard',
            submenu: null
          },
          {
            text: 'Test2-2',
            icon: 'person',
            route: 'hoteladmindashboard',
            submenu: null
          }
        ]
      },
      {
        text: 'Test3',
        icon: 'person',
        route: 'hoteladmindashboard',
        submenu: null
      }
    ]
  },
];


// *** The number of elements here should be the same as that in the initial menus in initialMenuItems
// Otherwise it gives the.
export let defaultMenuItems: Array<IMenuItem> = [
  {
    text: '',
    icon: '',
    route: '',
    submenu: null
  },
  {
    text: '',
    icon: '',
    route: '',
    submenu: null
  },
  {
    text: '',
    icon: '',
    route: '',
    submenu: null
  }
];

