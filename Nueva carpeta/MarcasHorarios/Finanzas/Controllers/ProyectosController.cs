using Domain;
using Finanzas.Models;
using Finanzas.ViewModels;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Finanzas.Controllers
{
    public class ProyectosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.Proyectos.ToListAsync());
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
                Proyecto proyecto = await db.Proyectos.FindAsync(id);
                if (proyecto == null)
                {
                    return HttpNotFound();
                }
                return View(proyecto);
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
                return View(new ProyectoViewModel { Fecha=DateTime.Today, sFecha=DateTime.Today.ToString("dd/MM/yyyy")});
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProyectoViewModel view)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(view.sFecha))
                    {
                        view.Fecha = DateTime.ParseExact(view.sFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    Proyecto proyecto = ToProyecto(view);
                    db.Proyectos.Add(proyecto);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(view);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Proyecto ToProyecto(ProyectoViewModel view)
        {
            return new Proyecto
            {
                Activo=view.Activo,
                Codigo=view.Codigo,
                Descripcion=view.Descripcion,
                Nombre=view.Nombre,
                ProyectoId=view.ProyectoId,
                Fecha=view.Fecha
            };
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
                Proyecto proyecto = await db.Proyectos.FindAsync(id);
                if (proyecto == null)
                {
                    return HttpNotFound();
                }

                ProyectoViewModel view = ToView(proyecto);
                return View(view);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ProyectoViewModel ToView(Proyecto proyecto)
        {
            return new ProyectoViewModel
            {
                Activo=proyecto.Activo,
                Codigo=proyecto.Codigo,
                Descripcion=proyecto.Descripcion,
                Fecha=proyecto.Fecha,
                Nombre=proyecto.Nombre,
                ProyectoId=proyecto.ProyectoId,
                sFecha=proyecto.Fecha.ToString("dd/MM/yyyy")
            };
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProyectoViewModel view)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(view.sFecha))
                {
                    view.Fecha = DateTime.ParseExact(view.sFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                Proyecto proyecto = ToProyecto(view);
                db.Entry(proyecto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
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
                Proyecto proyecto = await db.Proyectos.FindAsync(id);
                if (proyecto == null)
                {
                    return HttpNotFound();
                }

                db.Proyectos.Remove(proyecto);
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
