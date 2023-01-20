using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Request.FavoriteList.CommentedFavoriteList
{
    public class CommentedFavoriteListCreateRequest
    {
        public int UserId { get; set; }
        public int FavoriteListId { get; set; }
        public string CommentBody { get; set; }
    }
}
