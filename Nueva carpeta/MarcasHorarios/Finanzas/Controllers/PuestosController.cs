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
    public class PuestosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.Puestos.ToListAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Puesto puesto = await db.Puestos.FindAsync(id);
                if (puesto == null)
                {
                    return HttpNotFound();
                }
                return View(puesto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public ActionResult Create()
        {
            return View(new Puesto { Horas=9});
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Puesto puesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Puestos.Add(puesto);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(puesto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto puesto = await db.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Puesto puesto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(puesto).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(puesto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Puesto puesto = await db.Puestos.FindAsync(id);
                if (puesto == null)
                {
                    return HttpNotFound();
                }

                db.Puestos.Remove(puesto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
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
