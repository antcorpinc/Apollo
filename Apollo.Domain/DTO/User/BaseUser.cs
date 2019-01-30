using Apollo.Core.Interface;
using Apollo.Domain.DTO.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.User
{
   public  class BaseUser: BaseModelWithActive, IIdentifiableModel<Guid>
    {
        public BaseUser()
        {

        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
