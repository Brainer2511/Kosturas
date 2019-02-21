using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;
using Finanzas.Models;

namespace Finanzas.Controllers
{
    public class BDPersonalffsController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: BDPersonalffs
        public async Task<ActionResult> Index()
        {
            return View(await db.BDPersonalff.ToListAsync());
        }

        // GET: BDPersonalffs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDPersonalff bDPersonalff = await db.BDPersonalff.FindAsync(id);
            if (bDPersonalff == null)
            {
                return HttpNotFound();
            }
            return View(bDPersonalff);
        }

        // GET: BDPersonalffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BDPersonalffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BDPersonalff bDPersonalff)
        {
            if (ModelState.IsValid)
            {
                db.BDPersonalff.Add(bDPersonalff);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bDPersonalff);
        }

        // GET: BDPersonalffs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDPersonalff bDPersonalff = await db.BDPersonalff.FindAsync(id);
            if (bDPersonalff == null)
            {
                return HttpNotFound();
            }
            return View(bDPersonalff);
        }

        // POST: BDPersonalffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( BDPersonalff bDPersonalff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bDPersonalff).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bDPersonalff);
        }

        // GET: BDPersonalffs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BDPersonalff bDPersonalff = await db.BDPersonalff.FindAsync(id);
            if (bDPersonalff == null)
            {
                return HttpNotFound();
            }
            return View(bDPersonalff);
        }

        // POST: BDPersonalffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BDPersonalff bDPersonalff = await db.BDPersonalff.FindAsync(id);
            db.BDPersonalff.Remove(bDPersonalff);
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
