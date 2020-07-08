using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DAL.Repository
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        T Update(T entity, int id);
        IEnumerable<T> Alert(Expression<Func<T, bool>> condition);
        T GetById(int id);
    }
}
