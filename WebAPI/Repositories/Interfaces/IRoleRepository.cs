using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(int roleId);
        Task<bool> IsRoleNameExist(string roleName);
        Task<Role> GetRoleByRoleNameAsync(string roleName);
        void CreateRole(Role role);
        void UpdateRole(Role role);
    }
}
