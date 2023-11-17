using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taro.Core.Dtos.RoleDtos;
using Taro.Core.Entities.Roles;
using Taro.Core.Interfaces;

namespace Taro.Services.Implementation
{
    public class RoleServices : IRoleServices
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleServices(RoleManager<Role> roleManager, IMapper mapper)
        {

            _roleManager = roleManager;
            _mapper = mapper;

        }
        public async Task SeedRolesAsync()
        {
            if (await _roleManager.Roles.AnyAsync())
            {
                return;
            }

            var roles = new List<RoleAddModel>()
            {
                new RoleAddModel{ Name = "Admin" },
                new RoleAddModel{ Name = "Student" },
                new RoleAddModel{ Name = "Instructor" },
            };

            await AddSeedRoles(roles);
        }

        private async Task AddSeedRoles(List<RoleAddModel> roles)
        {
            foreach (var roleToAdd in roles)
            {
                var roleCheck = await _roleManager.FindByNameAsync(roleToAdd.Name);

                if (roleCheck != null)
                {
                    continue;
                }

                var role = _mapper.Map<Role>(roleToAdd);

                role.CreatedBy = "System";
                role.CreatedAt = DateTime.UtcNow;

                await _roleManager.CreateAsync(role);
            }
        }
    }
}
