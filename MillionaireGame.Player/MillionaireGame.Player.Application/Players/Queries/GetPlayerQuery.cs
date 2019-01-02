using MediatR;
using MillionaireGame.Player.Application.Models;

namespace MillionaireGame.Player.Application.Players.Queries
{
    public class GetPlayerQuery : IRequest<PlayerDto>
    {
        public string PlayerName { get; set; }
    }
}
