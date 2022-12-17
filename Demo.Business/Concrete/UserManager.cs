using Demo.Business.Abstract;
using Demo.Core.Abstract;
using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUser _user;

        public UserManager(IUser user)
        {
            _user = user;
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

        public bool Update(User entity)
        {
            return _user.Update(entity);
        }
    }
}
