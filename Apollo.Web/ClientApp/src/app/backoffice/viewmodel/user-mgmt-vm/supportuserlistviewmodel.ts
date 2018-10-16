import { ApplicationRoleViewModel } from './applicationroleviewmodel';

export class SupportUserListViewModel {
  id: string;
  firstName: string;
  lastName: string;
  fullName: string;
  userName: string;
  email: string;
  isActive: boolean;
  userApplicationRole: ApplicationRoleViewModel[];
}
