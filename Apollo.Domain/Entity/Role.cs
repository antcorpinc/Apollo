using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("Role", Schema = "Security")]
    public partial class Role : IdentityRole<Guid>
    {
        public Role()
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
        [InverseProperty("Role")]
        public UserType UserTypeNavigation { get; set; }
        [InverseProperty("Role")]
        public ICollection<ApplicationRole> ApplicationRole { get; set; }
              
        [InverseProperty("Role")]
        public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        [InverseProperty("Role")]
        public ICollection<UserAppRoleMapping> UserAppRoleMapping { get; set; }
    }
}
