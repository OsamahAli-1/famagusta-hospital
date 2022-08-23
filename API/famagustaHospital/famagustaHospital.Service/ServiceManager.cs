﻿using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace famagustaHospital.Service;
public sealed class ServiceManager : IServiceManager
{
    //private readonly Lazy<IEntityService> _entityService;
    private readonly Lazy<ISystemUserService> _userService;
    private readonly Lazy<IPatientService> _patientService;
    private readonly Lazy<IAuthenticationService> _authService;
    private readonly Lazy<IPatientAuthenticationService> _patientAuthService;
    private readonly Lazy<IDoctorAuthenticationService> _doctorAuthService;
    private readonly Lazy<IChronicService> _chronicService;
    private readonly Lazy<IDoctorService> _doctorService;
    private readonly Lazy<IQualificationService> _qualificationService;





    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<SystemUser> manager, IOptions<JwtConfiguration> configuration)
    {
        _authService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, manager, configuration));
        _userService = new Lazy<ISystemUserService>(() => new SystemUserService(repositoryManager, logger,manager, mapper));
        _patientService = new Lazy<IPatientService>(() => new PatientService(repositoryManager, logger, mapper));
        _patientAuthService = new Lazy<IPatientAuthenticationService>(() => new PatientAuthenticationService(repositoryManager, logger, mapper, manager, configuration));
        _doctorAuthService = new Lazy<IDoctorAuthenticationService>(() => new DoctorAuthenticationService(repositoryManager, logger, mapper, manager, configuration));
        _chronicService = new Lazy<IChronicService>(() => new ChronicService(repositoryManager, logger, mapper));
        _doctorService = new Lazy<IDoctorService>(() => new DoctorService(repositoryManager, logger, mapper));
        _qualificationService = new Lazy<IQualificationService>(() => new QualificationService(repositoryManager, logger, mapper));
        //_entityService = new Lazy<IEntityService>(() => new EntityService(repositoryManager, logger, mapper));

    }
    public IAuthenticationService AuthenticationService => _authService.Value;
    public ISystemUserService SystemUserService => _userService.Value;
    public IPatientService PatientService => _patientService.Value;
    public IPatientAuthenticationService PatientAuthenticationService => _patientAuthService.Value;
    public IDoctorAuthenticationService DoctorAuthenticationService => _doctorAuthService.Value;
    public IChronicService ChronicService => _chronicService.Value;
    public IDoctorService DoctorService => _doctorService.Value;
    public IQualificationService QualificationService => _qualificationService.Value;
    //public IEntityService EntityService => _entityService.Value;

}

