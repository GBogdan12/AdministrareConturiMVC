using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Licenta.Models;

namespace Licenta.Controllers
{
    public class DosarController : Controller
    {
        private dbLicentaEntities db = new dbLicentaEntities();

        // GET: Dosar
        public ActionResult Index()
        {
            var dosars = db.Dosars.Include(d => d.City).Include(d => d.Company).Include(d => d.TribunalD);
            return View(dosars.ToList());
        }

        // GET: Dosar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosar dosar = db.Dosars.Find(id);
            if (dosar == null)
            {
                return HttpNotFound();
            }
            return View(dosar);
        }

        // GET: Dosar/Create
        public ActionResult Create()
        {
            ViewBag.OrasId = new SelectList(db.Cities, "Id", "Denumire");
            ViewBag.Companie = new SelectList(db.Companies, "Id", "Denumire");
            ViewBag.IdTribunal = new SelectList(db.TribunalDs, "Id", "Nume");
            return View();
        }

        // POST: Dosar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumePart1,NumePart2,IdTribunal,DataDosar,Stadiu,Obiect,Complet,Actualizare,DataUrmatoareSedinta,TipSolutie,Companie,OrasId,NumarDosar")] Dosar dosar)
        {
            if (ModelState.IsValid)
            {
                db.Dosars.Add(dosar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrasId = new SelectList(db.Cities, "Id", "Denumire", dosar.OrasId);
            ViewBag.Companie = new SelectList(db.Companies, "Id", "Denumire", dosar.Companie);
            ViewBag.IdTribunal = new SelectList(db.TribunalDs, "Id", "Nume", dosar.IdTribunal);
            return View(dosar);
        }

        // GET: Dosar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosar dosar = db.Dosars.Find(id);
            if (dosar == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrasId = new SelectList(db.Cities, "Id", "Denumire", dosar.OrasId);
            ViewBag.Companie = new SelectList(db.Companies, "Id", "Denumire", dosar.Companie);
            ViewBag.IdTribunal = new SelectList(db.TribunalDs, "Id", "Nume", dosar.IdTribunal);
            return View(dosar);
        }

        // POST: Dosar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumePart1,NumePart2,IdTribunal,DataDosar,Stadiu,Obiect,Complet,Actualizare,DataUrmatoareSedinta,TipSolutie,Companie,OrasId,NumarDosar")] Dosar dosar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dosar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrasId = new SelectList(db.Cities, "Id", "Denumire", dosar.OrasId);
            ViewBag.Companie = new SelectList(db.Companies, "Id", "Denumire", dosar.Companie);
            ViewBag.IdTribunal = new SelectList(db.TribunalDs, "Id", "Nume", dosar.IdTribunal);
            return View(dosar);
        }

        // GET: Dosar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosar dosar = db.Dosars.Find(id);
            if (dosar == null)
            {
                return HttpNotFound();
            }
            return View(dosar);
        }

        // POST: Dosar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dosar dosar = db.Dosars.Find(id);
            db.Dosars.Remove(dosar);
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
