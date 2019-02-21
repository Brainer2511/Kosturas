using Domain;
using Finanzas.Models;
using Finanzas.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Finanzas.Controllers
{
    public class HorarioPersonasController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            try
            {
                var horarioPersonas = db.HorarioPersonas.Include(h => h.Persona).Include(h=>h.HorarioRubro);
                return View(await horarioPersonas.ToListAsync());
            }
            catch (Exception)
            {
                return View(new List<HorarioPersona>());
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
                HorarioPersona horarioPersona = await db.HorarioPersonas.FindAsync(id);
                if (horarioPersona == null)
                {
                    return HttpNotFound();
                }
                return View(horarioPersona);
            }
            catch (Exception)
            {
                return View(new HorarioPersona());
            }
        }

        [HandleError]
        public ActionResult Create()
        {
            try
            {
                var list = db.Personas.ToList();
                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "NombreCompleto");
                ViewBag.HorarioRubroId = new SelectList(db.HorarioRubros, "HorarioRubroId", "Nombre");
                return View(new HorarioPersonaViewModel { Duracion=0, Fecha=DateTime.Today, Hora=TimeSpan.MinValue, sFecha=DateTime.Today.ToString("dd/MM/yyyy"), sHora=TimeSpan.MinValue.ToString("HH:mm") });
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HorarioPersonaViewModel view)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(view.sFecha))
                    {
                        view.Fecha = DateTime.ParseExact(view.sFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    if (!string.IsNullOrEmpty(view.sHora))
                    {
                        view.Hora = TimeSpan.ParseExact(view.sHora, "g", CultureInfo.InvariantCulture, TimeSpanStyles.AssumeNegative);
                    }
                    HorarioPersona horarioPersona = new HorarioPersona();
                    AutoMapper.Mapper.Map(view, horarioPersona);
                    db.HorarioPersonas.Add(horarioPersona);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }               
            }
            catch (Exception)
            {
            }

            ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "NombreCompleto", view.PersonaId);
            ViewBag.HorarioRubroId = new SelectList(db.HorarioRubros, "HorarioRubroId", "Nombre", view.HorarioRubroId);
            return View(view);
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
                HorarioPersona horarioPersona = await db.HorarioPersonas.FindAsync(id);
                if (horarioPersona == null)
                {
                    return HttpNotFound();
                }
                ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "NombreCompleto", horarioPersona.PersonaId);
                ViewBag.HorarioRubroId = new SelectList(db.HorarioRubros, "HorarioRubroId", "Nombre", horarioPersona.HorarioRubroId);

                HorarioPersonaViewModel view = new HorarioPersonaViewModel();
                AutoMapper.Mapper.Map(horarioPersona, view);
                return View(view);
            }
            catch (Exception)
            {
                return View(new HorarioPersonaViewModel());
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HorarioPersonaViewModel view)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(view.sFecha))
                    {
                        view.Fecha = DateTime.ParseExact(view.sFecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    if (!string.IsNullOrEmpty(view.sHora))
                    {
                        view.Hora = TimeSpan.ParseExact(view.sHora, "HH:mm", CultureInfo.InvariantCulture);
                    }
                    HorarioPersona horarioPersona = new HorarioPersona();
                    AutoMapper.Mapper.Map(view, horarioPersona);
                    db.Entry(horarioPersona).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }              
            }
            catch (Exception)
            {              
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "PersonaId", "NombreCompleto", view.PersonaId);
            ViewBag.HorarioRubroId = new SelectList(db.HorarioRubros, "HorarioRubroId", "Nombre", view.HorarioRubroId);
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
                HorarioPersona horarioPersona = await db.HorarioPersonas.FindAsync(id);
                if (horarioPersona == null)
                {
                    return HttpNotFound();
                }

                db.HorarioPersonas.Remove(horarioPersona);
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
