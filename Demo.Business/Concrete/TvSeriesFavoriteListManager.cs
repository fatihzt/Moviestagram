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
    public class TvSeriesFavoriteListManager : ITvSeriesFavoriteListService
    {
        private readonly ITvSeriesFavoriteList _tvSeriesFavoriteList;
        public TvSeriesFavoriteListManager(ITvSeriesFavoriteList tvSeriesFavoriteList)
        {
            _tvSeriesFavoriteList = tvSeriesFavoriteList;
        }

        public int Add(TvSeriesFavoriteList entity)
        {
            return _tvSeriesFavoriteList.Add(entity);
        }

        public bool Delete(TvSeriesFavoriteList entity)
        {
            return _tvSeriesFavoriteList.Delete(entity);
        }

       

        public TvSeriesFavoriteList Get(Expression<Func<TvSeriesFavoriteList, bool>> filter = null, Func<IQueryable<TvSeriesFavoriteList>, IIncludableQueryable<TvSeriesFavoriteList, object>> includesPath = null)
        {
            return _tvSeriesFavoriteList.Get(filter, includesPath);
        }

        

        public List<TvSeriesFavoriteList> GetAll(Expression<Func<TvSeriesFavoriteList, bool>> filter = null, Func<IQueryable<TvSeriesFavoriteList>, IIncludableQueryable<TvSeriesFavoriteList, object>> includesPath = null)
        {
            return _tvSeriesFavoriteList.GetAll(filter, includesPath);
        }

        public bool Update(TvSeriesFavoriteList entity)
        {
            return _tvSeriesFavoriteList.Update(entity);
        }
    }
}
