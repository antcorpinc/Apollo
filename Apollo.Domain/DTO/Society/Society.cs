using Apollo.Core.Interface;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class Society : BaseModelWithActive, IObjectWithState, IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public ObjectState ObjectState { get; set ; }

        public string Name { get; set; }
        public string Description { get; set; }        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }            
        public int StateId { get; set; }        
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string Landmark { get; set; }
        public string PinCode { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalPhoneNumber { get; set; }
        public Guid? ParentSocietyId { get; set; }       
        
    }

    public class SocietyValidator : AbstractValidator<Society>
    {
        public SocietyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.StateId).NotEmpty();
            RuleFor(x => x.CityId).NotEmpty();
            RuleFor(x => x.AreaId).NotEmpty();
        }
    }

    public class SocietyUpdateValidator : AbstractValidator<Society>
    {
        public SocietyUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.StateId).NotEmpty();
            RuleFor(x => x.CityId).NotEmpty();
            RuleFor(x => x.AreaId).NotEmpty();
        }
    }

}
