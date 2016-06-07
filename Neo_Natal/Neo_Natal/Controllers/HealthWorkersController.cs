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
    public class HealthWorkersController : Controller
    {
        private Neo_NatalDB db = new Neo_NatalDB();

        // GET: HealthWorkers
        public ActionResult Index()
        {
            ViewBag.Clients = db.Clients.ToList(); //later <--get current HealthWorker 
            return View(db.HealthWorkers.ToList()); //take out later 

        }

        //GET PARTIAL VIEW HealthWorkers/Index
        public ViewResult _ClientInfo()
        {
            return View("_ClientInfo");
        }

        // GET: HealthWorkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthWorker healthWorker = db.HealthWorkers.Find(id);
            if (healthWorker == null)
            {
                return HttpNotFound();
            }
            return View(healthWorker);
        }

        // GET: HealthWorkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HealthWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,email")] HealthWorker healthWorker)
        {
            if (ModelState.IsValid)
            {
                db.HealthWorkers.Add(healthWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(healthWorker);
        }

        // GET: HealthWorkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthWorker healthWorker = db.HealthWorkers.Find(id);
            if (healthWorker == null)
            {
                return HttpNotFound();
            }
            return View(healthWorker);
        }

        // POST: HealthWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,email")] HealthWorker healthWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healthWorker);
        }

        // GET: HealthWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthWorker healthWorker = db.HealthWorkers.Find(id);
            if (healthWorker == null)
            {
                return HttpNotFound();
            }
            return View(healthWorker);
        }

        // POST: HealthWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthWorker healthWorker = db.HealthWorkers.Find(id);
            db.HealthWorkers.Remove(healthWorker);
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
