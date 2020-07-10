using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Abstract;
using ToDoList.BLL.Concrete;
using ToDoList.DAL;

namespace ToDoList.Helper.Job
{
    public class Job
    {
        private static IScheduler Start()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            IScheduler sched = schedFact.GetScheduler();
            if (!sched.IsStarted)
                sched.Start();

            return sched;
        }

        public static List<EventList> EventList { get; set; } = new List<EventList>();
        public static void Trigger()
        {
            EventList = SingletonDataList<EventList>.GetObject().Where(q => q.Date == Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy")) && q.Time == new TimeSpan(Convert.ToInt32(DateTime.Now.ToString("HH")), Convert.ToInt32(DateTime.Now.ToString("mm")), 00)).ToList();
            IScheduler sched = Start();
            sched.Clear();
            JobMission.EventList.Clear();
            for (int i = 0; i < EventList.Count; i++)
            {
                IJobDetail jobMisson = JobBuilder.Create<JobMission>().WithIdentity(i.ToString(), null).UsingJobData("Title", EventList[i].Title).UsingJobData("Content", EventList[i].Content).UsingJobData("Time", EventList[i].Time.ToString()).UsingJobData("Date", EventList[i].Date.ToString()).UsingJobData("Id", EventList[i].Id.ToString()).Build();

                ISimpleTrigger jobTrigger = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity(i.ToString()).StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInSeconds(60).RepeatForever()).Build();
                sched.ScheduleJob(jobMisson, jobTrigger);
            }


        }
    }
}
