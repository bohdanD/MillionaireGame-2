using MillionaireGame.Question.Application.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MillionaireGame.Question.Persistence.DbConcrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly QuestionDbContext _questionDbContext;

        public Repository(QuestionDbContext questionDbContext)
        {
            _questionDbContext = questionDbContext;
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return _questionDbContext.Set<T>().Where(expression).AsEnumerable();
        }

        public T GetSingle(Expression<Func<T, bool>> expression)
        {
            return _questionDbContext.Set<T>().Where(expression).FirstOrDefault();
        }
    }
}
