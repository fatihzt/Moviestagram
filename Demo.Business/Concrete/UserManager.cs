using Demo.Business.Abstract;
using Demo.Business.Request.Jwt;
using Demo.Business.Request.User;
using Demo.Core.Abstract;
using Demo.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
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

        

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null || password.Length < 9) { throw new ArgumentException("Password must be at least 8 characters long"); }
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public string CreateToken(User user)
        {
            var secureKey = Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value);
            var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Sub,_configuration.GetSection("jwt:Subject").Value),
                            new Claim("EMail",user.EMail),
                            new Claim("passwordHash",user.passwordHash.ToString()),
                            new Claim("passwordSalt",user.passwordSalt.ToString())
                        };

            var securityKey = new SymmetricSecurityKey(secureKey);
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);


            var token = new JwtSecurityToken(
                _configuration.GetSection("Jwt:Issuer").Value,
                _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddMinutes(10)

                );

            var tokens = new JwtSecurityTokenHandler().WriteToken(token);

            return tokens;
        }

        public bool Delete(User entity)
        {
            return _user.Delete(entity);
        }

       

        public User Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IIncludableQueryable<User, object>> includesPath = null)
        {
            return _user.Get(filter, includesPath);
        }

       

        public List<User> GetAll(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IIncludableQueryable<User, object>> includesPath = null)
        {
            return _user.GetAll(filter, includesPath);
        }

        

        public bool Update(User entity)
        {
            return _user.Update(entity);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}

 