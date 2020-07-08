using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ToDoList.BLL.Abstract;
using ToDoList.WebUI.Models;

namespace ToDoList.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventListService _eventListService;
        public HomeController(IEventListService eventListService)
        {
            _eventListService = eventListService;
        }
        public ActionResult Index()
        {

            return View(_eventListService.GetAll());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Add(EventListRequestModel arg)
        {

            return Json(_eventListService.Add(new ToDoList.Entities.EventList()
            {
                Content = arg.Content,
                Date = arg.Date,
                Id = arg.Id,
                Time = arg.Time,
                Title = arg.Title
            }), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            return Json(_eventListService.Delete(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            var entity = _eventListService.GetById(id);
            EventListRequestModel request = new EventListRequestModel()
            {
                Content = entity.Content,
                Date = entity.Date,
                Id = entity.Id,
                Time = entity.Time,
                Title = entity.Title
            };
            return View(request);
        }
        [HttpPost]
        public JsonResult Update(EventListRequestModel arg)
        { 
            return Json(
            _eventListService.Update(new Entities.EventList()
            {
                Id = arg.Id,
                Content = arg.Content,
                Date = arg.Date,
                Time = arg.Time,
                Title = arg.Title
            }
            , arg.Id)
            , JsonRequestBehavior.AllowGet);
        }

    }
}