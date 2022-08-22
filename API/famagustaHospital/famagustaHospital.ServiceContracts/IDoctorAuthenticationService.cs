using famagustaHospital.Shared.DataTransferObject;
using famagustaHospital.Shared.DataTransferObject.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace famagustaHospital.ServiceContracts
{
    public interface IDoctorAuthenticationService
    {
        Task<IdentityResult> RegisterUser(DoctorUserCreationDto doctorUserForRegistration);
        //Task<bool> ValidateUser(AuthenticationDto request);
        Task<AuthenticationResult> CreateToken(bool populateExp);
        Task<AuthenticationResult> RefreshToken(RefreshTokenRequest token);
        Task<AuthenticationResult> AuthenticateUser(AuthenticationDto ar);
    }
}
