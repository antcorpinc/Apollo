using System;
using System.Collections.Generic;
using System.Text;
using Apollo.Domain.DTO.Base;

namespace Apollo.Domain.DTO
{
    public partial class Feature {
     public int Id { get; set; }
     
        public string Description { get; set; }
        public int? Order { get; set; }
        public int? ParentFeatureId { get; set; }
        public string Name { get; set; }

        public bool? IsMenuRequired { get; set; }
        public bool? ViewAccess { get; set; }
        public bool? AddAccess { get; set; }
        public bool? EditAccess { get; set; }
        public bool? DeleteAccess { get; set; }
        public bool? ApproveAccess { get; set; }
        public bool? IsRequired { get; set; }
    }
}