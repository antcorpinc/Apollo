using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo.Core.Common
{
   public class ServiceResponse
    {
        public List<ValidationFailure> ErrorMessages { get; set; }
        public bool Successful => !ErrorMessages.Any();

        public ServiceResponse()
        {
            ErrorMessages = new List<ValidationFailure>();
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }

        public ServiceResponse<object> ToObject()
        {
            return new ServiceResponse<object>()
            {
                Data = Data,
                ErrorMessages = ErrorMessages
            };
        }
    }

    public class CreatedServiceResponse<T>: ServiceResponse<T>
    {
        public Guid Id { get; set; }

        public new CreatedServiceResponse<object> ToObject()
        {
            return new CreatedServiceResponse<object>()
            {
                Id = Id,
                Data = Data,
                ErrorMessages = ErrorMessages
            };
        }
    }
}
