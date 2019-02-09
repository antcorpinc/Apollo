using Apollo.Core.Common;
using Apollo.Domain.DTO.User;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Service.UserManagement.Interface
{
    public interface IApplicationService
    {
        List<Application> GetApplications();
        Task<ServiceResponse<ApplicationListItem>> GetApplicationDetails(string applicationName);
    }
}
