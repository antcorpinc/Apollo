import { ObjectState } from 'src/app/common/enums';
import { IObjectWithState } from 'src/app/common/iobjectwithstate';

export class BuildingViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  societyId: string;
  isActive: boolean;
  name: string;
  description: string;
  createdBy: string;
  updatedBy: string;
  createdDate?: Date;
}
