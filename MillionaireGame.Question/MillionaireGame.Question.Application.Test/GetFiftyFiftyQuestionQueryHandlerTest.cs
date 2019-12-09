using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Questions.Queries;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MillionaireGame.Question.Application.Test
{
    public class GetFiftyFiftyQuestionQueryHandlerTest
    {
        private Mock<IRepository<Domain.Question>> _mock;

        public GetFiftyFiftyQuestionQueryHandlerTest()
        {
            _mock = new Mock<IRepository<Domain.Question>>();
        }

        [Fact]
        public async void GetFiftyFiftyQuestion_Test()
        {
            var query = new GetFiftyFiftyQuestionQuery() { QuestionId = 1 };
            _mock.Setup(r => r.Find(1)).Returns(Task.Run(() => new Domain.Question()
            {
                Id = 1,
                QuestionText = "dsdfdf",
                Answers = new List<Domain.Answer>()
                {
                    new Domain.Answer() { IsCorrect = true },
                    new Domain.Answer() { IsCorrect = false }
                }
            }));
            var handler = new GetFiftyFiftyQuestionQueryHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrWhiteSpace(result.QuestionText));
            Assert.True(result.Answers.Count() == 2);
        }

        [Fact]
        public async void GetFiftyFiftyQuestionFail_Test()
        {
            var query = new GetFiftyFiftyQuestionQuery() { QuestionId = 4546454 };
            _mock.Setup(r => r.Find(4546454)).Returns(Task.Run(() => default(Domain.Question)));
            var handler = new GetFiftyFiftyQuestionQueryHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Null(result);
        }
    }
}
