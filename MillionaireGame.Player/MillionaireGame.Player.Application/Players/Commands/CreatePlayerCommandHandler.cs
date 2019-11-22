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

        public async Task<Unit> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return Unit.Value;
            }

            await _repository.Add(new Domain.Player { Name = request.PlayerName });

            return Unit.Value;
        }
    }
}
