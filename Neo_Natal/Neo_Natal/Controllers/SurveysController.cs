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
    public class SurveysController : Controller
    {
        private Neo_NatalDB db = new Neo_NatalDB();

        // GET: Surveys
        public ActionResult Index()
        {
            var surveys = db.Surveys.Include(s => s.Client);
            return View(surveys.ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "client_id,risk_score,Q1_address,Q2_zip_code,Q3_race,Q4_ward,Q5_first_child,Q6_prem_birth,Q7_obgyn,Q8_age,Q9_stress,Q10_smoker,Q11_fam_smoker,Q12_alcohol,Q13_fam_alcohol,Q14_fam_drug,Q15_drug,Q16_safe_nbhood,Q17_safe_home,Q18_illness,Q19_transport,Q20_internet,Q21_mob_internet,Q22_diet,Q23_gov_assist,Q24_rel_income,Q25_education")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name", survey.client_id);
            return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name", survey.client_id);
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "client_id,risk_score,Q1_address,Q2_zip_code,Q3_race,Q4_ward,Q5_first_child,Q6_prem_birth,Q7_obgyn,Q8_age,Q9_stress,Q10_smoker,Q11_fam_smoker,Q12_alcohol,Q13_fam_alcohol,Q14_fam_drug,Q15_drug,Q16_safe_nbhood,Q17_safe_home,Q18_illness,Q19_transport,Q20_internet,Q21_mob_internet,Q22_diet,Q23_gov_assist,Q24_rel_income,Q25_education")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_id = new SelectList(db.Clients, "id", "first_name", survey.client_id);
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
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
