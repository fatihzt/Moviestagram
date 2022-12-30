﻿using Demo.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Abstract
{
    public interface IMovieFavoriteList:IEntityRepository<MovieFavoriteList>
    {
        List<MovieFavoriteList> GetAll(Expression<Func<MovieFavoriteList, bool>> filter = null, Func<IQueryable<MovieFavoriteList>, IIncludableQueryable<MovieFavoriteList, object>> includesPath = null);
    }
}
