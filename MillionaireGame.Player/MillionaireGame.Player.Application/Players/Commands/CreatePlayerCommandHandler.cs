using MediatR;
using MillionaireGame.Player.Application.DataContracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Player.Application.Players.Commands
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Unit>
    {
        private readonly IRepository<Domain.Player> _repository;

        public CreatePlayerCommandHandler(IRepository<Domain.Player> repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
