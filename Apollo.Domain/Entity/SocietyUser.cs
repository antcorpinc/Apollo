using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Apollo.Domain.Entity
{
    [Table("SocietyUser", Schema = "Security")]
    public partial class SocietyUser
    {
        public Guid Id { get; set; }
        public Guid SocietyId { get; set; }

        public Guid BuildingId { get; set; }
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }

        // Todo:Add other attributes like buiding and flat -- One username with 1 flat only - May be not ????

        [ForeignKey("SocietyId")]
        public Society.Society Society { get; set; }

        //[ForeignKey("BuildingId")]
        //public Society.Building Building { get; set; }

        // ToDO: Having Problem with adding the Society Id as Foreign Key
        // https://social.msdn.microsoft.com/Forums/en-US/25962df3-9400-49f3-b6da-29fba0a127b9/ef-core-introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths?forum=adodotnetentityframework
        // https://stackoverflow.com/questions/41711772/entity-framework-core-cascade-delete-one-to-many-relationship


        //[ForeignKey("FlatId")]
        //public Society.Flat Flat { get; set; }


        [ForeignKey("UserId")]
        public ApolloUser User { get; set; }

    }
}
