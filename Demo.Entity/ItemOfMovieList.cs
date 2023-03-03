using Demo.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class ItemOfMovieList:ItemOfListBase<int>
    {
        
        public int MovieId { get; set; }
    }
}
