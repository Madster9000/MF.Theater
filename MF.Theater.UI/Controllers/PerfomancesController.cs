using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Theater.Services.Queries;

namespace MF.Theater.UI.Controllers
{
    public class PerfomancesController : Controller
    {
        private readonly IPerfomanceQueries mPerfomanceQueries;

        public PerfomancesController(IPerfomanceQueries perfomanceQueries)
        {
            mPerfomanceQueries = perfomanceQueries;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SelectPage(int p, int r)
        {
            var perfomances = mPerfomanceQueries.SelectPagedPerfomances(p, r);
            return Json(perfomances, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Count()
        {
            var result = mPerfomanceQueries.PerfomancesCount();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}