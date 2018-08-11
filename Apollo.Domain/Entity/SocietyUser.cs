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

        [ForeignKey("BuildingId")]
        public Society.Building Building { get; set; }

        [ForeignKey("FlatId")]
        public Society.Flat Flat { get; set; }


        [ForeignKey("UserId")]
        public ApolloUser User { get; set; }

    }
}
