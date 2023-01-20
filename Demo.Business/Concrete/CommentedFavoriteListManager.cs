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
    public class CommentedFavoriteListManager:ICommentedFavoriteListService
    {
        private readonly ICommentedFavoriteList _commentedFavoriteList;
        public CommentedFavoriteListManager(ICommentedFavoriteList commentedFavoriteList)
        {
            _commentedFavoriteList = commentedFavoriteList;
        }

        public int Add(CommentedFavoriteList entity)
        {
            return _commentedFavoriteList.Add(entity);
        }

        public bool Delete(CommentedFavoriteList entity)
        {
            return _commentedFavoriteList.Delete(entity);
        }

        public CommentedFavoriteList Get(Expression<Func<CommentedFavoriteList, bool>> filter = null)
        {
            return _commentedFavoriteList.Get(filter);
        }

        public List<CommentedFavoriteList> GetAll(Expression<Func<CommentedFavoriteList, bool>> filter = null)
        {
            return _commentedFavoriteList.GetAll(filter);
        }

        public bool Update(CommentedFavoriteList entity)
        {
            return _commentedFavoriteList.Update(entity);
        }
    }
}
