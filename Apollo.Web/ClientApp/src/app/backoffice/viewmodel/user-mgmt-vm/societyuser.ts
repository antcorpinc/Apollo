import { IObjectWithState } from 'src/app/common/iobjectwithstate';
import { ObjectState } from 'src/app/common/enums';

export class SocietyUser implements IObjectWithState {
  objectState: ObjectState;
  societyId: string;
  buildingId: string;
  flatId: string;
  roleId: string;
}
