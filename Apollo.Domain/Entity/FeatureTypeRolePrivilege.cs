﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("FeatureTypeRolePrivilege", Schema = "Security")]
    public partial class FeatureTypeRolePrivilege
    {
        public Guid Id { get; set; }
        public int FeatureId { get; set; }
        public string Privileges { get; set; }
        public Guid RoleId { get; set; }

        // This is optional since the Support User Roles can have access to all societies so null or
        // For BackOffice there is no society
        
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
       
        [ForeignKey("FeatureId")]
         public Feature Feature { get; set; }
        [ForeignKey("RoleId")]
  
        public ApolloRole Role { get; set; }

        [ForeignKey("SocietyId")]

        public Society.Society Society  { get; set; }
    }
}
