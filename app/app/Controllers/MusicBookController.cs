using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class MusicBookController : Controller
    {
        // GET: MusicBook
        public ActionResult Index()
        {
            return View();
        }
    }
}