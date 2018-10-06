import { Injectable } from '@angular/core';

export interface IMenuItem {
  text: string;
  icon: string;
  route: string;
  submenu: Array<IMenuItem>;
}

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  items: Array<IMenuItem>;
  showingLeftSideMenu = false;
  appDrawer: any;

  constructor() { }

  toggleLeftSideMenu(): void {
     this.showingLeftSideMenu = !this.showingLeftSideMenu;
     this.toggleNav();
   }

  closeNav() {
    if (this.appDrawer !== undefined) {
    this.appDrawer.close();
    }
  }

  openNav() {
    this.showingLeftSideMenu = true;
    if (this.appDrawer !== undefined) {
    this.appDrawer.open();
    }
  }

  toggleNav() {
    if (this.appDrawer !== undefined) {
    this.appDrawer.toggle();
    }
  }
}
