using famagustaHospital.Shared.DataTransferObject.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface ISessionService
    {
        Task<SessionDto> CreateSession(SessionCreationDto sessionForCreation);
    }
}
