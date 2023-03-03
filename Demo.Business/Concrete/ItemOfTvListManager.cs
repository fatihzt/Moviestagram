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
    public class ItemOfTvListManager : IItemOfTvListService
    {
        private readonly IItemOfTvList _itemOfTvList;
        public ItemOfTvListManager(IItemOfTvList itemOfTvList)
        {
            _itemOfTvList = itemOfTvList;
        }
        public int Add(ItemOfTvList entity)
        {
            return _itemOfTvList.Add(entity);
        }

        public bool Delete(ItemOfTvList entity)
        {
            return _itemOfTvList.Delete(entity);
        }

        public ItemOfTvList Get(Expression<Func<ItemOfTvList, bool>> filter = null, Func<IQueryable<ItemOfTvList>, IIncludableQueryable<ItemOfTvList, object>> includesPath = null)
        {
            return _itemOfTvList.Get(filter, includesPath);
        }

        public List<ItemOfTvList> GetAll(Expression<Func<ItemOfTvList, bool>> filter = null, Func<IQueryable<ItemOfTvList>, IIncludableQueryable<ItemOfTvList, object>> includesPath = null)
        {
            return _itemOfTvList.GetAll(filter, includesPath);
        }

        public bool Update(ItemOfTvList entity)
        {
            return _itemOfTvList.Update(entity);
        }
    }
}
