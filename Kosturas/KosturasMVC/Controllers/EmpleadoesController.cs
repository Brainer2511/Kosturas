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

namespace KosturasMVC.Controllers
{
    public class EmpleadoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Empleadoes
        public async Task<ActionResult> Index()
        {
            return View(await db.Empleados.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmpleadoId,Nombre,Apellidos,Alias,Email,Activo,Usuario,Clave,RecibirInforme,ResivirNotifica,EditPagina,EditSegundaPagina,ApcederTarjeta,EditCreditoClinte,EditPuntosClinte,AbrirCajon,desdelunes,desdemartes,desdemiercoles,desdejueves,desdeviernes,desdesabado,desdedomingo,hastalunes,hastamartes,hastamiercoles,hastajueves,hastaviernes,hastasabado,hastadomingo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmpleadoId,Nombre,Apellidos,Alias,Email,Activo,Usuario,Clave,RecibirInforme,ResivirNotifica,EditPagina,EditSegundaPagina,ApcederTarjeta,EditCreditoClinte,EditPuntosClinte,AbrirCajon,desdelunes,desdemartes,desdemiercoles,desdejueves,desdeviernes,desdesabado,desdedomingo,hastalunes,hastamartes,hastamiercoles,hastajueves,hastaviernes,hastasabado,hastadomingo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = await db.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empleado empleado = await db.Empleados.FindAsync(id);
            db.Empleados.Remove(empleado);
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
