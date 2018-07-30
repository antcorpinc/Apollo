using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("UserAppRoleMapping", Schema = "Security")]
    public partial class UserAppRoleMapping
    {
        public int Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ApplicationId")]
        [InverseProperty("UserAppRoleMapping")]
        public Application Application { get; set; }
        [ForeignKey("RoleId")]
        [InverseProperty("UserAppRoleMapping")]
        public Role Role { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserAppRoleMapping")]
        public User User { get; set; }
    }
}
