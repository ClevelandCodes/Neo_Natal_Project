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
    public class surveysController : Controller
    {
        private neo_natalEntities db = new neo_natalEntities();

        // GET: surveys
        public ActionResult Index()
        {
            var surveys = db.surveys.Include(s => s.client).Include(s => s.health_worker);
            return View(surveys.ToList());
        }

        // GET: surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            survey survey = db.surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: surveys/Create
        public ActionResult Create()
        {
            ViewBag.client_id = new SelectList(db.clients, "id", "first_name");
            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username");
            return View();
        }

        // POST: surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,health_worker_id,client_id,question_1,quesiton_2,question_3,question_4,question_5,question_6,question_7,question_8,question_9,question_10,question_11,question_12,question_13,question_14,question_15,question_16,question_17,question_18,question_19,question_20,quesiton_21,question_22,quesiton_23,question_24,question_25")] survey survey)
        {
            if (ModelState.IsValid)
            {
                db.surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_id = new SelectList(db.clients, "id", "first_name", survey.client_id);
            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username", survey.health_worker_id);
            return View(survey);
        }

        // GET: surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            survey survey = db.surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_id = new SelectList(db.clients, "id", "first_name", survey.client_id);
            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username", survey.health_worker_id);
            return View(survey);
        }

        // POST: surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,health_worker_id,client_id,question_1,quesiton_2,question_3,question_4,question_5,question_6,question_7,question_8,question_9,question_10,question_11,question_12,question_13,question_14,question_15,question_16,question_17,question_18,question_19,question_20,quesiton_21,question_22,quesiton_23,question_24,question_25")] survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_id = new SelectList(db.clients, "id", "first_name", survey.client_id);
            ViewBag.health_worker_id = new SelectList(db.health_worker, "id", "username", survey.health_worker_id);
            return View(survey);
        }

        // GET: surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            survey survey = db.surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            survey survey = db.surveys.Find(id);
            db.surveys.Remove(survey);
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
