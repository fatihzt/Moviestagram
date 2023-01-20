
using Demo.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core
{
    public class DataBaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:fatihozata.database.windows.net,1433;Initial Catalog=Moviestagram;Persist Security Info=False;User ID=ozata;Password=fatih.0703;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
        public DbSet<User> User { get; set; }
        public DbSet<MovieFavoriteList> MovieFavoriteList { get; set; }
        public DbSet<TvSeriesFavoriteList> TvSeriesFavoriteList { get; set; }
        public DbSet<LikedFavoriteList> LikedFavoriteList { get; set; }
        public DbSet<CommentedFavoriteList> CommentedFavoriteList { get; set; }


    }
}
