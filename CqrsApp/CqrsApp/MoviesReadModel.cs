using CqrsApp.Models;
using SimpleCqrs.Eventing;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CqrsApp
{
    public class MoviesReadModel : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReview> MovieRevies { get; set; }

        public MoviesReadModel() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>().HasKey(p => p.Id).
                HasMany(p => p.Reviews);

            modelBuilder.Entity<Movie>()
                .Ignore(p => p.UncommittedEvents);

            modelBuilder.Entity<MovieReview>().HasKey(p => p.Id)
                .Ignore(p=>p.UncommittedEvents);


            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}