using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Persistence.DbConcrete
{
    public class RepositoryMock : IRepository<Domain.Question>
    {
        public Task<Domain.Question> Find(int id)
        {
            var answers = new List<Answer>
            {
                new Answer { IsCorrect = false, AnswerId = 1 },
                new Answer { IsCorrect = false, AnswerId = 2 },
                new Answer { IsCorrect = true, AnswerId = 3 },
                new Answer { IsCorrect = false, AnswerId = 4 }
            };
            return Task.Run(() => new Domain.Question { Answers = answers, Id = 1, QuestionText = "blah blah", ComplexityId = 1 });
        }

        public Task<IEnumerable<Domain.Question>> GetMany(Expression<Func<Domain.Question, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Question> GetSingle(Expression<Func<Domain.Question, bool>> expression)
        {
            var answers = new List<Answer>
            {
                new Answer { IsCorrect = false, AnswerId = 1 },
                new Answer { IsCorrect = false, AnswerId = 2 },
                new Answer { IsCorrect = true, AnswerId = 3 },
                new Answer { IsCorrect = false, AnswerId = 4 }
            };
            return Task.Run(() => new Domain.Question { Answers = answers, Id = 1, QuestionText = "blah blah", ComplexityId = 1 });
        }
    }
}
