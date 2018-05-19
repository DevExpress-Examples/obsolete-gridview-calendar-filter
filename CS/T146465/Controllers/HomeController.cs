using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using MVCxGridViewDataBinding.Models;
using DevExpress.Data.Filtering;

namespace T146465.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = MyModel.GetModelList();
            return PartialView("_GridViewPartial", model);
        }
        public object CreateNextMonthFilter(string field)
        {
            if (String.IsNullOrWhiteSpace(field))
                return String.Empty;
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 2, 1);
            var filter = new BetweenOperator(field, startDate, endDate);
            return filter;
        }
        public object CreateLastMonthFilter(string field)
        {
            if (String.IsNullOrWhiteSpace(field))
                return String.Empty;
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var filter = new BetweenOperator(field, startDate, endDate);
            return filter;
        }
        public ActionResult CustomFilterProcessingAction(string field, string command) {
           ViewData["field"] = field;
           switch(command){
               case  "NextMonth":
                ViewData["filterExpression"] = CreateNextMonthFilter(field);
                   break;
               case "LastMonth":
                   ViewData["filterExpression"] = CreateLastMonthFilter(field);
                   break;
               default:
                   ViewData["filterExpression"] = String.Empty;
                   break;
            }
            var model = MyModel.GetModelList();
            return PartialView("_GridViewPartial", model);
        }
    }
}
