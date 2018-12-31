using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Questions.Queries;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MillionaireGame.Question.Application.Test
{
    public class GetQuestionQueryHandlerTest
    {
        private Mock<IRepository<Domain.Question>> _mock;

        public GetQuestionQueryHandlerTest()
        {
            _mock = new Mock<IRepository<Domain.Question>>();
        }

        [Fact]
        public async void GetSingleByComplexity_Test()
        {
            var query = new GetQuestionQuery() { CopmlexityId = 1 };
            _mock.Setup(r => r.GetSingle(It.IsAny<Expression<Func<Domain.Question, bool>>>()))
                .Returns(Task.Run(() => new Domain.Question() { QuestionId = 1, ComplexityId = 1 }));
            var handler = new GetQuestionQueryHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);
            Assert.NotNull(result);
            Assert.True(result.ComplexityId == 1);
        }

        [Fact]
        public async void GetSingleByComplexityFail_Test()
        {
            var query = new GetQuestionQuery() { CopmlexityId = 5 }; //invalid complexity. 4 is max
            _mock.Setup(r => r.GetSingle(It.IsAny<Expression<Func<Domain.Question, bool>>>()))
                .Returns(Task.Run(() => default(Domain.Question)));
            var handler = new GetQuestionQueryHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
