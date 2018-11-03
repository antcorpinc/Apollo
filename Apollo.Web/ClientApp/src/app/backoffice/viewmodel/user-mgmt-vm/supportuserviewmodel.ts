
import {ApplicationRoleIdViewModel} from './applicationroleidviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class SupportUserViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  userType: number;
  email: string;
  phoneNumber: string;
  isActive: boolean;
  userApplicationRole: ApplicationRoleIdViewModel[];
  createdBy: string;
  updatedBy: string;
}
