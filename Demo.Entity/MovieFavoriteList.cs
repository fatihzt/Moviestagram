using Demo.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    
    public class MovieFavoriteList:FavoriteListBase<int>
    {
        public int MovieIds { get; set; }
        //public List<int> Movieidleri { get; set; }

    }

   
}
