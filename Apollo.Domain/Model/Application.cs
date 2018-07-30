using Apollo.Core.Interface;
using Apollo.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apollo.Domain.Model
{
   public  class Application : BaseModelWithActive, IIdentifiableModel<Guid>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
   
      
    }
}
