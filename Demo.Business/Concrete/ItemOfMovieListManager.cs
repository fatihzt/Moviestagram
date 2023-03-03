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
    public class ItemOfMovieListManager : IItemOfMovieListService
    {
        private readonly IItemOfMovieList _itemOfMovieList;
        public ItemOfMovieListManager(IItemOfMovieList ıtemOfMovieList)
        {
            _itemOfMovieList = ıtemOfMovieList;
        }

        public int Add(ItemOfMovieList entity)
        {
            return _itemOfMovieList.Add(entity);
        }

        public bool Delete(ItemOfMovieList entity)
        {
            return _itemOfMovieList.Delete(entity);
        }
        public ItemOfMovieList Get(Expression<Func<ItemOfMovieList, bool>> filter = null, Func<IQueryable<ItemOfMovieList>, IIncludableQueryable<ItemOfMovieList, object>> includesPath = null)
        {
            return _itemOfMovieList.Get(filter, includesPath);
        }

        public List<ItemOfMovieList> GetAll(Expression<Func<ItemOfMovieList, bool>> filter = null, Func<IQueryable<ItemOfMovieList>, IIncludableQueryable<ItemOfMovieList, object>> includesPath = null)
        {
            return _itemOfMovieList.GetAll(filter, includesPath);
        }

        public bool Update(ItemOfMovieList entity)
        {
            return _itemOfMovieList.Update(entity);
        }
    }
}
