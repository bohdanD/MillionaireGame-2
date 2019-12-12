using MillionaireGame.Question.Application.Answers.Queries;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Domain;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MillionaireGame.Question.Application.Test
{
    public class GetAnswerCorrectnessQueryHandlerTest
    {
        private Mock<IRepository<Answer>> _mock;
        public GetAnswerCorrectnessQueryHandlerTest()
        {
            _mock = new Mock<IRepository<Answer>>();
        }

        [Fact]
        public async void GetAnswerCorrectness_Test()
        {
            var query = new GetCorrectAnswerQuery() { AnswerId = 1 };
            _mock.Setup(r => r.Find(1))
                .Returns(Task.Run(() => new Answer() { AnswerId = 1, AnswerText = "text", IsCorrect = true }));
            var handler = new GetCorrectAnswerQueryHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);
            Assert.NotNull(result);
            Assert.NotNull(result.IsCorrect);
            Assert.True(result.AnswerId == 1);
        }

        [Fact]
        public async void GetAnswerCorrectnessFail_Test()
        {
            var query = new GetCorrectAnswerQuery();
            _mock.Setup(r => r.Find(0))
                .Returns(Task.Run(() => default(Answer)));
            var handler = new GetCorrectAnswerQueryHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
