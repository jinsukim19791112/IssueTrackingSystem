using app.BL;
using app.BL.Project;
using app.DL;
using app.DL.Home;
using app.DL.Project;
using app.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectHandler _handler;

        public ProjectController()
        {
            _handler = new ProjectHandler(new ProjectDataAccess(), new CommonDataAccess());
        }

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project Detail for CRUD
        public ActionResult Detail(string id, string type)
        {

            if (type == "E")
            {
                // Set DropDown List.
                List<SelectListItem> statusDropDownList = _handler.GetAllStatus();
                for (int i = 0; i < statusDropDownList.Count; i++)
                {
                    if (statusDropDownList[i].Value == id)
                    {
                        statusDropDownList[i].Selected = true;
                    }
                }
                // Set Project View Model.
                ProjectVM projectVM = _handler.GetProjectWithId(int.Parse(id));

                // Set ViewBag.
                ViewBag.PageType = type;
                ViewBag.Name = projectVM.Name;
                ViewBag.StartDate = projectVM.StartDate;
                ViewBag.EndDate = projectVM.EndDate;
                ViewBag.Description = projectVM.Description;
                ViewBag.StatusDropDownList = statusDropDownList;
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetProjectTable()
        {
            List<ProjectVM> viewModel = _handler.GetProjectTable();

            return Json(new
            {
                aaData = viewModel.Select(x => new[] { x.Id, x.Name, x.StartDate, x.EndDate, x.Status })
            }, JsonRequestBehavior.AllowGet);
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


    }
}