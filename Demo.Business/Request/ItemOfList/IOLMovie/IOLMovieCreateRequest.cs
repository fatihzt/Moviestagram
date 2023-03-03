using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Request.ItemOfList.IOLMovie
{
    public class IOLMovieCreateRequest
    {
        public int FavoriteListId { get; set; }
        public int MovieId { get; set; }
    }
}
