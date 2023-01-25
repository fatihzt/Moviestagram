using Demo.Business.Request.User;
using Demo.Core.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Abstract
{
    public interface IUserService:IUser
    {
        string Register(UserRegistirationRequest user);
        string Login(UserLoginRequest user);
    }
}
