using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoList.BLL.Abstract;
using ToDoList.BLL.Concrete;
using ToDoList.DAL;

namespace ToDoList.Helper
{
    public class SingletonDataList<T> where T: class, new()
    {

        private static List<T> dataList;
        public static List<T> GetObject()
        {
            if (dataList == null)
            {
                using (ToDoListContext db = new ToDoListContext())
                {

                    DbSet<T> dbSet = db.Set<T>();
                    dataList = dbSet.ToList();
                }
            }

            return dataList;
        }



    }
}
