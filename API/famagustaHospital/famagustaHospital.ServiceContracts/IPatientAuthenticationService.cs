using Microsoft.AspNetCore.Identity;
using famagustaHospital.Shared.DataTransferObject;

namespace famagustaHospital.ServiceContracts;
public interface IPatientAuthenticationService
{
    Task<IdentityResult> RegisterUser(PatientUserCreationDto patientUserForRegistration);
    //Task<bool> ValidateUser(AuthenticationDto request);
    Task<AuthenticationResult> CreateToken(bool populateExp);
    Task<AuthenticationResult> RefreshToken(RefreshTokenRequest token);
    Task<AuthenticationResult> AuthenticateUser(AuthenticationDto ar);
}

