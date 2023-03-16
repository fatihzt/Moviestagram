using Demo.Business.Abstract;
using Demo.Business.Request.Jwt;
using Demo.Business.Request.User;
using Demo.Business.Response.User;
using Demo.Core.Abstract;
using Demo.Entity;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
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
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IConfiguration configuration, ILogger<UserController> logger)
        {
            _userService = userService;
            _configuration = configuration;
            _logger = logger;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegistirationRequest dto)
        {
            var result = _userService.GetAll(f => f.EMail == dto.EMail);
            //var eMail= new MimeMessage();
            if (result.Count >= 1)
            {
                return BadRequest("Username is already exist.");
            }
            _logger.LogInformation("Register method is triggered");
            _userService.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User entity = new()
            {
                Name=dto.Name,
                Surname=dto.Surname,
                EMail = dto.EMail,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,

            };
            //eMail.From.Add(MailboxAddress.Parse(_configuration.GetSection("Mail:EMail").Value));
            //eMail.To.Add(MailboxAddress.Parse(dto.EMail));
            //eMail.Body = new TextPart(TextFormat.Html) { Text = Body() };
            //using var smtp= new SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587,SecureSocketOptions.StartTls);
            //smtp.Send(eMail);
            _userService.Add(entity);

            return Ok(entity);
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLoginRequest dto)
        {

            _logger.LogInformation("Login method is triggered");
            var result = _userService.GetAll(f => f.EMail == dto.EMail);
            if (result.Count == 0) { return BadRequest("User is not found."); }
            foreach (var item in result)
            {
                if (!_userService.VerifyPasswordHash(dto.Password, item.passwordHash, item.passwordSalt)) return BadRequest("wrong info");
                string token = _userService.CreateToken(item);
                UserLoginResponse loginResponse = new() {  Id=item.Id,EMail = item.EMail,Password = token,Name=item.Name,Surname=item.Surname };

                return Ok(loginResponse);
            }
            return Ok();
        }
       
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
        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword([FromQuery] string eMail,string newPassword)
        {
            var result = _userService.Get(f => f.EMail == eMail);

            if (result == null) { return BadRequest("User nor found."); }
            _userService.CreatePasswordHash(newPassword,out byte[]passwordHash,out byte[]passwordSalt);
            result.passwordHash = passwordHash;
            result.passwordSalt=passwordSalt;
            _userService.Update(result);
            return Ok(result);
            


        }
        private string Body()
        {
            return new string("<title>\r\nRegister Mail</title>\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n<style>\r\nbody {background-color:#ffffff;background-repeat:no-repeat;background-position:top left;background-attachment:fixed;}\r\nh1{font-family:Impact, sans-serif;color:#000000;background-color:#ffffff;}\r\np {font-family:Helvetica, sans-serif;font-size:18px;font-style:italic;font-weight:bold;color:#000000;background-color:#ffffff;}\r\n</style>\r\n</head>\r\n<body>\r\n<h1>Register Mail</h1>\r\n<p>Thank you for registering at Moviestagram.</p>\r\n<p>If you have any questions, don't hesitate to contact us.</p>\r\n<p>Thank you,</p>\r\n<p>The Moviestagram Team.</p>\r\n</body>");
        }
    }
}
