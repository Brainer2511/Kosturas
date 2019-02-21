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
    public class NacionalidadesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.Nacionalidades.ToListAsync());
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
                Nacionalidad nacionalidad = await db.Nacionalidades.FindAsync(id);
                if (nacionalidad == null)
                {
                    return HttpNotFound();
                }
                return View(nacionalidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Nacionalidad nacionalidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Nacionalidades.Add(nacionalidad);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(nacionalidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Nacionalidad nacionalidad = await db.Nacionalidades.FindAsync(id);
                if (nacionalidad == null)
                {
                    return HttpNotFound();
                }
                return View(nacionalidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Nacionalidad nacionalidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(nacionalidad).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(nacionalidad);
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
                Nacionalidad nacionalidad = await db.Nacionalidades.FindAsync(id);
                if (nacionalidad == null)
                {
                    return HttpNotFound();
                }

                db.Nacionalidades.Remove(nacionalidad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
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
