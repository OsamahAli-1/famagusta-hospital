using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities.Exceptions;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject;
using famagustaHospital.Shared.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Service;
internal sealed class SystemUserService : ISystemUserService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly UserManager<SystemUser> _manager;
    private readonly IMapper _mapper;

    public SystemUserService(IRepositoryManager repository, ILoggerManager logger, UserManager<SystemUser> manager, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<UserViewDto> users, MetaData metaData)> GetAllUsersAsync(UserParameter parameters, bool trackChanges)
    {
        var users = await _repository.SystemUser.GetAllUsersAsync(parameters, trackChanges);

        var usersDto = _mapper.Map<IEnumerable<UserViewDto>>(users);

        return (users: usersDto, metaData: users.MetaData);
    }

    public async Task<UserViewDto> GetUserAsync(string id, bool trackChanges)
    {
        var user = await GetUserAndCheckIfItExists(id, trackChanges);
        var userDto = _mapper.Map<UserViewDto>(user);
        return userDto;
    }

    public async Task<UserViewDto> AddUserAsync(UserCreationDto userDto)
    {
        var userEntity = _mapper.Map<SystemUser>(userDto);
        var result = await _manager.CreateAsync(userEntity, userDto.Password);

        if (result.Succeeded)
            await _manager.AddToRoleAsync(userEntity, userDto.Role);

        var userDtoReturn = _mapper.Map<UserViewDto>(userEntity);

        return userDtoReturn;
    }

    public async Task UpdateUserAsync(string userId, UserUpdateDto user, bool trackChanges)
    {
        var currentUser = await GetUserAndCheckIfItExists(userId, trackChanges);
        _mapper.Map(user, currentUser);
        await _repository.SaveAsync();
    }

    public async Task<bool> ResetPasswordAsync(string userId, string loggedInUser, string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new NotValidDataException();

        var user = await GetUserAndCheckIfItExists(userId, false);
        var loggeduser = await GetUserAndCheckIfItExists(loggedInUser, false);

        if (loggeduser.Role != "Admin" && user.Id != loggeduser.Id)
            throw new NotValidDataException();

        try
        {
            await _manager.RemovePasswordAsync(user);
            var x = await _manager.AddPasswordAsync(user, password);

            return x.Succeeded;
        }
        catch
        {
            throw new NotValidDataException();
        }
    }

    public async Task<bool> CahangeRoleAsync(string userId, string role)
    {
        var user = await GetUserAndCheckIfItExists(userId, false);

        var currentRole = await _repository.SystemUser.GetRoleByUserId(userId);

        var Removeresult = await _manager.RemoveFromRoleAsync(user, currentRole.Name);
        var AddResult = false;
        if (Removeresult.Succeeded)
        {
            var saveRole = await _manager.AddToRoleAsync(user, role);
            AddResult = saveRole.Succeeded;
        }

        return AddResult;
    }

    public async Task<bool> CheckUserName(string username)
    {
        var staff = await _manager.FindByNameAsync(username);

        if (staff == null)
            return true;
        else return false;
    }

    private async Task<SystemUser> GetUserAndCheckIfItExists(string id, bool trackChanges)
    {
        var user = await _repository.SystemUser.GetUserAsync(id, trackChanges);
        if (user is null)
            throw new UserNotFoundException(id);
        return user;
    }


}

