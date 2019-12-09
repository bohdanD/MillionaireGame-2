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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Question>> GetMany(Expression<Func<Domain.Question, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Question> GetSingle(Expression<Func<Domain.Question, bool>> expression)
        {
            return Task.Run(() => new Domain.Question { Answers = null, Id = 1, QuestionText = "blah blah", ComplexityId = 1 });
        }
    }
}
