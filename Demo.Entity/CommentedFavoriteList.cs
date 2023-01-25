using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class CommentedFavoriteList
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("FavoriteListId")]
        public int FavoriteListId { get; set; }
        public int? MovieId { get; set; }
        public int? TvSeriesId { get; set; }
        public string CommentBody { get; set; }
    }
}
