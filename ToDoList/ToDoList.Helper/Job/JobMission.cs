using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL;

namespace ToDoList.Helper.Job
{
    public class JobMission : IJob
    {
        public static List<EventList> EventList { get; set; } = new List<EventList>();
        public void Execute(IJobExecutionContext context)
        {
          
            JobDataMap data = context.JobDetail.JobDataMap;
            EventList.Add(new EventList()
            {
                Title = data.GetString("Title"),
                Content = data.GetString("Content"),
                Time = TimeSpan.Parse(data.GetString("Time")),
                Date = Convert.ToDateTime(data.GetString("Date")),
                Id = Convert.ToInt32(data.GetString("Id"))
            });

        }
    }
}
