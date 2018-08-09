using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity
{
    [Table("SocietyRole", Schema = "Security")]
    public partial class SocietyRole
    {
        public Guid Id { get; set; }
        public Guid SocietyId { get; set; }
        public Guid RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("RoleId")]
        public ApolloRole Role { get; set; }

        [ForeignKey("SocietyId")]
        public Society.Society Society { get; set; }

    }
}
