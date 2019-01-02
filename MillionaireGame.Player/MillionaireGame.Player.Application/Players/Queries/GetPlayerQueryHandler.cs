using MediatR;
using MillionaireGame.Player.Application.DataContracts;
using MillionaireGame.Player.Application.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Player.Application.Players.Queries
{
    public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, PlayerDto>
    {
        private readonly IRepository<Domain.Player> _repository;
        public GetPlayerQueryHandler(IRepository<Domain.Player> repository)
        {
            _repository = repository;
        }

        public async Task<PlayerDto> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            var player = await _repository.GetSingle(p => p.Name == request.PlayerName);
            PlayerDto result = null;
            if (player != null)
            {
                result = new PlayerDto()
                {
                    PlayerId = player.PlayerId,
                    PlayerName = player.Name
                };
            }

            return result;

        }
    }
}
