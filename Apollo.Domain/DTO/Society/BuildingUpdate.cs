using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class BuildingUpdate : OptionalBaseModelWithActive, IObjectWithState
    {
        public ObjectState ObjectState { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }     

    }

    public class BuildingUpdateValidator : AbstractValidator<BuildingUpdate>
    {
        public BuildingUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
            RuleFor(x => x.CreatedDate).NotEmpty();
        }
    }

}
