using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finanzas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = User.Identity.Name;
            return View();
        }

        public PartialViewResult MenuAdministrador()
        {
            try
            {
                if (true)
                {

                }
                return PartialView("_MenuAdministrador");
            }
            catch 
            {
                return PartialView("_MenuAdministrador");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}