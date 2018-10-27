using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.Entity;
using Apollo.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ApplicationRole = Apollo.Domain.Entity.ApplicationRole;

namespace Apollo.Data.DataRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApolloContext _context;
        public RoleRepository(ApolloContext context)
        {
            _context = context;
        }
        public Guid Add(ApolloRole newEntity)
        {
           
            throw new NotImplementedException();
        }

        public IQueryable<ApolloRole> Find(Expression<Func<ApolloRole, bool>> predicate)
        {
            return _context.Role.Where(predicate);
        }

        public ApolloRole Get(Guid id)
        {
            return _context.Roles.Include(role => role.FeatureTypeRolePrivilege)
               .Where(role => role.Id == id).FirstOrDefault();
        }

        public List<RolePrivilege> GetRelatedPrivilegesForRoleAndApp(Guid roleId, Guid appId)
        {
            List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();
            var role = _context.Roles.Where(r => r.Id == roleId).FirstOrDefault();

            rolePrivileges = _context.Entry(role).Collection(r => r.FeatureTypeRolePrivilege).Query()
                .Join(_context.ApplicationFeature, ftp => ftp.FeatureId, ap => ap.FeatureId, (r, ftp) => new { r, ftp })
                .Where(a => a.ftp.ApplicationId == appId)
                
                .Select(m => new RolePrivilege
                {
                    FeatureTypeId = m.ftp.FeatureId,
                    Privileges = m.r.Privileges,
                    RoleName = m.r.Role.Name,
                    FeatureTypeName = m.ftp.Feature.Name,
                    FeatureLabel = m.ftp.Feature.Description,
                    ParentFeatureId = m.ftp.Feature.ParentFeatureId,
                    Order = m.ftp.Feature.Order,
                    ApplicationName = m.ftp.Application.Name
                }).OrderBy(rp => rp.ParentFeatureId).ThenBy(p => p.Order).ToList();
            return rolePrivileges;
        }

        public List<RolePrivilege> GetRelatedPrivilegesForRoleAppAndSociety(Guid roleId, Guid appId, Guid? societyId)
        {
            List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();
            var role = _context.Roles.Where(r => r.Id == roleId).FirstOrDefault();

            rolePrivileges = _context.Entry(role).Collection(r => r.FeatureTypeRolePrivilege).Query()
                .Join(_context.ApplicationFeature, ftp => ftp.FeatureId, ap => ap.FeatureId, (r, ftp) => new { r, ftp })
                .Where(a => (a.ftp.ApplicationId == appId) &&  (a.r.SocietyId == societyId))

                .Select(m => new RolePrivilege
                {
                    FeatureTypeId = m.ftp.FeatureId,
                    Privileges = m.r.Privileges,
                    RoleName = m.r.Role.Name,
                    FeatureTypeName = m.ftp.Feature.Name,
                    FeatureLabel = m.ftp.Feature.Description,
                    ParentFeatureId = m.ftp.Feature.ParentFeatureId,
                    Order = m.ftp.Feature.Order,
                    ApplicationName = m.ftp.Application.Name
                }).OrderBy(rp => rp.ParentFeatureId).ThenBy(p => p.Order).ToList();
            return rolePrivileges;
        }

       /*  List<ApplicationRole> GetRolesForApplicationAndUserType(Guid applicationId ,Apollo.Domain.Enum.UserType? userType){
            var roles = _context.ApplicationRole.Where(a => a.ApplicationId == applicationId && a.IsActive == true)
                                 .Include(r => r.Application)
                                 .Include(r => r.Role).ToList();
            if((int)userType > 0){
                roles = roles.Where(r => r.Role.UserTypeId == (int)userType).ToList(); 
            }

            return roles;
        } */

        public void Remove(ApolloRole entity)
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

        List<ApplicationRole> IRoleRepository.GetRolesForApplicationAndUserType(Guid applicationId, Domain.Enum.UserType? userType)
        {
            var roles = _context.ApplicationRole.Where(a => a.ApplicationId == applicationId && a.IsActive == true)
                                 .Include(r => r.Application)
                                 .Include(r => r.Role).ToList();
            if((int)userType > 0){
                roles = roles.Where(r => r.Role.UserTypeId == (int)userType).ToList(); 
            }

            return roles;
        }
    }
}
