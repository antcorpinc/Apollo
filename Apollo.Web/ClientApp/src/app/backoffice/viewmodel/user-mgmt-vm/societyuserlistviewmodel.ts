import { ApplicationRoleViewModel } from './applicationroleviewmodel';

export class SocietyUserListViewModel {
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  email: string;
  isActive: boolean;
  societyName: string;
  buildingName: string;
  flatName: string;
  userApplicationRole: ApplicationRoleViewModel[];
}
