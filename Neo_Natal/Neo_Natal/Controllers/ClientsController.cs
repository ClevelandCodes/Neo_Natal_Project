using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Neo_Natal.Models;

namespace Neo_Natal.Controllers
{
    public class ClientsController : Controller
    {
        private Neo_NatalDB db = new Neo_NatalDB();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.HealthWorker).Include(c => c.Survey);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.healthworker_id = new SelectList(db.HealthWorkers, "id", "username");
            ViewBag.id = new SelectList(db.Surveys, "client_id", "client_id");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,healthworker_id,first_name,last_name,DOB,ethnicity,street_number,street_name,city,zip_code,county,ward,phone,email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.healthworker_id = new SelectList(db.HealthWorkers, "id", "username", client.healthworker_id);
            ViewBag.id = new SelectList(db.Surveys, "client_id", "client_id", client.id);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.healthworker_id = new SelectList(db.HealthWorkers, "id", "username", client.healthworker_id);
            ViewBag.id = new SelectList(db.Surveys, "client_id", "client_id", client.id);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,healthworker_id,first_name,last_name,DOB,ethnicity,street_number,street_name,city,zip_code,county,ward,phone,email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.healthworker_id = new SelectList(db.HealthWorkers, "id", "username", client.healthworker_id);
            ViewBag.id = new SelectList(db.Surveys, "client_id", "client_id", client.id);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
