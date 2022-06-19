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
using CompetitionManager.Models.DTO;

namespace CompetitionManager.Controllers
{
    public class CompetitionController : Controller
    {
        private CompetitionContext db = new CompetitionContext();

        // GET: Competition
        public ActionResult Index()
        {

            var competitions = db.Competitions.Include(c => c.Game).Include(c => c.MainOrganizer).Include(c => c.Rulebook);
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
            ViewBag.GameID = new SelectList(db.Games, "ID", "Name");
            ViewBag.MainOrganizerID = new SelectList(db.MainOrganizers, "ID", "PESEL");
            ViewBag.RulebookID = new SelectList(db.Rulebooks, "ID", "Description");
            return View();
        }

        // POST: Competition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GameID,RegistrationStartDate,RegistrationEndDate,StartDate,EndDate,CurrentCompetitionState,MainOrganizerID")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competitions.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "ID", "Name", competition.GameID);
            ViewBag.MainOrganizerID = new SelectList(db.MainOrganizers, "ID", "PESEL", competition.MainOrganizerID);
            ViewBag.RulebookID = new SelectList(db.Rulebooks, "ID", "Description", competition.ID);
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
            ViewBag.GameID = new SelectList(db.Games, "ID", "Name", competition.GameID);
            ViewBag.MainOrganizerID = new SelectList(db.MainOrganizers, "ID", "PESEL", competition.MainOrganizerID);
            ViewBag.RulebookID = new SelectList(db.Rulebooks, "ID", "Description", competition.ID);
            PopulateAssignedHelperData(competition);
            return View(competition);
        }

        // POST: Competition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,string[] selectedHelpers)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var competition = db.Competitions.Find(id);
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                UpdateCompetitionHelpers(selectedHelpers, competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.GameID = new SelectList(db.Games, "ID", "Name", competition.GameID);
            ViewBag.MainOrganizerID = new SelectList(db.MainOrganizers, "ID", "PESEL", competition.MainOrganizerID);
            ViewBag.RulebookID = new SelectList(db.Rulebooks, "ID", "Description", competition.ID);
            PopulateAssignedHelperData(competition);
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
        [ActionName("CreateHelper")]
        public ActionResult CreateHelperOnCompetition(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dto = new HelperOnCompetitionDTO();
            dto.CompetitionId = id.Value;
            return View(dto);
        }

        // POST: Helper/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CreateHelper")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHelperOnCompetition(HelperOnCompetitionDTO helperOnCompetitionDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Helpers.Add(helperOnCompetitionDTO.Helper);
                    var c=db.Competitions.Find(helperOnCompetitionDTO.CompetitionId);
                    c.Helpers.Add(helperOnCompetitionDTO.Helper);
                    db.SaveChanges();
                    return RedirectToAction("Details/"+helperOnCompetitionDTO.CompetitionId);
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(helperOnCompetitionDTO);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void PopulateAssignedHelperData(Competition competition)
        {
            var allHelpers = db.Helpers;
            var competitionHelpers = new HashSet<int>(competition.Helpers.Select(c => c.ID));
            var viewModel = new List<AssignedHelperDTO>();
            foreach (var helper in allHelpers)
            {
                viewModel.Add(new AssignedHelperDTO
                {
                    HelperID = helper.ID,
                    FirstName = helper.FirstName,
                    LastName=helper.LastName,
                    Assigned = competitionHelpers.Contains(helper.ID)
                });
            }
            ViewBag.Helpers = viewModel;
        }
        private void UpdateCompetitionHelpers(string[] selectedHelpers, Competition competitionToUpdate)
        {
            if (selectedHelpers == null)
            {
                competitionToUpdate.Helpers = new List<Helper>();
                return;
            }


            var selectedHelpersHS = new HashSet<string>(selectedHelpers);
            var competitionHelpers = new HashSet<int>
                (db.Competitions.Find(competitionToUpdate.ID).Helpers.Select(c => c.ID));
            foreach (Helper helper in db.Helpers)
            {
                if (selectedHelpersHS.Contains(helper.ID.ToString()))
                {
                    if (!competitionHelpers.Contains(helper.ID))
                    {
                        competitionToUpdate.Helpers.Add(helper);
                    }
                }
                else
                {
                    if (competitionHelpers.Contains(helper.ID))
                    {
                        competitionToUpdate.Helpers.Remove(helper);
                    }
                }
                
            }
        }
    }
}
