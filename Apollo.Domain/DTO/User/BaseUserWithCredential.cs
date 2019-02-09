using Apollo.Core.Interface;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.User
{
    public class BaseUserWithCredential : BaseModelWithActive, IObjectWithState, IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int UserType { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ObjectState ObjectState  { get; set; }
    }
}
