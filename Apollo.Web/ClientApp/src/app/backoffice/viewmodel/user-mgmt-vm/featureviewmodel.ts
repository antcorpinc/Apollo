export class FeatureViewModel {
  id: string;
  isActive: boolean;
  name: string;
  description: string;
  order: number;
  parentFeatureId: string;
  privileges: string;
  subFeature: FeatureViewModel[];
// featureTypeRolePrivilegeId: string;
  isExpanded: boolean;
}

export class BaseFeatureViewModel {
  id: number;
  name: string;
  description: string;
  order: number;
  parentFeatureId: string;
  isActive: boolean;
  createdBy: string;
  updatedBy: string;
  privileges: string;
  featureTypeRolePrivilegeId: string;
  featurePrivileges: string;
  viewAccess?: boolean;
  addAccess?: boolean;
  editAccess?: boolean;
  deleteAccess?: boolean;
  approveAccess?: boolean;
  isRequired?: boolean;
  fullAccess?: boolean;
}

export class FeatureVM extends BaseFeatureViewModel {
  subModule: FeatureVM[];
  isExpanded: boolean;
}

export class FeatureViewModelFlatNode extends BaseFeatureViewModel {
  expandable: boolean;
  level: number;
}



