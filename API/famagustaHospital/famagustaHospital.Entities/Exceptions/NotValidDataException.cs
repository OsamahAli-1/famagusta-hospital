using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Entities.Exceptions;

public class NotValidDataException : BadRequestException
{
    public NotValidDataException() : base("Not Valid Data")
    {

    }
}