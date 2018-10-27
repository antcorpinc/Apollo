using System;
using System.Collections.Generic;
using System.Text;
using Apollo.Domain.DTO.Base;

namespace Apollo.Domain.DTO
{
    public partial class FeatureTypeRolePrivilege
    {
        public Guid Id { get; set; }
        public int FeatureId { get; set; }
        public string Privileges { get; set; }
        public Guid RoleId { get; set; }

        // Todo:This is optional since the Support User Roles can have access to all societies so null or
        // For BackOffice there is no society
        
      //  public Guid? SocietyId { get; set; }
       
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
       
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
       
        public Feature Feature { get; set; }
         
        public Role Role { get; set; }

       //public Society.Society Society  { get; set; }
    }
}