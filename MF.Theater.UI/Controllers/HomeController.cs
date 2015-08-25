using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Theater.Services.Queries;
using MF.Theater.UI.ViewModels;

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
            var viewModel = new PerfomanceViewModel
            {
                Perfomances = mPerfomanceQueries.SelectAll()
            };
            return View(viewModel);
        }

    }
}