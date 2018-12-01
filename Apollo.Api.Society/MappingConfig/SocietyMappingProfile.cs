﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apollo.Api.Society.MappingConfig
{
    public class SocietyMappingProfile: Profile
    {
        public SocietyMappingProfile()
        {
            CreateMap<Domain.Entity.Society.Society, Apollo.Domain.DTO.SocietyList>()
                .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.Area, opt => opt.MapFrom(s => s.Area.Name))
                .ForMember(des => des.City, opt => opt.MapFrom(s => s.City.Name))
                .ForMember(des => des.State, opt => opt.MapFrom(s => s.State.Name))
                .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive));

            CreateMap<Domain.DTO.Society.Society, Apollo.Domain.Entity.Society.Society>()
                .ForMember(des => des.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.AreaId, opt => opt.MapFrom(s => s.AreaId))
                .ForMember(des => des.CityId, opt => opt.MapFrom(s => s.CityId))
                .ForMember(des => des.StateId, opt => opt.MapFrom(s => s.StateId))
                .ForMember(des => des.IsActive, opt => opt.MapFrom(s => s.IsActive))
                .ForMember(des => des.Landmark, opt => opt.MapFrom(s => s.Landmark))
                .ForMember(des => des.ObjectState, opt => opt.MapFrom(s => s.ObjectState))
                .ForMember(des => des.AddressLine1, opt => opt.MapFrom(s => s.AddressLine1))
                .ForMember(des => des.AddressLine2, opt => opt.MapFrom(s => s.AddressLine2))
                .ForMember(des => des.AdditionalPhoneNumber, opt => opt.MapFrom(s => s.AdditionalPhoneNumber))
                .ForMember(des => des.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(des => des.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                .ForMember(des => des.PinCode, opt => opt.MapFrom(s => s.PinCode))
                // Todo ?? Add updates & dates 
                .ReverseMap();
                


        }
    }
}
