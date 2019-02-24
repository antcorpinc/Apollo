
import {ApplicationRoleIdViewModel} from './applicationroleidviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
import { SocietyUser } from './societyuser';
import { UserApplicationRoleViewModel } from './userapplicationroleviewmodel';

export class SocietyUserUpdateViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  userType: number;
  email: string;
  phoneNumber: string;
  isActive: boolean;
  createdBy: string;
  updatedBy: string;
  userApplicationRole: UserApplicationRoleViewModel;
}
