using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.BLL.Abstract
{
    public interface IEventListService
    {
        IEnumerable<EventList> GetAll();
        EventList Add(EventList entity);
       
        bool Delete(int id);
        EventList Update(EventList entity, int id);
        IEnumerable<EventList> Alert(DateTime date, TimeSpan time);
        EventList GetById(int id);
    }
}
