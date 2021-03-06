﻿using Apollo.Core.Interface;
using Apollo.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity
{
    public partial class ApolloUser : IdentityUser<Guid>, IIdentifiableModel<Guid>, IObjectWithState
    {
        public ApolloUser()
        {
            UserAppRoleMappings = new HashSet<UserAppRoleMapping>();

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int UserTypeId { get; set; }
         [StringLength(256)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(256)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        [StringLength(256)]
        public string PhotoUrl { get; set; }        
       
        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [ForeignKey("UserTypeId")]
        public UserType UserType { get; set; }
        public ICollection<UserAppRoleMapping> UserAppRoleMappings { get; set; }

        public SocietyUser SocietyUser { get; set; }
    }
}
