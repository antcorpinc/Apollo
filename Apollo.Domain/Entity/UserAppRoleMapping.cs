using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("UserAppRoleMapping", Schema = "Security")]
    public partial class UserAppRoleMapping
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid? SocietyId { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public ObjectState? ObjectState { get; set; }


        [ForeignKey("ApplicationId")]
  
        public Application Application { get; set; }
        [ForeignKey("RoleId")]
  
        public ApolloRole Role { get; set; }
        [ForeignKey("UserId")]
  
        public ApolloUser User { get; set; }

        [ForeignKey("SocietyId")]

        public Society.Society Society { get; set; }

    }
}
