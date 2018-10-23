using Apollo.Core.Interface;
using Apollo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Data.Interface
{
    public interface IApplicationRepository: IRepository<Application,Guid>
    {
         List<Application> GetApplications();
    }
}
