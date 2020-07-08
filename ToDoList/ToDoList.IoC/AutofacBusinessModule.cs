using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.Abstract;
using ToDoList.BLL.Concrete;

namespace ToDoList.IoC
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventListService>().As<IEventListService>(); 

            base.Load(builder);
        }
    }
}
