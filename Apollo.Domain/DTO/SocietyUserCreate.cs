using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
    public class SocietyUserCreate : Base.User
    {
        public SocietyUserCreate()
        {
            this.UserApplicationRole = new List<Base.UserApplicationRole>();
        }
        public ICollection<Base.UserApplicationRole> UserApplicationRole { get; set; }
        public Base.SocietyUser SocietyUser { get; set; }
    }

    public class SocietyUserCreateValidator : AbstractValidator<SocietyUserCreate>
    {
        // Todo: Add validations

    }
}
