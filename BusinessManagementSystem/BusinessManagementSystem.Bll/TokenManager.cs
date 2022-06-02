using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Bll
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateAccessToken(DtoLoginEmployee employee)
        {
            //claimleri oluşturduk
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employee.EmployeeEmail),
                new Claim(JwtRegisteredClaimNames.Jti, employee.EmployeeId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //claim rolleri oluşturduk
            var claimsRoleList = new List<Claim>
            {
                new Claim("role","Admin"),
                new Claim("role2","Yönetici")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //şifrelenmiş kimlik oluşturduk
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //token ayarlarını burda gerçekleştirdik
            var token = new JwtSecurityToken
            (
                issuer: configuration["Tokens:Issuer"],
                audience: configuration["Tokens:Issuer"],
                expires: DateTime.Now.AddDays(1),//token süresini 1 gün olarak ayarladık
                notBefore: DateTime.Now,//token üretildikten hemen sonra devreye girecek
                signingCredentials: cred,
                claims: claimsIdentity.Claims
            );

            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }
    }
}
