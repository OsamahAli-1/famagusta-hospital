using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.Shared.RequestFeatures;
public class UserParameter : RequestParameters
{
    public UserParameter() => OrderBy = "name";
    public string? SearchTerm { get; set; }
    public string? CurrentRole { get; set; }
    public string? Roles { get; set; }
    public string? LoggedInUserId { get; set; }
}
