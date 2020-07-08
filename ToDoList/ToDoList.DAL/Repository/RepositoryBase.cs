using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ToDoList.DAL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly ToDoListContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase()
        {
            _context = new ToDoListContext();
            _dbSet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> Alert(Expression<Func<T, bool>> condition)
        {
            return _dbSet.Where(condition).ToList();
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                return Delete(entity);
            }


            return false;
        }
        public bool Delete(T entity)
        {

            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
            int result = _context.SaveChanges();
            return result == 0 ? false : true;


        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Update(T entity, int id)
        {
            _context.Entry<T>(GetById(id)).State = EntityState.Detached;
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
