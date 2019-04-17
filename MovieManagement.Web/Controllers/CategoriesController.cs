using System;
using System.Web.Mvc;

namespace MovieManagement.Web.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            return View(id);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}