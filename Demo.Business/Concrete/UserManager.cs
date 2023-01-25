using Demo.Business.Abstract;
using Demo.Business.Request.Jwt;
using Demo.Business.Request.User;
using Demo.Core.Abstract;
using Demo.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUser _user;
        private readonly IConfiguration _configuration;

        public UserManager(IUser user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }

        public int Add(User entity)
        {
            return _user.Add(entity);
        }

        public bool Delete(User entity)
        {
            return _user.Delete(entity);
        }

        public User Get(Expression<Func<User, bool>> filter = null)
        {
            return _user.Get(filter);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _user.GetAll(filter);
        }

        public string Login(UserLoginRequest user)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                            new Claim("EMail",user.EMail),
                            new Claim("Password",user.Password)
                        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims
                /*signingCredentials: signIn*/);
            var encrypted = new JwtSecurityTokenHandler().WriteToken(token);
            return encrypted;
        }

        public string Register(UserRegistirationRequest user)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                            new Claim("EMail",user.EMail),
                            new Claim("Password",user.Password)
                        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims
                /*signingCredentials: signIn*/);
            var encrypted = new JwtSecurityTokenHandler().WriteToken(token);
            return encrypted;
        }

        public bool Update(User entity)
        {
            return _user.Update(entity);
        }
    }
}

 