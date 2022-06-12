using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
using Login_Paging.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Login_Paging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly ILoginRepositoy _context;
        private readonly MyDbcontext _context;
        private readonly AppSetting _appSettings;
        public UserController( MyDbcontext context, IOptionsMonitor<AppSetting> options)
        {
            _appSettings = options.CurrentValue;
            _context = context;
        }
        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _context.NguoiDungs.SingleOrDefault(p =>
                p.UserName == model.UserName && model.Password == p.Password);
            if (user == null) // khong dung nguoi dung 
            {
                var login = new ApiResponse
                {
                    Success = false,
                    Message = "Invalid user/password"
                };


            }

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                data = GennerateToken(user)
            });
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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secreKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);

        }
    }
}
