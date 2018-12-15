import { ObjectState } from 'src/app/common/enums';
import { IObjectWithState } from 'src/app/common/iobjectwithstate';

export class SocietyViewModel implements IObjectWithState {
  objectState: ObjectState;
  id: string;
  isActive: boolean;
  name: string;
  description: string;
  addressLine1: string;
  addressLine2: string;
  landmark: string;
  stateId: number;
  cityId: number;
  areaId: number;
  pinCode: string;
  phoneNumber: string;
  additionalPhoneNumber: string;
  createdBy: string;
  updatedBy: string;
}
