using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories.Repos
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(SchoolContext context) : base(context) { }

        public void CreateRole(Role role)
        {
            Create(role);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await FindByCondition(role => role.Id == roleId).FirstOrDefaultAsync();
        }

        public async Task<Role> GetRoleByRoleNameAsync(string roleName)
        {
            return await FindByCondition(role => role.RoleName == roleName).FirstOrDefaultAsync();
        }

        public async Task<bool> IsRoleNameExist(string roleName)
        {
            return await FindByCondition(role => role.RoleName == roleName).AnyAsync();
        }

        public void UpdateRole(Role role)
        {
            Update(role);
        }
    }
}
