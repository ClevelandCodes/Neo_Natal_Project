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
    public class clientsController : Controller
    {
        private neo_natalEntities db = new neo_natalEntities();

        // GET: clients
        public ActionResult Index()
        {
            var clients = db.clients.Include(c => c.health_worker);
            return View(clients.ToList());
        }

        // GET: clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: clients/Create
        public ActionResult Create()
        {
            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username");
            return View();
        }

        // POST: clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,DOB,street_number,street_name,zip_code,county,ward,phone_number,email,health_worker_id")] client client)
        {
            if (ModelState.IsValid)
            {
                db.clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username", client.health_worker_id);
            return View(client);
        }

        // GET: clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username", client.health_worker_id);
            return View(client);
        }

        // POST: clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,DOB,street_number,street_name,zip_code,county,ward,phone_number,email,health_worker_id")] client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username", client.health_worker_id);
            return View(client);
        }

        // GET: clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            client client = db.clients.Find(id);
            db.clients.Remove(client);
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
