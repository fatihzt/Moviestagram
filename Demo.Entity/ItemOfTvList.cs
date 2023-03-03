using Demo.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class ItemOfTvList:ItemOfListBase<int>
    {
        
        public int TvId { get; set; }
    }
}
