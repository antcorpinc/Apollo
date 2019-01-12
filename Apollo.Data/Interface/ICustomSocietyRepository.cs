using Apollo.Domain.DTO.Society;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.Interface
{
    // Info : This interface is specifically for Custom search where its doesn't return entity ,
    // but directly mapped projected DTO so that it gets desired results.This is efficient bcos only
    // custom query get executed in select
    // Later get all the Select from ISocietyRepository to here - 
   public interface ICustomSocietyRepository
    {
        Task<List<SocietyListItem>> GetSocietiesWithCustomSearchAsync(string customSearch);
    }
}
