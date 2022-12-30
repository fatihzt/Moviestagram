using Demo.Business.Abstract;
using Demo.Core.Abstract;
using Demo.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Concrete
{
    public class MovieFavoriteListManager : IMovieFavoriteListService
    {
        private readonly IMovieFavoriteList _movieFavoriteList;
        public MovieFavoriteListManager(IMovieFavoriteList movieFavoriteList)
        {
            _movieFavoriteList = movieFavoriteList;
        }
    
        public int Add(MovieFavoriteList entity)
        {
            return _movieFavoriteList.Add(entity);
        }

        public bool Delete(MovieFavoriteList entity)
        {
           return _movieFavoriteList.Delete(entity);
        }

        public MovieFavoriteList Get(Expression<Func<MovieFavoriteList, bool>> filter = null)
        {
            return _movieFavoriteList.Get(filter);
        }

        public List<MovieFavoriteList> GetAll(Expression<Func<MovieFavoriteList, bool>> filter = null)
        {
           return _movieFavoriteList.GetAll(filter);
        }

        public List<MovieFavoriteList> GetAll(Expression<Func<MovieFavoriteList, bool>> filter = null, Func<IQueryable<MovieFavoriteList>, IIncludableQueryable<MovieFavoriteList, object>> includesPath = null)
        {
            return _movieFavoriteList.GetAll(filter, includesPath);
        }

        public bool Update(MovieFavoriteList entity)
        {
            return _movieFavoriteList.Update(entity);
        }
    }
}
