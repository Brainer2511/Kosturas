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
    public class MarcasController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            var marcas = db.Marcas.Include(m => m.Persona).Include(m => m.Ubicacion);
            return View(await marcas.ToListAsync());
        }

        [HandleError]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = await db.Marcas.FindAsync(id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }

        [HandleError]
        public ActionResult Create()
        {
            try
            {
                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "ADMCC");
                ViewBag.UbicacionId = new SelectList(db.Ubicaciones, "UbicacionId", "Nombre");
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Marca marca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Marcas.Add(marca);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "ADMCC", marca.PersonaId);
                ViewBag.UbicacionId = new SelectList(db.Ubicaciones, "UbicacionId", "Nombre", marca.UbicacionId);
                return View(marca);
            }
            catch (Exception)
            {
                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "ADMCC", marca.PersonaId);
                ViewBag.UbicacionId = new SelectList(db.Ubicaciones, "UbicacionId", "Nombre", marca.UbicacionId);
                return View(marca);
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
                Marca marca = await db.Marcas.FindAsync(id);
                if (marca == null)
                {
                    return HttpNotFound();
                }
                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "ADMCC", marca.PersonaId);
                ViewBag.UbicacionId = new SelectList(db.Ubicaciones, "UbicacionId", "Nombre", marca.UbicacionId);
                return View(marca);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Marca marca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(marca).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "ADMCC", marca.PersonaId);
                ViewBag.UbicacionId = new SelectList(db.Ubicaciones, "UbicacionId", "Nombre", marca.UbicacionId);
                return View(marca);
            }
            catch (Exception)
            {

                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "ADMCC", marca.PersonaId);
                ViewBag.UbicacionId = new SelectList(db.Ubicaciones, "UbicacionId", "Nombre", marca.UbicacionId);
                return View(marca);
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
                Marca marca = await db.Marcas.FindAsync(id);
                if (marca == null)
                {
                    return HttpNotFound();
                }

                db.Marcas.Remove(marca);
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
