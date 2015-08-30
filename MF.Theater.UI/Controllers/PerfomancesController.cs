using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MF.Theater.DTO;
using MF.Theater.Services.Commands;
using MF.Theater.Services.Queries;
using MF.Theater.UI.Attributes;
using MF.Theater.UI.Extensions;

namespace MF.Theater.UI.Controllers
{
    public class PerfomancesController : Controller
    {
        private readonly IPerfomanceQueries mPerfomanceQueries;
        private readonly IPerfomanceCommands mPerfomanceCommands;

        public PerfomancesController(IPerfomanceQueries perfomanceQueries, IPerfomanceCommands perfomanceCommands)
        {
            mPerfomanceQueries = perfomanceQueries;
            mPerfomanceCommands = perfomanceCommands;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SelectPage(int p, int r)
        {
            var perfomances = mPerfomanceQueries.SelectPagedPerfomances(p, r);

            return new NewtonsoftJsonResult{Data = perfomances, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Count()
        {
            var result = mPerfomanceQueries.PerfomancesCount();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(PerfomanceDto request)
        {
            mPerfomanceCommands.Create(request);
            return Json("success");
        }
    }
}