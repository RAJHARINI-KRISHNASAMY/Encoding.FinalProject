using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Encodingproject.Models;

namespace Encodingproject.Services
{
    public interface IAuthenticateService
    {
        Admin Authenticate(String UserName, String Password);
    }
}
