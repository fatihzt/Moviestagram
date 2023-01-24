using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Request.FavoriteList.MovieList
{
    public class MovieListCreateRequest
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime? DateTime { get; set; }
        public int MovieIds { get; set; }
        //public List<int> Movieidleri { get; set; }
    }
}
