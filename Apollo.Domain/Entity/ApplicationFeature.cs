using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("ApplicationFeature", Schema = "Security")]
    public partial class ApplicationFeature
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public int FeatureTypeId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ApplicationId")]
  //      [InverseProperty("ApplicationFeature")]
        public Application Application { get; set; }
        [ForeignKey("FeatureTypeId")]
  //      [InverseProperty("ApplicationFeature")]
        public Feature FeatureType { get; set; }
    }
}
