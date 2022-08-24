using famagustaHospital.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    //private readonly Lazy<IEntityRepository> _entityRepository;
    private readonly Lazy<ISystemUserRepository> _userRepository;
    private readonly Lazy<IPatientRepository> _patientRepository;
    private readonly Lazy<IDoctorRepository> _doctorRepository;
    private readonly Lazy<IChronicRepository> _chronicRepository;
    private readonly Lazy<IQualificationRepository> _qualificationRepository;
    private readonly Lazy<IExperienceRepository> _experienceRepository;
    private readonly Lazy<IDoctorAvailabilityRepository> _doctorAvailabilityRepository;
    private readonly Lazy<ISessionRepository> _sessionRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        //_entityRepository = new Lazy<IEntityRepository>(() => new RiskRepository(repositoryContext));
        _userRepository = new Lazy<ISystemUserRepository>(() => new SystemUserRepository(repositoryContext));
        _patientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(repositoryContext));
        _doctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(repositoryContext));
        _chronicRepository = new Lazy<IChronicRepository>(() => new ChronicRepository(repositoryContext));
        _qualificationRepository = new Lazy<IQualificationRepository>(() => new QualificationRepository(repositoryContext));
        _experienceRepository = new Lazy<IExperienceRepository>(() => new ExperienceRepository(repositoryContext));
        _doctorAvailabilityRepository = new Lazy<IDoctorAvailabilityRepository>(() => new DoctorAvailabilityRepository(repositoryContext));
        _sessionRepository = new Lazy<ISessionRepository>(() => new SessionRepository(repositoryContext));
    }

    //public IEntityRepository Entity => _entityRepository.Value;SSS
    public ISystemUserRepository SystemUser => _userRepository.Value;
    public IPatientRepository Patient => _patientRepository.Value;
    public IDoctorRepository Doctor => _doctorRepository.Value;
    public IChronicRepository Chronic => _chronicRepository.Value;
    public IQualificationRepository Qualification => _qualificationRepository.Value;
    public IExperienceRepository Experience => _experienceRepository.Value;
    public IDoctorAvailabilityRepository DoctorAvailability => _doctorAvailabilityRepository.Value;
    public ISessionRepository Session => _sessionRepository.Value;
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

}

