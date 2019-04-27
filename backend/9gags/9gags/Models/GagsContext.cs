using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace _9gags.Models
{
    public class GagsContext : DbContext
    {
        public GagsContext(DbContextOptions<GagsContext> options)
    : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c => c.Views).WithOne(e => e.User);
            modelBuilder.Entity<Article>().HasMany(c => c.Views).WithOne(e => e.Article);
            modelBuilder.Entity<View>().HasOne(au => au.Article).WithMany(c => c.Views);
            modelBuilder.Entity<View>().HasOne(au => au.User).WithMany(c => c.Views);

            modelBuilder.Entity<User>().HasMany(c => c.Votes).WithOne(e => e.User);
            modelBuilder.Entity<Article>().HasMany(c => c.Votes).WithOne(e => e.Article);
            modelBuilder.Entity<Vote>().HasOne(au => au.Article).WithMany(c => c.Votes);
            modelBuilder.Entity<Vote>().HasOne(au => au.User).WithMany(c => c.Votes);

            modelBuilder.Entity<User>().HasMany(c => c.Comments).WithOne(e => e.User);
            modelBuilder.Entity<Article>().HasMany(c => c.Comments).WithOne(e => e.Article);

            modelBuilder.Entity<Comment>().HasOne(au => au.Article).WithMany(c => c.Comments);
            modelBuilder.Entity<Comment>().HasOne(au => au.User).WithMany(c => c.Comments);
        }
    }
}
