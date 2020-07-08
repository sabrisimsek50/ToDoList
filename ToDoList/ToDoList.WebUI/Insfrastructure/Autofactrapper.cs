using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ToDoList.IoC;

namespace ToDoList.WebUI.Insfrastructure
{
    public class Autofactrapper
    {
        public static void Run()
        {
            SetAutofacContainer();

        }

        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new AutofacBusinessModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        
    }
}