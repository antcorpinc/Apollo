
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';
import { SocietyUser } from './societyuser';
import { ApplicationRoleViewModel } from './applicationroleviewmodel';

export class SocietyUserGetViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  firstName: string;
  lastName: string;
  userId: string;
  userName: string;
  userType: number;
  email: string;
  phoneNumber: string;
  isActive: boolean;
  societyId: string;
  societyName: string;
  buildingId: string;
  buildingName: string;
  flatId: string;
  flatName: string;
  createdBy: string;
  updatedBy: string;
  userAppRoles: ApplicationRoleViewModel[];

}
