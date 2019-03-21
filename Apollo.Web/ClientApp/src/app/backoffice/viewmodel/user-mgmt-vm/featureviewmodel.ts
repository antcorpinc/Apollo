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
