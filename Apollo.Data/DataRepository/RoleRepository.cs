using Apollo.Data.Interface;
using Apollo.Domain.DTO;
using Apollo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
            throw new NotImplementedException();
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
    }
}
