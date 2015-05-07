using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angular_MVC.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        // the rest of action seems unless if the requests is to use WCF services
        // So MVC. Net service is not really necessary.
    }
}