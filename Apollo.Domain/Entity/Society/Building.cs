using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Apollo.Core.Interface;
using Apollo.Domain.Enum;

namespace Apollo.Domain.Entity.Society
{
    [Table("Building", Schema = "Society")]
    public partial class Building:  IIdentifiableModel<Guid>, IObjectWithState
    {
        public Building()
        {
            Flats = new HashSet<Flat>();
            SocietyUsers = new HashSet<SocietyUser>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid SocietyId { get; set; }

        public bool? IsActive { get; set; }
        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


        [NotMapped]
        public ObjectState ObjectState { get; set; }


        [ForeignKey("SocietyId")]
        public Society Society { get; set; }

        public ICollection<Flat> Flats { get; set; }

        public ICollection<SocietyUser> SocietyUsers { get; set; }

    }
}
