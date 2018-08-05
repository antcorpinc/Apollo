﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apollo.Domain.Entity
{
    [Table("Application", Schema = "Security")]
    public partial class Application
    {
        public Application()
        {
            ApplicationFeature = new HashSet<ApplicationFeature>();
            ApplicationRole = new HashSet<ApplicationRole>();
            UserAppRoleMapping = new HashSet<UserAppRoleMapping>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

  //      [InverseProperty("Application")]
        public ICollection<ApplicationFeature> ApplicationFeature { get; set; }
  //      [InverseProperty("Application")]
        public ICollection<ApplicationRole> ApplicationRole { get; set; }
  //      [InverseProperty("Application")]
        public ICollection<UserAppRoleMapping> UserAppRoleMapping { get; set; }
    }
}
