using System;
using System.Web.Mvc;
using MF.Theater.DTO;
using MF.Theater.Services.Commands;
using MF.Theater.Services.Queries;
using MF.Theater.Services.Workflows;
using MF.Theater.UI.Extensions;

namespace MF.Theater.UI.Controllers
{
    public class PerfomancesController : Controller
    {
        private readonly IPerfomanceQueries mPerfomanceQueries;
        private readonly IPerfomanceWorkflow mPerfomanceWorkflow;
        private readonly IPerfomanceCommands mPerfomanceCommands;

        public PerfomancesController(IPerfomanceQueries perfomanceQueries, IPerfomanceWorkflow perfomanceWorkflow, IPerfomanceCommands perfomanceCommands)
        {
            mPerfomanceQueries = perfomanceQueries;
            mPerfomanceWorkflow = perfomanceWorkflow;
            mPerfomanceCommands = perfomanceCommands;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SelectPage(int p, int r, DateTime sd, DateTime ed, string n)
        {
            var perfomances = mPerfomanceQueries.SelectPagedPerfomances(p, r, sd, ed, n);

            return new NewtonsoftJsonResult{Data = perfomances, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Count(DateTime sd, DateTime ed, string n)
        {
            var result = mPerfomanceQueries.PerfomancesCount( sd, ed, n);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(PerfomanceDto request)
        {
            mPerfomanceCommands.Create(request);
            
            return Json("success");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Update(PerfomanceDto request)
        {
            mPerfomanceWorkflow.ExecuteStep(request);
            return Json("success");
        }
    }
}