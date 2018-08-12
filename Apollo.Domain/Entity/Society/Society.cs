using Apollo.Domain.Entity.MasterData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity.Society
{
    [Table("Society", Schema = "Society")]
    public partial class Society
    {
        public Society()
        {
            Buildings = new HashSet<Building>();
            SocietyUsers = new HashSet<SocietyUser>();
        }
        public Guid Id { get; set; }
       
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required]
        public int StateId { get; set; }
        [Required]
        public int CityId { get; set; }

        public int AreaId{ get; set; }
        
        [Required]
        public string PinCode { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalPhoneNumber { get; set; }

        public Guid? ParentSocietyId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        [ForeignKey("ParentSocietyId")]
         public Society ParentSociety { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public ICollection<SocietyUser> SocietyUsers { get; set; }

    }
}
