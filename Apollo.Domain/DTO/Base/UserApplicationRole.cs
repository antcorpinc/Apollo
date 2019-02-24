using Apollo.Core.Interface;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Base
{
    public class UserApplicationRole : IObjectWithState //, IIdentifiableModel<Guid>
    {
        public Guid? Id { get; set;  }
        public Guid? UserId { get; set; }
        public Guid? SocietyId { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        public ObjectState ObjectState { get; set; }
        
    }
}
