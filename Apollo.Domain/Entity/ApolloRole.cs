using Apollo.Core.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity
{
    public class ApolloRole : IdentityRole<Guid>, IIdentifiableModel<Guid>
    {
        public ApolloRole()
        {
            ApplicationRole = new HashSet<ApplicationRole>();
            FeatureTypeRolePrivilege = new HashSet<FeatureTypeRolePrivilege>();
            UserAppRoleMapping = new HashSet<UserAppRoleMapping>();
        }


        public int? UserType { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Description { get; set; }

        [ForeignKey("UserType")]
   //     [InverseProperty("ApolloRole")]
        public UserType UserTypeNavigation { get; set; }
     //   [InverseProperty("ApolloRole")]
        public ICollection<ApplicationRole> ApplicationRole { get; set; }

    //    [InverseProperty("ApolloRole")]
        public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
    //    [InverseProperty("ApolloRole")]
        public ICollection<UserAppRoleMapping> UserAppRoleMapping { get; set; }
    }
}
