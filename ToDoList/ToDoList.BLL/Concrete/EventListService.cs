using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Abstract;
using ToDoList.DAL.Repository;
using ToDoList.DAL;

namespace ToDoList.BLL.Concrete
{
    public class EventListService : IEventListService
    {
        private readonly RepositoryBase<EventList> _repo;
        public EventListService()
        {
            _repo = new RepositoryBase<EventList>();
        }
        public EventList Add(EventList entity)
        {
            return _repo.Add(entity);
        }

        public IEnumerable<EventList> Alert(DateTime date, TimeSpan time)
        {
            return _repo.Alert(q => q.Date == date && q.Time == time);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<EventList> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public EventList GetById(int id)
        {
            return _repo.GetById(id);
        }

        public EventList Update(EventList entity, int id)
        {
            return _repo.Update(entity, id);
        }
    }
}
