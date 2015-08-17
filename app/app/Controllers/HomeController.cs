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