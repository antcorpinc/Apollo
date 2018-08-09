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
        public Guid UserId { get; set; }

        [ForeignKey("RoleId")]
        public ApolloRole Role { get; set; }

        [ForeignKey("UserId")]
        public ApolloUser User { get; set; }

    }
}
