using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("ApplicationRole", Schema = "Security")]
    public partial class ApplicationRole
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("ApplicationId")]
      
        public Application Application { get; set; }
        [ForeignKey("RoleId")]
     
        public ApolloRole Role { get; set; }
    }
}
