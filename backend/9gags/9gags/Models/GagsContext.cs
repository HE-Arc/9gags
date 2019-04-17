﻿using System;
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
            modelBuilder.Entity<View>().HasKey(t =>
            new { t.ArticleId, t.UserId });

            modelBuilder.Entity<View>()
             .HasOne(au => au.Article)
             .WithMany(u => u.Views)
             .HasForeignKey(au => au.ArticleId);

            modelBuilder.Entity<View>()
                .HasOne(au => au.User)
                .WithMany(u => u.Views)
                .HasForeignKey(au => au.UserId);

            modelBuilder.Entity<Comment>().HasKey(t =>
           new { t.ArticleId, t.UserId });

            modelBuilder.Entity<Comment>()
             .HasOne(au => au.Article)
             .WithMany(u => u.Comments)
             .HasForeignKey(au => au.ArticleId);

            modelBuilder.Entity<Comment>()
                .HasOne(au => au.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(au => au.UserId);

            modelBuilder.Entity<Vote>().HasKey(t =>
           new { t.ArticleId, t.UserId });

            modelBuilder.Entity<Vote>()
             .HasOne(au => au.Article)
             .WithMany(u => u.Votes)
             .HasForeignKey(au => au.ArticleId);

            modelBuilder.Entity<Vote>()
                .HasOne(au => au.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(au => au.UserId);

        }
    }
}
