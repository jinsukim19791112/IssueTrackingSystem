using app.BL;
using app.DL;
using app.DL.Home;
using app.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        # region Project
        public ActionResult ProjectList()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProjectTable()
        {
            HomeHandler handler = new HomeHandler(new HomeDataAccess());
            List<ProjectVM> viewModel = handler.GetProject(0, 100);

            return Json(new
            {
                aaData = viewModel.Select(x => new[] { x.Id, x.Name, x.StartDate, x.EndDate, x.Status })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult NewProject(FormCollection collection)
        {
            string name = collection["name"];
            string startDate = collection["startDate"];
            string endDate = collection["endDate"];
            string status = collection["status"];

            // TODO Call DL to save data.

            // Create Page Success. Redirect to Project Page.
            return Json(new { code = "200", msg = "Transaction completed!" });
        }

        [HttpGet]
        public JsonResult GetProjectWithID(int id)
        {
            // TODO Call DL to retrieve data.

            ProjectVM viewModel = new ProjectVM();
            viewModel.Name = "musicbook";
            viewModel.StartDate = "2015-01-01";
            viewModel.EndDate = "2015-12-31";
            viewModel.Status = "Open";

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
        # endregion Project

        public ActionResult Incident()
        {
            HomeHandler handler = new HomeHandler(new HomeDataAccess());
            List<IncidentVM> viewModel = handler.GetIncident(0, 100);
            return View(viewModel);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }    
}