using famagustaHospital.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Contracts
{
    public interface ISessionRepository
    {
        void CreateSession(Session session);
    }
}
