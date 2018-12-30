using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Questions.Queries;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading;
using Xunit;

namespace MillionaireGame.Question.Application.Test
{
    public class GetQuestionQueryHandlerTest
    {
        [Fact]
        public void GetManyByComplexity_Test()
        {
            var mock = new Mock<IRepository<Domain.Question>>();
            var query = new GetQuestionQuery() { CopmlexityId = 1 };
            Expression<Func<Domain.Question, bool>> expression 
                = question => question.ComplexityId == query.CopmlexityId;
            mock.Setup(r => r.GetSingle(expression))
                .Returns(() => new Domain.Question() { QuestionId = 1, ComplexityId = 1 });
            var handler = new GetQuestionQueryHandler(mock.Object);

            var result = handler.Handle(query, CancellationToken.None);

            Assert.Equal(1, result.Result.ComplexityId);
        }
    }
}
