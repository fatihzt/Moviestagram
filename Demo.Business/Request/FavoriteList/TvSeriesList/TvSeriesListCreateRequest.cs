using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Request.FavoriteList.TvSeriesList
{
    public class TvSeriesListCreateRequest
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
