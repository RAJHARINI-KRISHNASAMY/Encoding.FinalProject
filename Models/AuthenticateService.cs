using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Encodingproject.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Encodingproject.Models
{
    public class AuthenticateService :  IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        private List<Admin> Admins = new List<Admin>(){
new Admin{AdminId =1, Fname = "Rajharini", Lname="Krishnasamy", UserName="Harini", Password ="password"}
};
        public Admin Authenticate(string userName, string password)
        {
            var admin = Admins.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            //return null if Admin not found
            if (admin == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
new Claim(ClaimTypes.Name, admin.AdminId.ToString()),
new Claim(ClaimTypes.Role, "Admin"),
new Claim(ClaimTypes.Version, "V3.1")
}),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                admin.Token = tokenHandler.WriteToken(token);
                return admin;
                admin.Password = null;
            }
        }
    }
}
