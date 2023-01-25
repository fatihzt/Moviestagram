using Demo.Business.Abstract;
using Demo.Business.Request.Jwt;
using Demo.Business.Request.User;
using Demo.Core.Abstract;
using Demo.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegistirationRequest dto)
        {
            if (dto != null && dto.Name != null && dto.Password != null)
            {
                if (dto != null)
                {
                    var encryptedPassword = _userService.Register(dto);
                    User entity = new() { Name = dto.Name, Surname = dto.Surname, Password = encryptedPassword, EMail = dto.EMail, TelNo = dto.TelNo };
                    _userService.Add(entity);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLoginRequest dto)
        {
            var result = _userService.Get(u => u.EMail == dto.EMail);
            if (dto != null && dto.EMail != null && dto.Password != null)
            {
                if (dto != null)
                {
                    var password = _userService.Login(dto);
                    if (result.Password == password)
                    {
                        return Ok("Successfully Login!");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        //[HttpPost("Register")]
        //public IActionResult Register(UserRegistirationRequest dto)
        //{
        //    if (dto != null && dto.Name != null && dto.Password != null)
        //    {
        //        var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
        //        if (dto != null)
        //        {
        //            var claims = new[]
        //            {
        //                new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
        //                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
        //                new Claim("Name",dto.Name),
        //                new Claim("Surname",dto.Surname),
        //                new Claim("Password",dto.Password)
        //            };
        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
        //            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //            var token = new JwtSecurityToken(
        //                jwt.Issuer,
        //                jwt.Audience,
        //                claims,
        //                expires: DateTime.Now.AddMinutes(20),
        //                signingCredentials: signIn);
        //            var encrypted = new JwtSecurityTokenHandler().WriteToken(token);
        //            User entity = new() { Name = dto.Name, Surname = dto.Surname, Password = encrypted, EMail = dto.EMail, TelNo = dto.TelNo };
        //            _userService.Add(entity);
        //            return Ok(encrypted);
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpGet]
        public IActionResult GetAll()
        {
            var result=_userService.GetAll();
            return Ok(result);
        }
        [HttpDelete("DeleteUserById{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool result = _userService.Delete(new() { Id = id });
            return Ok(result);
        }
    }
}
