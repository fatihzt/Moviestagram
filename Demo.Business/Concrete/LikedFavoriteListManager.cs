using Demo.Business.Abstract;
using Demo.Core.Abstract;
using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Concrete
{
    public class LikedFavoriteListManager:ILikedFavoriteListService
    {
        private readonly ILikedFavoriteList _likedFavoriteList;
        public LikedFavoriteListManager(ILikedFavoriteList likedFavoriteList)
        {
            _likedFavoriteList = likedFavoriteList;
        }

        public int Add(LikedFavoriteList entity)
        {
            return _likedFavoriteList.Add(entity);
        }

        public bool Delete(LikedFavoriteList entity)
        {
            return _likedFavoriteList.Delete(entity);
        }

        public LikedFavoriteList Get(Expression<Func<LikedFavoriteList, bool>> filter = null)
        {
            return _likedFavoriteList.Get(filter);
        }

        public List<LikedFavoriteList> GetAll(Expression<Func<LikedFavoriteList, bool>> filter = null)
        {
            return _likedFavoriteList.GetAll(filter);
        }

        public bool Update(LikedFavoriteList entity)
        {
            return _likedFavoriteList.Update(entity);
        }
    }
}
