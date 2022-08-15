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


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        //_entityRepository = new Lazy<IEntityRepository>(() => new RiskRepository(repositoryContext));
        _userRepository = new Lazy<ISystemUserRepository>(() => new SystemUserRepository(repositoryContext));

    }

    //public IEntityRepository Entity => _entityRepository.Value;
    public ISystemUserRepository SystemUser => _userRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

}

