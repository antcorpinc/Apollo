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
        public int FeatureId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }
        [ForeignKey("FeatureId")]
          public Feature Feature { get; set; }
    }
}
