using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity.Form
{
    [Table("FormType", Schema = "Form")]
    public partial class FormType
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
