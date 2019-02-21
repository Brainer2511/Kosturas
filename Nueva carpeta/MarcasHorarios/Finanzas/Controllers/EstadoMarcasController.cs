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
    public class EstadoMarcasController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.EstadoMarcas.ToListAsync());
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
                EstadoMarca estadoMarca = await db.EstadoMarcas.FindAsync(id);
                if (estadoMarca == null)
                {
                    return HttpNotFound();
                }
                return View(estadoMarca);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EstadoMarca estadoMarca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.EstadoMarcas.Add(estadoMarca);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(estadoMarca);
            }
            catch (Exception)
            {

                return View(estadoMarca);
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
                EstadoMarca estadoMarca = await db.EstadoMarcas.FindAsync(id);
                if (estadoMarca == null)
                {
                    return HttpNotFound();
                }
                return View(estadoMarca);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EstadoMarca estadoMarca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(estadoMarca).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(estadoMarca);
            }
            catch (Exception)
            {

                return View(estadoMarca);
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
                EstadoMarca estadoMarca = await db.EstadoMarcas.FindAsync(id);
                if (estadoMarca == null)
                {
                    return HttpNotFound();
                }

                db.EstadoMarcas.Remove(estadoMarca);
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
