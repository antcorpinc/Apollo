using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO.User
{
   public  class SocietyUserCreate: BaseUserWithCredential
    {
        public SocietyUserCreate()
        {

        }
        public SocietyUser SocietyUser { get; set; }
    }
}
