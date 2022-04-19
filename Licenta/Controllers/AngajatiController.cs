using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Licenta.Models
{
    [Authorize(Roles = "Administrator")]
    public class AngajatiController : Controller
    {
        private dbLicentaEntities db = new dbLicentaEntities();

        // GET: Angajati
        public async Task<ActionResult> Index()
        {
            var userDs = db.UserDs.Include(u => u.Company).Include(u => u.AspNetUser);
            return View(await userDs.ToListAsync());
        }

        // GET: Angajati/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserD userD = await db.UserDs.FindAsync(id);
            if (userD == null)
            {
                return HttpNotFound();
            }
            return View(userD);
        }

        // GET: Angajati/Create
        public ActionResult Create()
        {
            ViewBag.CompanieId = new SelectList(db.Companies, "Id", "Denumire");
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Angajati/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CompanieId,Nume,Prenume,CNP,Oras,Judet,Adresa,SefIdD")] UserD userD)
        {
            if (ModelState.IsValid)
            {
                db.UserDs.Add(userD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanieId = new SelectList(db.Companies, "Id", "Denumire", userD.CompanieId);
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userD.Id);
            return View(userD);
        }

        // GET: Angajati/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserD userD = await db.UserDs.FindAsync(id);
            if (userD == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanieId = new SelectList(db.Companies, "Id", "Denumire", userD.CompanieId);
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userD.Id);
            return View(userD);
        }

        // POST: Angajati/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CompanieId,Nume,Prenume,CNP,Oras,Judet,Adresa,SefIdD")] UserD userD)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(userD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanieId = new SelectList(db.Companies, "Id", "Denumire", userD.CompanieId);
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", userD.Id);
            return View(userD);
        }




        // GET: Angajati/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserD userD = await db.UserDs.FindAsync(id);
            if (userD == null)
            {
                return HttpNotFound();
            }
            return View(userD);
        }

        // POST: Angajati/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            UserD userD = await db.UserDs.FindAsync(id);
            db.UserDs.Remove(userD);
            await db.SaveChangesAsync();
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
