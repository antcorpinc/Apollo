using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity.Society
{
    [Table("Building", Schema = "Society")]
    public partial class Building
    {
        public Building()
        {
            Flats = new HashSet<Flat>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid SocietyId { get; set; }


        [ForeignKey("SocietyId")]
        public Society Society { get; set; }

        public ICollection<Flat> Flats { get; set; }
    }
}
