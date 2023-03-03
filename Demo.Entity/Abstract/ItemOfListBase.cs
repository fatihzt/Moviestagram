using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity.Abstract
{
    public abstract class ItemOfListBase<T> where T : IEquatable<T>
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("FavoriteListId")]
        public int FavoriteListId { get; set; } 
    }
}
