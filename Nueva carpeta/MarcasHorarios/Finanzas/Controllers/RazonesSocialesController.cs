using Domain;
using Finanzas.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Finanzas.Controllers
{
    public class RazonesSocialesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            return View(await db.RazonesSociales.ToListAsync());
        }

        [HandleError]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazonSocial razonSocial = await db.RazonesSociales.FindAsync(id);
            if (razonSocial == null)
            {
                return HttpNotFound();
            }
            return View(razonSocial);
        }

        [HandleError]
        public ActionResult Create()
        {
            return View();
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RazonSocial razonSocial)
        {
            if (ModelState.IsValid)
            {
                db.RazonesSociales.Add(razonSocial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(razonSocial);
        }

        [HandleError]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazonSocial razonSocial = await db.RazonesSociales.FindAsync(id);
            if (razonSocial == null)
            {
                return HttpNotFound();
            }
            return View(razonSocial);
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RazonSocial razonSocial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(razonSocial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(razonSocial);
        }

        [HandleError]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazonSocial razonSocial = await db.RazonesSociales.FindAsync(id);
            if (razonSocial == null)
            {
                return HttpNotFound();
            }

            db.RazonesSociales.Remove(razonSocial);
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
