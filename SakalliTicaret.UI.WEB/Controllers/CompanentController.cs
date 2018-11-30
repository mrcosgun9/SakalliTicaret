using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SakalliTicaret.Core.Model;

namespace SakalliTicaret.UI.WEB.Controllers
{
    public class CompanentController : Controller
    {
        SakalliTicaretDb db = new SakalliTicaretDb();
        // GET: Companent
        public ActionResult SliderMenu()
        {
            var Category = db.Categories.ToList();
            return View(Category);
        }

        public ActionResult IndexProcudt()
        {
            var model = db.Products.Take(6).ToList();
            return View(model);
        }
            
    }
}