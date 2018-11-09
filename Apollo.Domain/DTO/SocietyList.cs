using Apollo.Core.Interface;
using Apollo.Domain.DTO.Base;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
    public class SocietyList : BaseModelWithActive, IObjectWithState, IIdentifiableModel<Guid>
    {
        public Guid Id { get; set; }
        public ObjectState ObjectState { get; set; }
        public string Name { get; set; }

        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
