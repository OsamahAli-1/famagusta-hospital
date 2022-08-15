using System;
using System.Collections.Generic;
using System.Text;

namespace famagustaHospital.Shared.DataTransferObject;

public record RefreshTokenRequest
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
}

