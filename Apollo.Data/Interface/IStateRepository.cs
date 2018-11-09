using Apollo.Core.Interface;
using Apollo.Domain.Entity.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Data.Interface
{
   public interface IStateRepository:  IRepository<State, int>
    {
    }
}
