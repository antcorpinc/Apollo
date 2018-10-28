import { IObjectWithState } from '../../../common/iobjectwithstate';
import { ObjectState } from '../../../common/enums';

export class ApplicationRoleIdViewModel implements IObjectWithState  {
  objectState: ObjectState;
  applicationId: string;
  roleId: string;
}
