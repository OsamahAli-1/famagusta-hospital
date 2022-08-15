using AutoMapper;
using famagustaHospital.Contracts;
using famagustaHospital.Entities;
using famagustaHospital.Entities.Exceptions;
using famagustaHospital.Entities.Models;
using famagustaHospital.ServiceContracts;
using famagustaHospital.Shared.DataTransferObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace famagustaHospital.Service;
internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly UserManager<SystemUser> _userManager;
    private readonly IOptions<JwtConfiguration> _configuration;
    private SystemUser? _user;
    private readonly JwtConfiguration _jwtConfiguration;

    public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<SystemUser> userManager, IOptions<JwtConfiguration> configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
        _jwtConfiguration = _configuration.Value;
    }

    public async Task<IdentityResult> RegisterUser(UserCreationDto userDto)
    {
        var user = _mapper.Map<SystemUser>(userDto);
        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (result.Succeeded)
            await _userManager.AddToRoleAsync(user, userDto.Role);

        return result;
    }

    public async Task<AuthenticationResult> AuthenticateUser(AuthenticationDto ar)
    {
        _user = await _userManager.FindByNameAsync(ar.Username);


        if (_user == null || _user.IsDeleted || !_user.IsActive)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "Invalid Credentials" }
            };
        }

        var result = await _userManager.CheckPasswordAsync(_user, ar.Password);

        AuthenticationResult response = new AuthenticationResult();

        if (!result)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "Username/password Combination are wrong" }
            };
        }

        return await CreateToken(populateExp: true);
    }

    public async Task<AuthenticationResult> CreateToken(bool populateExp)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        var refreshToken = GenerateRefreshToken();
        _user.RefreshToken = refreshToken;

        if (populateExp)
            _user.RefreshTokenExpiryTime = DateTime.Now.AddHours(24);

        await _userManager.UpdateAsync(_user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new AuthenticationResult
        {
            Success = true,
            Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
            RefreshToken = refreshToken
        };
    }

    private SigningCredentials GetSigningCredentials()
    {
        //TO:DO Secret Key as Environment variable
        var key = Encoding.UTF8.GetBytes("s,vdhhggiphldih123!");
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var roles = await _userManager.GetRolesAsync(_user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, _user.UserName),
            new Claim("id", _user.Id),
            new Claim("role", roles.FirstOrDefault())
        };

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
        );
        return tokenOptions;
    }

    #region Refresh Token

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
    public async Task<AuthenticationResult> RefreshToken(RefreshTokenRequest token)
    {
        var principal = GetPrincipalFromExpiredToken(token.Token);
        var user = await _userManager.FindByNameAsync(principal.Identity.Name);
        if (user == null || user.RefreshToken != token.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new RefreshTokenBadRequest();
        _user = user;
        return await CreateToken(populateExp: false);
    }
    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
            ValidateLifetime = true,
            ValidIssuer = _jwtConfiguration.ValidIssuer,
            ValidAudience = _jwtConfiguration.ValidAudience
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }
        return principal;
    }

    #endregion
}
