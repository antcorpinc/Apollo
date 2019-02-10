
import {ApplicationRoleIdViewModel} from './applicationroleidviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
import { SocietyUser } from './societyuser';

export class SocietyUserViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  userType: number;
  email: string;
  phoneNumber: string;
  isActive: boolean;
  societyId: string;
  buildingId: string;
  flatId: string;
  createdBy: string;
  updatedBy: string;
  societyUser: SocietyUser;

}
