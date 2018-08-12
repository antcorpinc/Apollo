using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
   public class FeaturePermission
    {
        public int FeatureTypeId { get; set; }
        public string TypeName { get; set; }
        public string Label { get; set; }
        public int? ParentFeatureId { get; set; }
        public int? Order { get; set; }
        public string Privileges { get; set; }

    }
}
