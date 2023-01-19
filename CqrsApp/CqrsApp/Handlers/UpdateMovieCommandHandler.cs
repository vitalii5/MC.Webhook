using CqrsApp.Commands;
using CqrsApp.Models;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CqrsApp.Handlers
{
    public class UpdateMovieCommandHandler : AggregateRootCommandHandler<UpdateMovieCommand, Movie>
    {
        protected IDomainRepository _repository;

        public UpdateMovieCommandHandler(IDomainRepository repository) : base(repository) { }

        public override void Handle(UpdateMovieCommand command, Movie movie)
        {
            movie.Update(command.AggregateRootId, command.Title, command.ReleaseDate, command.RunningTimeMinutes);
        }
    }

}