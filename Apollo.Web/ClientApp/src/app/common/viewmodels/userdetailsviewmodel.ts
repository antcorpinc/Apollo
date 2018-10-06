import { IMenuItem } from '../../framework/fw/services/menu.service';


export class FeaturePermissionViewModel {
  constructor() {
    this.subFeaturePermissionViewModel = new Array<FeaturePermissionViewModel>();
    this.submenu = new Array<IMenuItem>();
  }
   featureTypeId: number;
   typeName: string;
   label: string;
   parentFeatureId?: number;
   order?: number;
   privileges: string;
   icon: string;
   route: string;
   subFeaturePermissionViewModel: Array<FeaturePermissionViewModel>;
   submenu: Array<IMenuItem>;
  }

  export class ApplicationPermissionViewModel {
    constructor() {
      this.featurePermissions = new Map<number, FeaturePermissionViewModel>();
      this.featuresList = new Array<FeaturePermissionViewModel>();
    }
     name: string;
     role: string;
     roleUserType?: number;
     // Todo - May be we dont need the Map  as we are not using it.
     featurePermissions: Map<number, FeaturePermissionViewModel>;
     // ~ Todo - May be we dont need the Map.
     featuresList: Array<FeaturePermissionViewModel>;
    }

export class UserDetailsViewModel {
    constructor() {
      this.applicationPermissions = new Array<ApplicationPermissionViewModel>();
    }
    id: string;
    firstName: string;
    lastName: string;
    userType: number;
    profilePictureUri: string;
    disabled: boolean;
    userName: string;
    email: string;
    applicationPermissions: Array<ApplicationPermissionViewModel>;
}
