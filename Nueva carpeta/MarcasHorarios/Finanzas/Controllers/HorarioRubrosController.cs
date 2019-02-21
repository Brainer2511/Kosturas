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
    public class HorarioRubrosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.HorarioRubros.ToListAsync());
            }
            catch
            {

                return View(new List<HorarioRubro>());
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
                HorarioRubro horarioRubro = await db.HorarioRubros.FindAsync(id);
                if (horarioRubro == null)
                {
                    return HttpNotFound();
                }
                return View(horarioRubro);
            }
            catch (Exception)
            {
                return View(new HorarioRubro());
            }
        }

        [HandleError]
        public ActionResult Create()
        {
            return View();
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( HorarioRubro horarioRubro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.HorarioRubros.Add(horarioRubro);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(horarioRubro);
            }
            catch (Exception)
            {

                return View(horarioRubro);
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
                HorarioRubro horarioRubro = await db.HorarioRubros.FindAsync(id);
                if (horarioRubro == null)
                {
                    return HttpNotFound();
                }
                return View(horarioRubro);
            }
            catch
            {
                return View(new HorarioRubro());
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HorarioRubro horarioRubro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(horarioRubro).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(horarioRubro);
            }
            catch 
            {
                return View(horarioRubro);
            }
        }

        [HandleError]
        [HandleError]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                HorarioRubro horarioRubro = await db.HorarioRubros.FindAsync(id);
                if (horarioRubro == null)
                {
                    return HttpNotFound();
                }
                db.HorarioRubros.Remove(horarioRubro);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
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
