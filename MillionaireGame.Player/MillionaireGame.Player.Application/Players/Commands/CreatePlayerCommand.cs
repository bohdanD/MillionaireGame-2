using MediatR;

namespace MillionaireGame.Player.Application.Players.Commands
{
    public class CreatePlayerCommand : IRequest
    {
        public string PlayerName { get; set; }
    }
}
