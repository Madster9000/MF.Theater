using System.Web.Mvc;
using MF.Theater.Services.Queries;

namespace MF.Theater.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPerfomanceQueries mPerfomanceQueries;

        public HomeController(IPerfomanceQueries perfomanceQueries)
        {
            mPerfomanceQueries = perfomanceQueries;
        }

        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }

            if (HttpContext.User.IsInRole("admin"))
            {
                return View("AdminHome");
            }

            return View("UserHome");
        }

    }
}