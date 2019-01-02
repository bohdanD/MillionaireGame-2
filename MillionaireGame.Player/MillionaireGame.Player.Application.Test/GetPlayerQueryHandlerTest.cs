using MillionaireGame.Player.Application.DataContracts;
using MillionaireGame.Player.Application.Players.Queries;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MillionaireGame.Player.Application.Test
{
    public class GetPlayerQueryHandlerTest
    {
        private readonly Mock<IRepository<Domain.Player>> _mock;

        public GetPlayerQueryHandlerTest()
        {
            _mock = new Mock<IRepository<Domain.Player>>();
        }

        [Fact]
        public async void GetPlayer_Test()
        {
            var query = new GetPlayerQuery() { PlayerName = "player" };
            _mock.Setup(r => r.GetSingle(It.IsAny<Expression<Func<Domain.Player, bool>>>()))
                .Returns(Task.Run(() => new Domain.Player() { PlayerId = 1, Name = query.PlayerName }));
            var handler = new GetPlayerQueryHandler(_mock.Object);

            var player = await handler.Handle(query, CancellationToken.None);
            Assert.NotNull(player);
            Assert.True(player.PlayerName == query.PlayerName);
        }

        [Fact]
        public async void GetPlayerFail_Test()
        {
            var query = new GetPlayerQuery() { PlayerName = "some that not exist" };
            _mock.Setup(r => r.GetSingle(It.IsAny<Expression<Func<Domain.Player, bool>>>()))
                .Returns(Task.Run(() => default(Domain.Player)));
            var handler = new GetPlayerQueryHandler(_mock.Object);

            var player = await handler.Handle(query, CancellationToken.None);
            Assert.Null(player);
        }
    }
}
