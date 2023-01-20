using Demo.Core.Abstract;
using Demo.Core.EntityFramework;
using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Concrete
{
    public class EfCommentedFavoriteList:EfEntityRepositoryBase<CommentedFavoriteList,DataBaseContext>,ICommentedFavoriteList
    {
    }
}
