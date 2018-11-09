using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Service.UserManagement.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Apollo.Service.UserManagement
{
    public class SocietyService : ISocietyService
    {
        private ISocietyRepository _societyRepository;
        public SocietyService(ISocietyRepository societyRepository)
        {
            _societyRepository = societyRepository;
        }
        public List<SocietyList> GetAll()
        {
            var societies =  this._societyRepository.GetAll();
            if(societies != null && societies.Count() > 0)
            {
                return AutoMapper.Mapper.Map<IEnumerable<SocietyList>>(societies).ToList();
            }
            else
            {
                return null;
            }
            
        }
    }
}
