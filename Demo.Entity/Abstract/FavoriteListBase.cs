using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity.Abstract
{
    public abstract class FavoriteListBase<T> where T:IEquatable<T>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public DateTime? DateTime { get; set; }
        public virtual User User { get; set; }
    }
}
