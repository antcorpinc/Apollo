using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Apollo.Domain.DTO.User
{
   public class SocietyUserListItem: BaseUser
    {
        public SocietyUserListItem()
        {

        }
       public string SocietyName { get; set; }
        public string BuildingName { get; set; }
        public string FlatName { get; set; }

        //public static Expression<Func<Domain.Entity.ApolloUser, SocietyUserListItem>> Projection
        //{
        //    get
        //    {
        //        return x => new SocietyUserListItem()
        //        {
        //            Id = x.Id,
        //            FirstName = x.FirstName,
        //            LastName = x.LastName,
        //            IsActive = x.IsActive.Value,
        //            Email = x.Email,
        //            UserTypeId = x.UserTypeId,
        //            SocietyName = x.SocietyUser.Society.Name,
        //            BuildingName = x.SocietyUser.Building.Name,
        //            FlatName = x.SocietyUser.Flat.Name
        //        };
        //    }
        //}

        public static Expression<Func<Domain.Entity.SocietyUser, SocietyUserListItem>> Projection
        {
            get
            {
                return x => new SocietyUserListItem()
                {
                    Id = x.User.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    IsActive = x.User.IsActive.Value,
                    Email = x.User.Email,
                    UserTypeId = x.User.UserTypeId,
                    SocietyName = x.Society.Name,
                    BuildingName = x.Building.Name,
                    FlatName = x.Flat.Name
                };
            }
        }
    }
}
