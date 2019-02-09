using Apollo.Core.Common;
using Apollo.Data.Interface;
using Apollo.Domain.DTO.User;
using Apollo.Domain.Entity;
using Apollo.Service.UserManagement.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationRepository _applicationRepository;
        private ICustomApplicationRepository _customApplicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository,
            ICustomApplicationRepository customApplicationRepository)
        {
            _applicationRepository = applicationRepository;
            _customApplicationRepository = customApplicationRepository;
        }

        public Task<ServiceResponse<ApplicationListItem>> GetApplicationDetails(string applicationName)
        {
            throw new NotImplementedException();
        }

        public List<Application> GetApplications()
        {
            return _applicationRepository.GetApplications();
        }
    }
}
