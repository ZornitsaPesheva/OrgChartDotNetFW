using OrgChartDotNetFW.DAL;
using OrgChartDotNetFW.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public EmptyResult UpdateNode(Node model)
        {
            var node = db.Nodes.First(p => p.id == model.id);
            node.name = model.name;
            node.pid = model.pid;
            node.title = model.title;
            node.tags = model.tags;
            node.img = model.img;
            db.SaveChanges();
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];

                    string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        var path = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(path);

                        return Json(new
                        {
                            url = "/Uploads/" + fname
                        }); 

                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        public EmptyResult RemoveNode(string id)
        {
            var node = db.Nodes.First(p => p.id == id);
            db.Nodes.Remove(node);

            string parentId = node.pid;

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