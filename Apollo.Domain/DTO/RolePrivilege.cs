using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
   public class RolePrivilege
    {
        public int FeatureTypeId { get; set; }
        public string FeatureTypeName { get; set; }
        public string FeatureLabel { get; set; }
        public int? ParentFeatureId { get; set; }
        public int? Order { get; set; }
        public string Privileges { get; set; }
        public string RoleName { get; set; }

        public string ApplicationName { get; set; }
    }
}
