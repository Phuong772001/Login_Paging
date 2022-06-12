using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Login_Paging.Data;
using Login_Paging.Extensions;
using Login_Paging.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Login_Paging.Services
{
    public class LoginRepositoy : ILoginRepositoy
    {
        private readonly MyDbcontext _context;
        private readonly AppSetting _appSettings;
        public LoginRepositoy(MyDbcontext context, IOptionsMonitor<AppSetting> options)
        {
            _context = context;
            _appSettings = options.CurrentValue;
        }
        public string Login(LoginModel mode)
        {
            var user = _context.NguoiDungs.SingleOrDefault(p =>
                p.UserName == mode.UserName && mode.Password == p.Password);
            if (user == null) // khong dung nguoi dung 
            {
                var login = new ApiResponse
                {
                    Success = false,
                    Message = "Invalid user/password"
                };


            }

            return new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                data = GennerateToken(user)
            }.ToString();
        }

        private string GennerateToken(NguoiDung nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secreKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nguoiDung.HoTen),
                    new Claim(ClaimTypes.Email, nguoiDung.Email),
                    new Claim("UserName", nguoiDung.UserName),
                    new Claim("Id", nguoiDung.Id.ToString()),
                //role
                new Claim("TokenId",Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secreKeyBytes),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);

        }
    }
}
