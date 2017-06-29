using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication_Test.Controllers
{
    public class PreAdminController : Controller
    {
        //
        // GET: /PreAdmin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}
