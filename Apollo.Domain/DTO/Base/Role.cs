using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apollo.Domain.DTO.Base
{
    public class Role : BaseModelWithActive
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

     //public virtual List<Guid> ApplicationList { get; set; }

     //   public int UserType { get; set; }

      //  public ICollection<ApplicationRole> ApplicationRole { get; set; }
        /// <summary>
        /// FeatureTypeRolePrivilege
        /// </summary>
      //  public ICollection<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        /// <summary>
        /// UserAppRoleMapping
        /// </summary>
       //  public ICollection<UserAppRoleMapping> UserAppRoleMapping { get; set; }

      //  public string ConcurrencyStamp { get; set; }
        
      //  public string NormalizedName { get; set; }
    }
}