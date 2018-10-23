using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.DTO
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
