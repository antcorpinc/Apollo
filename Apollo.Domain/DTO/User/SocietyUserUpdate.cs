using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.User
{
   public class SocietyUserUpdate : OptionalBaseModelWithActive
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int UserType { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ObjectState ObjectState { get; set; }
        //   public SocietyUser SocietyUser { get; set; }
        public UserApplicationRole UserApplicationRole { get; set; }

        public SocietyUserUpdate()
        {

        }
    }
    public class SocietyUserUpdateValidator : AbstractValidator<SocietyUserUpdate>
    {

    }
}
