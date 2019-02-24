import { IObjectWithState } from 'src/app/common/iobjectwithstate';
import { ObjectState } from 'src/app/common/enums';

export class UserApplicationRoleViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  userId: string;
  applicationId: string;
  roleId: string;
}
