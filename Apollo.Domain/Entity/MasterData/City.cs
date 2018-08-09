using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity.MasterData
{
    [Table("City", Schema = "MasterData")]
    public partial class City
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public int? StateId { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }
    }
}
