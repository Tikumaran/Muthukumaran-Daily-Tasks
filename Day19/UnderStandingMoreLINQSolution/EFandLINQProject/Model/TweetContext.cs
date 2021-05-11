using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Model
{
    public class TweetContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q3S933H\SQLEXPRESS;Integrated Security=true;Database=dbTweet");
            }
        }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posts>().HasData(new Posts
            {
                Id = 1,
                PostText="Test",
                Category="Info"

            }) ;

        }
    }
}
