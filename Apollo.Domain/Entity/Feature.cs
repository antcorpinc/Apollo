using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("Feature", Schema = "Security")]
    public partial class Feature
    {
        public Feature()
        {
            ApplicationFeature = new HashSet<ApplicationFeature>();
            FeatureTypeRolePrivilege = new HashSet<FeatureTypeRolePrivilege>();
            InverseParentFeature = new HashSet<Feature>();
        }

        public int Id { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int? Order { get; set; }
        public int? ParentFeatureId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ParentFeatureId")]
 
        public Feature ParentFeature { get; set; }
 
        public ICollection<ApplicationFeature> ApplicationFeature { get; set; }
 
        public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
 
        public ICollection<Feature> InverseParentFeature { get; set; }
    }
}
