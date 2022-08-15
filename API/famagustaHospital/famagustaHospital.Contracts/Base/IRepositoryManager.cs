using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts;
public interface IRepositoryManager
{
    //IEntityRepository Entity { get; }
    ISystemUserRepository SystemUser { get; }
    Task SaveAsync();

}
