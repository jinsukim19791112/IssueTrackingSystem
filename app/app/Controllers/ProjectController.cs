using app.BL;
using app.BL.Common;
using app.BL.Project;
using app.BL.User;
using app.DL;
using app.DL.Home;
using app.DL.Project;
using app.DL.User;
using app.ViewModel.Common;
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
        private ProjectHandler _projectHandler;
        private UserHandler _userHandler;

        public ProjectController()
        {
            _projectHandler = new ProjectHandler(new ProjectDataAccess(), new CommonDataAccess());
            _userHandler = new UserHandler(new UserDataAccess());
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
            List<SelectListItem> statusDropDownList = _projectHandler.GetAllStatus();
            List<SelectListItem> roleDropDownList = _projectHandler.GetRoles();

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
                viewModel = _projectHandler.GetProjectWithId(int.Parse(id));
            }

            // Set ViewBag.
            ViewBag.PageType = type;
            ViewBag.StatusDropDownList = statusDropDownList;
            ViewBag.RoleDropDownList = roleDropDownList;

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetProjectTable()
        {
            var aaData = _projectHandler.GetProjectTable();
            return Json(new
                {
                    aaData = aaData.Select(x => new[] { x.Id, x.Name, x.SourceRespository, x.ReleasedVersion, x.StatusDropDownList })
                }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveProject(ProjectVM viewModel)
        {
            int statusCode = _projectHandler.UpsertProject(viewModel);
            StatusMessage statusMessage = CommonHandler.GetStatusMessage(statusCode);
            return Json(new { code = statusMessage.Code, msg = statusMessage.Message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteProject(int id)
        {
            int statusCode = _projectHandler.DeleteProject(id);
            StatusMessage statusMessage = CommonHandler.GetStatusMessage(statusCode);
            return Json(new { code = statusMessage.Code, msg = statusMessage.Message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProjectMember(int projectId)
        {
            List<UserVM> aaData = _projectHandler.GetProjectMembers(projectId);
            return Json(new
            {
                aaData = aaData.Select(x => new[] {x.Name, x.Email, x.Role, x.Dept })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            List<UserVM> aaData = _userHandler.GetUsers();
            return Json(new
            {
                aaData = aaData.Select(x => new[] { x.Name, x.Email, x.Dept })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}