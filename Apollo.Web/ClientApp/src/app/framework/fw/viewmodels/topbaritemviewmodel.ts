export interface IAppRole {
  application: string;
  role: string;
}

export interface ITopBarItem {
  firstName: string;
  lastName: string;
  profilePictureUri: string;
  applications?: Array<IAppRole>;
  activeApplication?: string;
  activeRole?: string;
}
export class TopBarItemViewModel implements ITopBarItem {
  firstName: string;
  lastName: string;
  profilePictureUri: string;
  applications?: IAppRole[];
  activeApplication?: string;
  activeRole?: string;
}

