using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("FeatureTypeRolePrivilege", Schema = "Security")]
    public partial class FeatureTypeRolePrivilege
    {
        public Guid Id { get; set; }
        public int FeatureTypeId { get; set; }
        public string Privileges { get; set; }
        public Guid RoleId { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
       
        [ForeignKey("FeatureTypeId")]
  //      [InverseProperty("FeatureTypeRolePrivilege")]
        public Feature FeatureType { get; set; }
        [ForeignKey("RoleId")]
  //      [InverseProperty("FeatureTypeRolePrivilege")]
        public ApolloRole Role { get; set; }
    }
}
