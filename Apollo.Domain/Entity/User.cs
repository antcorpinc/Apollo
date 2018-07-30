using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("User", Schema = "Security")]
    public partial class User : IdentityUser<Guid>
    {
        public User()
        {
            UserAppRoleMapping = new HashSet<UserAppRoleMapping>();
           
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int UserType { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(256)]
        
        public bool? IsActive { get; set; }
        [StringLength(256)]
        public string PhotoUrl { get; set; }
        [StringLength(256)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
       
       
        [ForeignKey("UserType")]
        [InverseProperty("User")]
        public UserType UserTypeNavigation { get; set; }
       
             
        [InverseProperty("User")]
        public ICollection<UserAppRoleMapping> UserAppRoleMapping { get; set; }
       
    }
}
