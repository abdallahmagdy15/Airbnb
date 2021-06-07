using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Airbnb.Repository
{
    public interface IRepositoryBase<T>
    {
        public void Add(T t);
        public void Remove(int id);
        public void Update(T t);
        public T Get(int id);
        public List<T> GetAll();
        public List<T> Find(Expression<Func<T, bool>> expression);
        public void Save();

    }
}
