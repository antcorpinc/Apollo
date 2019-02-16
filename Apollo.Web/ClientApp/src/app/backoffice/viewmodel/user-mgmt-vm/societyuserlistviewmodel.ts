import { ApplicationRoleViewModel } from './applicationroleviewmodel';

export class SocietyUserListViewModel {
  id: string;
  firstName: string;
  lastName: string;
  userId: string;
  userName: string;
  email: string;
  isActive: boolean;
  societyId: string;
  societyName: string;
  buildingId: string;
  buildingName: string;
  flatId: string;
  flatName: string;
  userApplicationRole: ApplicationRoleViewModel[];
}
