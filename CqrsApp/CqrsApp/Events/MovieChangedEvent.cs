using SimpleCqrs.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CqrsApp.Events
{
    public class MovieTitleChangedEvent : DomainEvent
    {
        public Guid MovieId
        {
            get { return AggregateRootId; }
            set { AggregateRootId = value; }
        }

        public string Title { get; set; }

        public MovieTitleChangedEvent(Guid movieId, string newTitle)
        {
            MovieId = movieId;
            Title = newTitle;
        }
    }

    public class MovieReleaseDateChangedEvent : DomainEvent
    {
        public Guid MovieId
        {
            get { return AggregateRootId; }
            set { AggregateRootId = value; }
        }
        public DateTime ReleaseDate { get; set; }

        public MovieReleaseDateChangedEvent(Guid movieId, DateTime newReleaseDate)
        {
            MovieId = movieId;
            ReleaseDate = newReleaseDate;
        }
    }

    public class MovieRunningTimeChangedEvent : DomainEvent
    {
        public Guid MovieId
        {
            get { return AggregateRootId; }
            set { AggregateRootId = value; }
        }
        public int RunningTimeMinutes { get; set; }
        public MovieRunningTimeChangedEvent(Guid movieId, int newRunningTime)
        {
            MovieId = movieId;
            RunningTimeMinutes = newRunningTime;
        }
    }
}