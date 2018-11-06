using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Base
{
    public class UserApplicationRole : IObjectWithState
    {
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        public ObjectState ObjectState { get; set; }
    }
}
