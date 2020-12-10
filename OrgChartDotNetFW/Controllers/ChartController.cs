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

        public JsonResult AddNode(Node model)
        {

            db.Nodes.Add(model);

            db.SaveChanges();

            return Json(new { id = model.id }, JsonRequestBehavior.AllowGet);
        }

        public EmptyResult RemoveNode(string id)
        {
            var node = db.Nodes.First(p => p.id == id);
            db.Nodes.Remove(node);

            string? parentId = node.pid;

            var children = db.Nodes.Where(p => p.pid == node.id);
            foreach (var child in children)
            {
                child.pid = node.pid;
            }

            db.SaveChanges();
            return new EmptyResult();
        }
    }
}