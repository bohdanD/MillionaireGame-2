using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MillionaireGame.Player.Application.DataContracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> Find(int id);
        Task<T> GetSingle(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> expression);
        Task<int> Add(T instance);
    }
}
