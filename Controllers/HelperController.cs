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
    public class HelperController : Controller
    {
        private CompetitionContext db = new CompetitionContext();

        // GET: Helper
        public ActionResult Index()
        {
            return View(db.Helpers.ToList());
        }

        // GET: Helper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helper helper = db.Helpers.Find(id);
            if (helper == null)
            {
                return HttpNotFound();
            }
            return View(helper);
        }

        // GET: Helper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Helper/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PESEL,Address,Email,FirstName,LastName")] Helper helper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Helpers.Add(helper);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(helper);
        }

        // GET: Helper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Helper helper = db.Helpers.Find(id);
            if (helper == null)
            {
                return HttpNotFound();
            }
            return View(helper);
        }

        // POST: Helper/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PESEL,Address,Email,FirstName,LastName")] Helper helper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Update failed. Try again, and if the problem persists see your system administrator.";
            }
            return View(helper);
        }

        // GET: Helper/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Helper helper = db.Helpers.Find(id);
            if (helper == null)
            {
                return HttpNotFound();
            }
            return View(helper);
        }

        // POST: Helper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Helper helper = db.Helpers.Find(id);
            db.Helpers.Remove(helper);
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
