using System.Linq;
using System.Web.Mvc;
using ToDoList.BLL.Abstract;
using ToDoList.Helper;
using ToDoList.Helper.Job;
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

            var result = _eventListService.Add(new ToDoList.DAL.EventList()
            {
                Content = arg.Content,
                Date = arg.Date,
                Id = arg.Id,
                Time = arg.Time,
                Title = arg.Title
            });
            SingletonDataList<DAL.EventList>.GetObject().Add(new DAL.EventList()
            {
                Content = result.Content,
                Date = result.Date,
                Id = result.Id,
                Time = result.Time,
                Title = result.Title
            });

            return Json(result, JsonRequestBehavior.AllowGet);
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
            var entity = _eventListService.Update(new DAL.EventList
            {
                Id = arg.Id,
                Content = arg.Content,
                Date = arg.Date,
                Time = arg.Time,
                Title = arg.Title
            }, arg.Id);
            SingletonDataList<DAL.EventList>.GetObject().Remove(SingletonDataList<DAL.EventList>.GetObject().Where(q => q.Id == arg.Id).FirstOrDefault());
            SingletonDataList<DAL.EventList>.GetObject().Add(new DAL.EventList()
            {
                Content = entity.Content,
                Date = entity.Date,
                Id = entity.Id,
                Time = entity.Time,
                Title = entity.Title
            });

            return Json(
            entity
            , JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Trigger()
        {
            Job.Trigger();
       


            return Json(Job.EventList, JsonRequestBehavior.AllowGet);
        }
    }
}