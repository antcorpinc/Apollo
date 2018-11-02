import { AbstractControl } from '@angular/forms';
import { Utilities } from 'src/app/common/utilities/utilities';

export class UserMgmtSupportUserSyncValidators {
  // Validation to check the same application is not added again.
  static ApplicationRoleValidator = function (control: AbstractControl) {
    const appRoleList = control;
    if ((appRoleList.value !== undefined) && (appRoleList.value !== null) &&
      (appRoleList.value.length > 0)) {

      const appList = [];

      const appRoleArray = [];
      appRoleList.value.forEach(element => {
        appList.push(element.applicationId);
        appRoleArray.push({ applicationId: element.applicationId, roleId: element.roleId });
      });
      const sorterAppList = appList.sort();
      for (let i = 0; i < sorterAppList.length - 1; i++) {
        if (sorterAppList[i + 1] != null && sorterAppList[i] != null) {
          if (sorterAppList[i + 1] === sorterAppList[i]) {
              return { 'ValidateAppRole': true };
          }
        }
      }
      for (let i = 0; i < appRoleArray.length; i++) {
        if ( appRoleArray[i] != null) {
          if (appRoleArray[i].applicationId !== null &&  Utilities.isNullOrEmpty(appRoleArray[i].roleId) ) {
            return { 'ValidateAppRoleNotNull': true };
          }
        }
      }
    }
    return null;
  };
}
