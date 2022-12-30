using Demo.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class MovieFavoriteList:FavoriteListBase<int>
    {
        public List<int> MovieIds { get; set; }

    }
}
