using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MillionaireGame.Question.Application.DataContracts
{
    public interface IRepository<T> where T : class
    {
        T GetSingle(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> expression);
    }
}
