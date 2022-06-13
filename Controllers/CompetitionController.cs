using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompetitionManager.DAL;
using CompetitionManager.Models;

namespace CompetitionManager.Controllers
{
    public class CompetitionController : Controller
    {
        private CompetitionContext db = new CompetitionContext();
        public CompetitionController()
        {
            System.Diagnostics.Debug.WriteLine("aasdasdasdsadasdsadsadsadx");
        }
        
        // GET: Competition
        public ActionResult Index()
        {
            var competitions = db.Competitions
                .Include(c => c.Rulebook)
                .Include(x => x.Game);
            return View(competitions.ToList());
        }

        // GET: Competition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // GET: Competition/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Rulebooks, "ID", "Description");
            return View();
        }

        // POST: Competition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RegistrationStartDate,RegistrationEndDate,StartDate,EndDate,CurrentCompetitionState")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competitions.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Rulebooks, "ID", "Description", competition.ID);
            return View(competition);
        }

        // GET: Competition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Rulebooks, "ID", "Description", competition.ID);
            return View(competition);
        }

        // POST: Competition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RegistrationStartDate,RegistrationEndDate,StartDate,EndDate,CurrentCompetitionState")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Rulebooks, "ID", "Description", competition.ID);
            return View(competition);
        }

        // GET: Competition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: Competition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competitions.Find(id);
            db.Competitions.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void Test()
        {
            System.Diagnostics.Debug.WriteLine("Controller-------------------------------------------");
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
