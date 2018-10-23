using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using Apollo.Service.UserManagement.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Service.UserManagement
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public List<Application> GetApplications()
        {
            return _applicationRepository.GetApplications();
        }
    }
}
