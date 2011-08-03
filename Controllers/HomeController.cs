using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigApp.Models;
using System.Xml;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace BigApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC! by najam sikander awan";
            using (var context = new BigAppContext())
            {
                using (var writer = new XmlTextWriter(@"d:/MyModel.edmx", Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(context, writer);
                }
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
