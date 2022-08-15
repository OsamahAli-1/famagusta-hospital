using famagustaHospital.Entities.Models;
using famagustaHospital.Shared.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts;
public interface ISystemUserRepository
{
    Task<PagedList<SystemUser>> GetAllUsersAsync(UserParameter parameters, bool trackChanges);
    Task<SystemUser> GetUserAsync(string id, bool trackChanges);
    Task<IdentityRole> GetRoleByUserId(string userId);

}

