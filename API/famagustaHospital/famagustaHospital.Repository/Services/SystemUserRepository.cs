using famagustaHospital.Contracts;
using famagustaHospital.Entities.Models;
using famagustaHospital.Repository.Extensions;
using famagustaHospital.Shared.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace famagustaHospital.Repository;
internal sealed class SystemUserRepository : RepositoryBase<SystemUser>, ISystemUserRepository
{
    private RepositoryContext _repository;

    public SystemUserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        _repository = repositoryContext;
    }

    public async Task<PagedList<SystemUser>> GetAllUsersAsync(UserParameter parameters, bool trackChanges)
    {

        var users = await FindByCondition(e => !e.IsDeleted, trackChanges)
             .FilterUsers()
             .SearchUsers(parameters.SearchTerm)
             .SortUsers(parameters.OrderBy)
             .ToListAsync();

        return PagedList<SystemUser>.ToPagedList(users, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<IdentityRole> GetRoleByUserId(string userId)
    {
        var user = await FindByCondition(c => c.Id.Equals(userId), false).SingleOrDefaultAsync();
        var currentUserRole = await _repository.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
        IdentityRole? currentRole = await _repository.Roles.FirstOrDefaultAsync(x => x.Id == currentUserRole.RoleId);

        return currentRole;
    }

    public async Task<SystemUser> GetUserAsync(string id, bool trackChanges) => await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();


}
