﻿using System;
using System.Collections.Generic;
using System.Text;

namespace famagustaHospital.Shared.DataTransferObject;

public record AuthenticationResult
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public bool Success { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}

