using CqrsApp.Commands;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CqrsApp.Handlers
{
    public enum CreateMovieStatus
    {
        Successful
    }

    public class CreateMovieCommandHandler : CommandHandler<CreateMovieCommand>
    {

        protected IDomainRepository _repository;

        public CreateMovieCommandHandler(IDomainRepository repository)
        {
            _repository = repository;
        }

        protected CreateMovieStatus ValidateCommand(CreateMovieCommand command)
        {
            return CreateMovieStatus.Successful;
        }


        public override void Handle(CreateMovieCommand command)
        {
            Return(ValidateCommand(command));

            var location = new Models.Movie(Guid.NewGuid(), command.Title, command.ReleaseDate, command.RunningTimeMinutes);

            _repository.Save(location);
        }
    }
}