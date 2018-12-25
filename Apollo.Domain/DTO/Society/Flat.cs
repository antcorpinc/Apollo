using Apollo.Core.Interface;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.Society
{
    public class Flat : BaseModelWithActive, IObjectWithState, IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public ObjectState ObjectState { get; set; }
        public string Name { get; set; }
        public Guid SocietyId { get; set; }

        public Guid BuildingId { get; set; }
    }
}
