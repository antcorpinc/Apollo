using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity.Society
{
    [Table("Flat", Schema = "Society")]
    public partial class Flat
    {
        public Flat()
        {

        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid SocietyId { get; set; }

        public Guid BuildingId { get; set; }

        [ForeignKey("SocietyId")]
        public Society Society { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }
    }
}
