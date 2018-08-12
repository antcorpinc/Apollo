using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
   public class ApplicationPermission
    {
        public ApplicationPermission()
        {
            FeaturesList = new List<FeaturePermission>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }
        public Guid RoleId { get; set; }
        public List<FeaturePermission> FeaturesList { get; set; }

        public int? RoleUserType { get; set; }
    }
}
