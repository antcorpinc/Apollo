using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Service.SocietyManagement.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Apollo.Service.SocietyManagement.Mappers;

namespace Apollo.Service.SocietyManagement
{
    public class SocietyService : ISocietyService
    {
        private ISocietyRepository _societyRepository;
        public SocietyService(ISocietyRepository societyRepository)
        {
            _societyRepository = societyRepository ??
                throw new ArgumentNullException(nameof(societyRepository)); ;
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
        public async Task<List<SocietyList>> GetAllAsync()
        {
            var societies = await this._societyRepository.GetAllAsync();
            return SocietyMapper.MapToSociety(societies);
        }
    }
}
