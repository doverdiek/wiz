using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace BackOfficeAuth
{
    public static class BackOfficeAuthentication
    {
        public static string KEY = "E4C6BE78169EAD8BFD4B6CC4F251EC6E";
        public static void SetupBackOfficeAuthentication(this IServiceCollection collection)
        {
            var key = Encoding.ASCII.GetBytes(KEY);
            collection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
    