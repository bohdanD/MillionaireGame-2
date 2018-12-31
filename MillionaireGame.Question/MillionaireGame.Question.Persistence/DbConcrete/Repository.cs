using Microsoft.EntityFrameworkCore;
using MillionaireGame.Question.Application.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Persistence.DbConcrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly QuestionDbContext _questionDbContext;

        public Repository(QuestionDbContext questionDbContext)
        {
            _questionDbContext = questionDbContext;
        }

        public Task<T> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression)
        {
            return await _questionDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> expression)
        {
            return await _questionDbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }
    }
}
