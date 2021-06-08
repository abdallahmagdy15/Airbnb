using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Airbnb.Repositories
{
    public interface IRepositoryBase<T>
    {
        public Task Add(T t);
        public Task Remove(int id);
        public Task Update(T t);
        public Task<T> Get(int id);
        public List<T> GetAll();
        public List<T> Find(Expression<Func<T, bool>> expression);
        public Task Save();

    }
}
