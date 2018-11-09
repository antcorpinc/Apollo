using Apollo.Core.Interface;
using Apollo.Domain.Entity.MasterData;
using Apollo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity.Society
{
    [Table("Society", Schema = "Society")]
    public partial class Society:  IIdentifiableModel<Guid>, IObjectWithState
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
        public string Landmark {get;set;}
        
        [Required]
        public string PinCode { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalPhoneNumber { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
         public bool? IsActive { get; set; }

        public Guid? ParentSocietyId { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(128)]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


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
