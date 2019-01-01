using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class BuildingCreate : OptionalBaseModelWithActive, IObjectWithState
    {
        public ObjectState ObjectState { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class BuildingCreateValidator:  AbstractValidator<BuildingCreate>
    {
        public BuildingCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();

        }
    }
}
