using CqrsApp.Events;
using CqrsApp.Models;
using SimpleCqrs.Eventing;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CqrsApp.Handlers
{
    public class MovieEventHandler : IHandleDomainEvents<MovieCreatedEvent>, 
                                     IHandleDomainEvents<MovieTitleChangedEvent>,
                                     IHandleDomainEvents<MovieReleaseDateChangedEvent>,
                                     IHandleDomainEvents<MovieRunningTimeChangedEvent>
    {
        public void Handle(MovieReleaseDateChangedEvent domainEvent)
        {
            using (MoviesReadModel entities = new MoviesReadModel())
            {
                var movie = entities.Movies.Find(domainEvent.AggregateRootId);
                movie.ReleaseDate = domainEvent.ReleaseDate;
                entities.Entry(movie).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Handle(MovieRunningTimeChangedEvent domainEvent)
        {
            using (MoviesReadModel entities = new MoviesReadModel())
            {
                var movie = entities.Movies.Find(domainEvent.AggregateRootId);
                movie.RunningTimeMinutes = domainEvent.RunningTimeMinutes;
                entities.Entry(movie).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Handle(MovieTitleChangedEvent domainEvent)
        {
            using (MoviesReadModel entities = new MoviesReadModel())
            {
                var movie = entities.Movies.Find(domainEvent.AggregateRootId);
                movie.Title = domainEvent.Title;
                entities.Entry(movie).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Handle(MovieCreatedEvent createdEvent)
        {
            using (MoviesReadModel entities = new MoviesReadModel())
            {
                var movie = new Movie(createdEvent.AggregateRootId, createdEvent.Title, createdEvent.ReleaseDate, createdEvent.RunningTimeMinutes);
                entities.Movies.Add(movie);
                entities.Entry(movie).State = EntityState.Added;
                entities.SaveChanges();
            }
        }
    }
}