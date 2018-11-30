using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakalliTicaret.UI.WEB.Areas.Panel.Controllers
{
    public class PartialController : AdminControlerBase
    {
        // GET: Panel/Partial
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult UserMenu()
        {
            return View();
        }
    }
}