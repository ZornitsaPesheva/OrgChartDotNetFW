using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrgChartDotNetFW.DAL;
using OrgChartDotNetFW.Models;

namespace OrgChartDotNetFW.Controllers
{
    public class NodeController : Controller
    {
        private OrgChartContext db = new OrgChartContext();

        // GET: Node
        public ActionResult Index()
        {
            return View(db.Nodes.ToList());
        }

        // GET: Node/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = db.Nodes.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // GET: Node/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Node/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pid,Stpid,Name,Title,Img,InternalTags")] Node node)
        {
            if (ModelState.IsValid)
            {
                db.Nodes.Add(node);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(node);
        }

        // GET: Node/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = db.Nodes.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: Node/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pid,Stpid,Name,Title,Img,InternalTags")] Node node)
        {
            if (ModelState.IsValid)
            {
                db.Entry(node).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(node);
        }

        // GET: Node/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = db.Nodes.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: Node/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Node node = db.Nodes.Find(id);
            db.Nodes.Remove(node);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public JsonResult Read()
        {
            var nodes = db.Nodes.Select(p => new Node { Id = p.Id, Pid = p.Pid, Name = p.Name });
            return Json(new { nodes = nodes }, JsonRequestBehavior.AllowGet);
        }


        public EmptyResult UpdateNode(Node model)
        {
            var node = db.Nodes.First(p => p.Id == model.Id);
            node.Name = model.Name;
            node.Pid = model.Pid;
            db.SaveChanges();
            return new EmptyResult();
        }

        public EmptyResult RemoveNode(string id)
        {
            var node = db.Nodes.First(p => p.Id == id);
            db.Nodes.Remove(node);

            string parentId = node.Pid;

            var children = db.Nodes.Where(p => p.Pid == node.Id);
            foreach (var child in children)
            {
                child.Pid = node.Pid;
            }

            db.SaveChanges();
            return new EmptyResult();
        }

        public JsonResult AddNode(Node model)
        {
            Node node = new Node();
            node.Name = model.Name;
            node.Pid = model.Pid;
            db.Nodes.Add(node);

            db.SaveChanges();

            return Json(new { id = node.Id }, JsonRequestBehavior.AllowGet);
        }


    }
}
