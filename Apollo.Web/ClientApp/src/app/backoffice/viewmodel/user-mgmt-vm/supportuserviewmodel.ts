
import {ApplicationRoleIdViewModel} from './applicationroleidviewmodel';
import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class SupportUserViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  phoneNumber: string;
  userApplicationRole: ApplicationRoleIdViewModel[];
  createdBy: string;
  updatedBy: string;
}
