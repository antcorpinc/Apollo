﻿using Apollo.Core.Interface;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Base
{
    public class SocietyUser: IObjectWithState, IIdentifiableModel<Guid>
    {
        public SocietyUser()
        {

        }
        public Guid Id { get; set; }
        public Guid SocietyId { get; set; }

        public Guid BuildingId { get; set; }
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }

        public ObjectState ObjectState { get; set; }
    }
}
