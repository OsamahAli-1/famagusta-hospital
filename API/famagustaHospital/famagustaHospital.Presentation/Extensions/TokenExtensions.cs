using Microsoft.AspNetCore.Http;
using famagustaHospital.Shared.DataTransferObject;

namespace famagustaHospital.Presentation.Extensions;
public static class TokenExtensions
{
    public static string GetUserId(this HttpContext httpContext)
    {
        if (httpContext.User == null)
        {
            return string.Empty;
        }

        return httpContext.User.Claims.Single(x => x.Type == "id").Value;
    }

    public static string GetStaffName(this HttpContext httpContext)
    {
        if (httpContext.User == null)
        {
            return string.Empty;
        }

        return httpContext.User.Claims.Single(x => x.Type == "name").Value;
    }
    public static string GetStaffUserName(this HttpContext httpContext)
    {
        if (httpContext.User == null)
        {
            return string.Empty;
        }

        return httpContext.User.Claims.Single(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
    }
    public static string GetUserRole(this HttpContext httpContext)
    {
        if (httpContext.User == null)
        {
            return string.Empty;
        }

        var role = httpContext.User.Claims.Single(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
        return role;
    }

    public static TokenDataModel GetHttpContextData(this HttpContext httpContext)
    {
        var tdm = new TokenDataModel();

        if (httpContext.User == null)
        {
            return new TokenDataModel();
        }
        tdm.UserId = httpContext.User.Claims.Single(x => x.Type == "id").Value;
        tdm.Name = httpContext.User.Claims.Single(x => x.Type == "name").Value;
        tdm.Username = httpContext.User.Claims.Single(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        tdm.Role = httpContext.User.Claims.Single(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
        tdm.IP = httpContext.Connection.RemoteIpAddress?.ToString();

        return tdm;
    }


}
