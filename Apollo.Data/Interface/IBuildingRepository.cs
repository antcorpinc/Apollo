using Apollo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Apollo.Domain.Entity.Society;
namespace Apollo.Data.Interface
{
    public interface IBuildingRepository: IRepository<Building, Guid> 
    {
    }
}
