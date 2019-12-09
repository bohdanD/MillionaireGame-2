using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Questions.Queries;
using MillionaireGame.Question.Domain;
using Moq;
using System;
using System.Linq;
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
                .Returns(Task.Run(() => new Domain.Question() { Id = 1, ComplexityId = 1 }));
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

        [Fact]
        public async void GetSingleByComplexityAnswers_Test()
        {
            var query = new GetQuestionQuery();
            var answers = new[]
            {
                new Answer() { AnswerId = 1, AnswerText = "a1", IsCorrect = false },
                new Answer() { AnswerId = 2, AnswerText = "a2", IsCorrect = false },
                new Answer() { AnswerId = 3, AnswerText = "a3", IsCorrect = true },
                new Answer() { AnswerId = 4, AnswerText = "a4", IsCorrect = false }
            };
            _mock.Setup(r => r.GetSingle(It.IsAny<Expression<Func<Domain.Question, bool>>>()))
                .Returns(Task.Run(() => new Domain.Question() { Id = 1, ComplexityId = 1, Answers = answers }));
            var handler = new GetQuestionQueryHandler(_mock.Object);

            var result = await handler.Handle(query, CancellationToken.None);
            Assert.NotNull(result);
            Assert.NotNull(result.Answers);
            Assert.True(result.Answers.Count() == 4);
            Assert.True(result.Answers.All(a => !string.IsNullOrWhiteSpace(a.AnswerText)));
            Assert.True(result.Answers.All(a => a.AnswerId != 0));
            Assert.True(result.Answers.All(a => a.IsCorrect == null));
        }
    }
}
