using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeoNatal1.Models;

namespace NeoNatal1.Controllers
{
    public class health_workerController : Controller
    {
        private neo_natalEntities db = new neo_natalEntities();

        // GET: health_worker
        public ActionResult Index()
        {
            var health_worker = db.health_worker.Include(h => h.client);
            return View(health_worker.ToList());
        }

        // GET: health_worker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            health_worker health_worker = db.health_worker.Find(id);
            if (health_worker == null)
            {
                return HttpNotFound();
            }
            return View(health_worker);
        }

        // GET: health_worker/Create
        public ActionResult Create()
        {
            ViewBag.client_id = new SelectList(db.surveys, "id", "first_name");
            return View();
        }

        // POST: health_worker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,email,password,client_id")] health_worker health_worker)
        {
            if (ModelState.IsValid)
            {
                db.health_worker.Add(health_worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_id = new SelectList(db.clients, "id", "first_name", health_worker.client_id);
            return View(health_worker);
        }

        // GET: health_worker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            health_worker health_worker = db.health_worker.Find(id);
            if (health_worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_id = new SelectList(db.clients, "id", "first_name", health_worker.client_id);
            return View(health_worker);
        }

        // POST: health_worker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,email,password,client_id")] health_worker health_worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(health_worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_id = new SelectList(db.clients, "id", "first_name", health_worker.client_id);
            return View(health_worker);
        }

        // GET: health_worker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            health_worker health_worker = db.health_worker.Find(id);
            if (health_worker == null)
            {
                return HttpNotFound();
            }
            return View(health_worker);
        }

        // POST: health_worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            health_worker health_worker = db.health_worker.Find(id);
            db.health_worker.Remove(health_worker);
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
    }
}
