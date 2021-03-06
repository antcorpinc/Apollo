﻿using Apollo.Core.Interface;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class Building : BaseModelWithActive, IObjectWithState, IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public ObjectState ObjectState { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid SocietyId { get; set; }

       
    }
}
