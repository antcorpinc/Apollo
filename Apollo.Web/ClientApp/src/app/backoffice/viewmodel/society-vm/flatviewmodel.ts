import { ObjectState } from 'src/app/common/enums';
import { IObjectWithState } from 'src/app/common/iobjectwithstate';

export class FlatViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  societyId: string;
  buildingId: string;
  isActive: boolean;
  name: string;
  createdBy: string;
  updatedBy: string;
}
