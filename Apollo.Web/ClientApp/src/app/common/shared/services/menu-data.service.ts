import { Injectable } from '@angular/core';
import { MenuService, IMenuItem } from '../../../framework/fw/services/menu.service';
import { UserDetailsViewModel, FeaturePermissionViewModel } from '../../viewmodels/userdetailsviewmodel';
import { TopBarService } from '../../../framework/fw/services/top-bar.service';
import { CONSTANTS } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class MenuDataService {
  _userDetails: UserDetailsViewModel;
  constructor(private menuService: MenuService, private topBarService: TopBarService) {
    this.topBarService.appChange$.subscribe((app) => this.transformMenuData(app));
  }

  initializeNonLoggedInMenus(menuItems: IMenuItem[]) {
    this.menuService.items = this.initializeMenuData(menuItems);
  }

  initializeLoggedInMenus(userDetails: UserDetailsViewModel) {
    this._userDetails = userDetails;
    if (userDetails.applicationPermissions.length > 0) {
      const app = this.topBarService.getTopBarItem().applications[0].application;
      this.transformMenuData(app);
    }
  }

  transformMenuData(app: string) {
    const appPermission = this._userDetails.applicationPermissions.find(x => x.name.trim().toUpperCase()
      === app.trim().toUpperCase());
    const featureListData: Array<FeaturePermissionViewModel> = appPermission.featuresList;
    let parentsMenuData: Array<FeaturePermissionViewModel> = new Array<FeaturePermissionViewModel>();
    if (featureListData != null && featureListData.length > 0) {
      // Top Level Menus
      parentsMenuData = featureListData.filter(val => val.parentFeatureId == null);
      parentsMenuData.forEach(parentMenuItem => {
        this.buildTreeviewMenu(parentMenuItem, featureListData);
      });
    }
    const translatedMenus = this.translateModelToMenusRecursively(parentsMenuData);
    console.log('TranslatedMenus' + JSON.stringify(translatedMenus));
    this.menuService.items = translatedMenus;

  }
  private translateModelToMenusRecursively(featurePermissionViewModel: Array<FeaturePermissionViewModel>) {
    const translatedMenus: IMenuItem[] = [];
    featurePermissionViewModel.forEach(element => {

      const tempMenuItem: IMenuItem = { icon: '', route: '', submenu: null, text: '' };
      tempMenuItem.icon = element.icon;
      tempMenuItem.route = element.route;
      tempMenuItem.text = element.label;

      if (element.subFeaturePermissionViewModel != null && element.subFeaturePermissionViewModel.length > 0) {
        tempMenuItem.submenu = this.translateModelToMenusRecursively(element.subFeaturePermissionViewModel);
      } else {
        tempMenuItem.submenu = null;
      }
      translatedMenus.push(tempMenuItem);
    });
    return translatedMenus;
  }

  private buildTreeviewMenu(parentMenuItem: FeaturePermissionViewModel,
    menuData: Array<FeaturePermissionViewModel>) {
    let menuItems: Array<FeaturePermissionViewModel>;
    // Get all child menu Items for the Parent
    menuItems = menuData.filter(menu => menu.parentFeatureId === parentMenuItem.featureTypeId);
    if (menuItems != null && menuItems.length > 0) {
      parentMenuItem.subFeaturePermissionViewModel = new Array<FeaturePermissionViewModel>();
      this.AddAdditionalMenuAttributes(parentMenuItem, true);
      menuItems.forEach((childMenu) => {
        parentMenuItem.subFeaturePermissionViewModel.push(childMenu);
        this.buildTreeviewMenu(childMenu, menuData);
      });
    }
    // tslint:disable-next-line:one-line
    else {
      this.AddAdditionalMenuAttributes(parentMenuItem, false);
    }
  }

  private AddAdditionalMenuAttributes(menuItem: FeaturePermissionViewModel, parent?: boolean):
    FeaturePermissionViewModel {
    if (menuItem != null) {
      menuItem.icon = this.getIconforMenuFeature(menuItem.typeName);
      if (parent === false) {
        menuItem.route = this.getRouteforMenuFeature(menuItem.typeName);
      } else {
        menuItem.route = null;
      }

    }
    return menuItem;
  }
  // Todo: Change This
  private getIconforMenuFeature(feature: string): string {
    if (feature.toUpperCase() === 'B2BHOTELS') {
      return 'person';
    } else if (feature.toUpperCase() === 'UNBEATABLEDEALS') {
      return 'person';
    } else if (feature.toUpperCase() === 'VIEWBOOKINGS') {
      return 'person';
    } else {
      return null;
    }
  }

  private getRouteforMenuFeature(feature: string): string {
    if (feature.toUpperCase() === CONSTANTS.feature.backoffice.dashboard.toUpperCase()) {
      return 'auth/backofficedashboard';
    } else if (feature.toUpperCase() === CONSTANTS.feature.backoffice.supportuser.toUpperCase()) {
      return 'auth/bo/usermgmt/supportusers';
    } else if (feature.toUpperCase() === CONSTANTS.feature.backoffice.societyprofile.toLocaleUpperCase()) {
      return 'auth/bo/societymgmt/societies';
    } else if (feature.toUpperCase() === CONSTANTS.feature.backoffice.societyUser.toUpperCase()) {
      return 'auth/bo/usermgmt/societyusers';
    } else {
      return null;
    }
  }

  private initializeMenuData(menuItems: Array<IMenuItem>) {
    const translatedMenus: Array<IMenuItem> = new Array<IMenuItem>();
    menuItems.forEach(item => {
      const tempMenuItem: IMenuItem = { icon: '', route: '', submenu: null, text: '' };
      tempMenuItem.icon = item.icon;
      tempMenuItem.route = item.route;
      tempMenuItem.text = item.text;
      if (item.submenu !== null) {
        tempMenuItem.submenu = this.initializeMenuData(item.submenu);
      } else {
        tempMenuItem.submenu = null;
      }
      translatedMenus.push(tempMenuItem);
    });
    return translatedMenus;
  }
}
