using famagustaHospital.Shared.DataTransferObject;
using famagustaHospital.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts;
public interface ISystemUserService
{
    Task<(IEnumerable<UserViewDto> users, MetaData metaData)> GetAllUsersAsync(UserParameter parameters, bool trackChanges);
    Task<UserViewDto> GetUserAsync(string id, bool trackChanges);
    Task<UserViewDto> AddUserAsync(UserCreationDto userDto);
    Task<bool> ResetPasswordAsync(string userId, string loggedInUser, string password);
    Task UpdateUserAsync(string userId, UserUpdateDto user, bool trackChanges);
    Task<bool> CheckUserName(string username);
}

