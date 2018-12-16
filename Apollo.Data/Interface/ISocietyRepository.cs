using Apollo.Core.Interface;
using Apollo.Domain.Entity.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    public interface ISocietyRepository: IRepository<Society, Guid> 
    {
         Task<Society> GetAsync(Guid id);
        
    }
}
