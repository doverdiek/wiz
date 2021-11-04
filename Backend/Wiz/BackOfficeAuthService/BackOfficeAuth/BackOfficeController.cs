using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BackOfficeAuth
{
    public class BackOfficeController : ControllerBase
    {
        public string UserId => ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
