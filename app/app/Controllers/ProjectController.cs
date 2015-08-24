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

        // GET: Project Detail page.
        public ActionResult Detail(string id, string type)
        {
            ProjectVM viewModel = new ProjectVM();
            List<SelectListItem> statusDropDownList = _handler.GetAllStatus();

            // Edit page
            if (type == "E")
            {
                // Set DropDown List.
                for (int i = 0; i < statusDropDownList.Count; i++)
                {
                    if (statusDropDownList[i].Value == id)
                    {
                        statusDropDownList[i].Selected = true;
                    }
                }

                // Set Project View Model.
                viewModel = _handler.GetProjectWithId(int.Parse(id));               
            }

            // Set ViewBag.
            ViewBag.PageType = type;
            ViewBag.StatusDropDownList = statusDropDownList;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetProjectTable()
        {
            List<ProjectVM> viewModel = _handler.GetProjectTable();

            return Json(new
            {
                aaData = viewModel.Select(x => new[] { x.Id, x.Name, x.StartDate, x.EndDate, x.StatusDropDownList })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveProject(ProjectVM viewModel)
        {
            string code = string.Empty;
            string msg = string.Empty;

            int statusCode = _handler.UpsertProject(viewModel);
            if (statusCode == 1)
            {
                code = "200";
                msg = "Transaction completed!";
            }
            else
            {
                code = "500";
                msg = "DB Error";
            }

            // Create Page Success. Redirect to Project Page.
            return Json(new { code = code, msg = msg });
        }

        [HttpPost]
        public JsonResult DeleteProject(int id)
        {
            string code = string.Empty;
            string msg = string.Empty;

            int statusCode = _handler.DeleteProject(id);
            if (statusCode == 1)
            {
                code = "200";
                msg = "Transaction completed!";
            }
            else
            {
                code = "500";
                msg = "DB Error";
            }

            // Create Page Success. Redirect to Project Page.
            return Json(new { code = code, msg = msg });
        }
    }
}