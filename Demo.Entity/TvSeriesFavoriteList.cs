using Demo.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class TvSeriesFavoriteList:FavoriteListBase<int>
    {
        public List<int> TvIds { get; set; }
    }
}
