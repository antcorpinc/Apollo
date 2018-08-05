using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("UserType", Schema = "Security")]
    public partial class UserType
    {
        public UserType()
        {
            Role = new HashSet<ApolloRole>();
            User = new HashSet<ApolloUser>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

 //       [InverseProperty("UserTypeNavigation")]
        public ICollection<ApolloRole> Role { get; set; }
 //       [InverseProperty("UserTypeNavigation")]
        public ICollection<ApolloUser> User { get; set; }
    }
}
