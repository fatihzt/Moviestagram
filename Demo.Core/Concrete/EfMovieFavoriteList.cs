using Demo.Core.Abstract;
using Demo.Core.EntityFramework;
using Demo.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Concrete
{
    public class EfMovieFavoriteList : EfEntityRepositoryBase<MovieFavoriteList, DataBaseContext>, IMovieFavoriteList
    {
        public List<MovieFavoriteList> GetAll(Expression<Func<MovieFavoriteList, bool>> filter = null, Func<IQueryable<MovieFavoriteList>, IIncludableQueryable<MovieFavoriteList, object>> includesPath = null)
        {
            using (DataBaseContext dbcontext = new DataBaseContext())
            {
                var query = dbcontext.Set<MovieFavoriteList>().AsQueryable();

                //filtre yoksa herşeyi getir eğer filtre varsa filtreye göre getir.
                if (filter != null) query = query.Where(filter);

                if (includesPath != null) query = includesPath(query);

                return query.ToList();
            }
        }
    }
}
