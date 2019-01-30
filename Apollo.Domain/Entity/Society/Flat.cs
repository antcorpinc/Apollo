using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Apollo.Core.Interface;
using Apollo.Domain.Enum;

namespace Apollo.Domain.Entity.Society
{
    [Table("Flat", Schema = "Society")]
    public partial class Flat : IIdentifiableModel<Guid>, IObjectWithState
    {
        public Flat()
        {

        }
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid SocietyId { get; set; }

        public Guid BuildingId { get; set; }

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


        // ToDO: Having Problem with adding the Society Id as Foreign Key
        // https://social.msdn.microsoft.com/Forums/en-US/25962df3-9400-49f3-b6da-29fba0a127b9/ef-core-introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths?forum=adodotnetentityframework
        // https://stackoverflow.com/questions/41711772/entity-framework-core-cascade-delete-one-to-many-relationship

        //[ForeignKey("SocietyId")]
        //public Society Society { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        public SocietyUser SocietyUser { get; set; }

    }
}
