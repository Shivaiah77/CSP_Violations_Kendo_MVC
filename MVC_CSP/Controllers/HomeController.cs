using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MVC_CSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CSP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDatalist([DataSourceRequest] DataSourceRequest request)
        {
            List<GridDetails> objlist = new List<GridDetails>();
            objlist.Add(new GridDetails { EmployeeId = 1, First_Name = "shiva", Last_Name = "Dantala", Address = "Hyderabad", Phone = "9999999999" });
            objlist.Add(new GridDetails { EmployeeId = 2, First_Name = "Sagar", Last_Name = "pakki", Address = "Hyderabad", Phone = "777777777" });
            objlist.Add(new GridDetails { EmployeeId = 3, First_Name = "Nagoorbi", Last_Name = "Shaik", Address = "Hyderabad", Phone = "1234567891" });
            return Json(objlist.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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