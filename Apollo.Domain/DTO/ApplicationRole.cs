using System;
using System.Collections.Generic;
using System.Text;
using Apollo.Domain.DTO.Base;

namespace Apollo.Domain.DTO
{
    public class ApplicationRole
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Application Application { get; set; }
             
        public Role Role { get; set; }
    }
}