using OrgChartDotNetFW.DAL;
using OrgChartDotNetFW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrgChartDotNetFW.Controllers
{
    public class ChartController : Controller
    {
        private OrgChartContext db = new OrgChartContext();

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Load()
        {
            var nodes = db.Nodes.ToList();
            return Json(nodes, JsonRequestBehavior.AllowGet);
        }    
    }
}