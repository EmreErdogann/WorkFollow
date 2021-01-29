using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFollow.Core.DTos;
using WorkFollow.Data.DataContext;
using WorkFollow.Data.Interfaces;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.Data.Implementaions
{
    public class EfUserRepository : EfRepository<User>, IUserRepository
    {
        private readonly WorkFollowDataContext _dbContext;
        public EfUserRepository(WorkFollowDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAdmın()
        {
            return _dbContext.Users.Join(_dbContext.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(_dbContext.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(ı => ı.roles.Name == "Member").Select(ı => new User()
            {
                Id = ı.user.Id,
                Name = ı.user.Name,
                SurName = ı.user.SurName,
                Picture=ı.user.Picture,
                Email=ı.user.Email,
                UserName=ı.user.UserName
            }).ToList();
        }
    }
}
