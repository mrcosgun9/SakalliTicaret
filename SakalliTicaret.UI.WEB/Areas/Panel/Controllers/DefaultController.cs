using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SakalliTicaret.UI.WEB.Areas.Panel.Controllers
{
    public class DefaultController : AdminControlerBase
    {
        // GET: Panel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}