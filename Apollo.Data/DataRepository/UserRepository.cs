using Apollo.Data.Interface;
using Apollo.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.DataRepository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ApolloContext _context;
        private readonly UserManager<ApolloUser> _userManager;
        public UserRepository(ApolloContext context, UserManager<ApolloUser> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager?? throw new ArgumentNullException(nameof(userManager)); ;
        }
        public Guid Add(ApolloUser newEntity)
        {
            throw new NotImplementedException();
        }
        public async Task<IdentityResult> Add(ApolloUser user, string password)
        {
            return await _userManager.CreateAsync(user, password).ConfigureAwait(false); ;
        }
        /*  public IQueryable<ApolloUser> Find(Expression<Func<ApolloUser, bool>> predicate)
         {
             return _context.User.Where(predicate);
         } */
        public List<ApolloUser> Find(Expression<Func<ApolloUser, bool>> predicate)
        {
            return _context.User.Where(predicate).ToList();
        }

        public async Task<List<ApolloUser>> FindAsync(Expression<Func<ApolloUser, bool>> predicate)
        {
            return await _context.User.Where(predicate).ToListAsync();
        }

        public List<ApolloUser> FindSupportUsers(Expression<Func<ApolloUser, bool>> predicate)
        {
          //  return this.Find(predicate).AsQueryable()
              return  _context.User.Where(predicate)
                        .Include(user => user.UserAppRoleMappings)
                         .ThenInclude(role => role.Application)
                         .ThenInclude(role => role.ApplicationRole)
                         .ThenInclude(role => role.Role).ToList();
        }
        public async Task<List<ApolloUser>> FindSupportUsersAsync(Expression<Func<ApolloUser, bool>> predicate)
        {  
            return await _context.User.Where(predicate)
                .Include(user => user.UserAppRoleMappings)
                         .ThenInclude(role => role.Application)
                         .ThenInclude(role => role.ApplicationRole)
                         .ThenInclude(role => role.Role).ToListAsync();
        }
        /*   public List<ApolloUser> GetSupportUsers()
          {
              return _context.User.Where(user => user.UserTypeId == 1)
                       .Include(userRole => userRole.UserAppRoleMappings)
                      .ToList();
          }
          public async Task<List<ApolloUser>> GetSupportUsersAsync()
          {
                 return await  _context.User.Where(user => user.UserTypeId == 1)
                       .Include(userRole => userRole.UserAppRoleMappings)
                      .ToListAsync();
          }
   */
        public ApolloUser Get(Guid id)
        {
            return _context.User.Where(users => users.Id == id)
                .Include(user => user.UserAppRoleMappings)
                .FirstOrDefault();
        }

        public async Task<ApolloUser> GetAsync(Guid id)
        {
            return await _context.User.Where(users => users.Id == id)
               .Include(user => user.UserAppRoleMappings)
               .ThenInclude(role => role.Application)
               .ThenInclude(role => role.ApplicationRole)
               .ThenInclude(role => role.Role)
               .FirstOrDefaultAsync();
        }
        public void Remove(ApolloUser entity)
        {
            throw new NotImplementedException();
        }
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        /* public ApolloUser Update(ApolloUser user)
        {
            _context.User.Attach(user);
            _context.ApplyStateChanges();
            
            try {
                _context.SaveChanges();
            }
           
            catch(Exception){

            }

            return user;
        } */
        public async Task<IdentityResult> Update(ApolloUser user)
        {
            return await _userManager.UpdateAsync(user).ConfigureAwait(false);
        }
        public async Task<ApolloUser> FindById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public IQueryable<ApolloUser> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<List<ApolloUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public Task<ApolloUser> AddAsync(ApolloUser newEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >=0 ;           
        }
    }
}
