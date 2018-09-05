using Apollo.Data;
using Apollo.Domain.Entity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Apollo.Sts.Configuration
{
    // Override the Profile Service to  get the custom claims for the User
    public class ApolloProfileService : IProfileService
    {
        private readonly ApolloContext _context;
        private readonly UserManager<ApolloUser> _userManager;

        public ApolloProfileService(UserManager<ApolloUser> userManager, ApolloContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.FindByIdAsync(context.Subject.GetSubjectId());
            // ToDO: Check if there is User returned before the below
            var userData = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            var claims = new Claim[]
             {
                 //Todo: Added claims -- In the below case we might not need since we already have userID
                  new Claim("username",userData.UserName)
             };
            context.IssuedClaims = claims.ToList();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
