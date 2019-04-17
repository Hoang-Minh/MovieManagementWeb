using System;
using System.Web.Mvc;

namespace MovieManagement.Web.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            return View(id);
        }
    }
}