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
using Finanzas.ViewModels;
using Finanzas.Helpers;

namespace Finanzas.Controllers
{
    public class PersonasController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        [HandleError]
        public async Task<ActionResult> Index()
        {
            try
            {
                var personas = db.Personas.Include(p => p.Distrito).Include(p => p.EstadoCivil).Include(p => p.Nacionalidad).Include(p => p.Puesto);
                return View(await personas.ToListAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        [HandleError]
        public ActionResult Create()
        {
            try
            {
                ViewBag.numeroProvincia = new SelectList(db.Provincias, "numeroProvincia", "Nombre");

                var list = db.Cantones.Where(c => c.numeroProvincia == db.Provincias.FirstOrDefault().numeroProvincia);

                ViewBag.numeroCanton = new SelectList(list, "numeroCanton", "Nombre");

                ViewBag.numeroDistrito = new SelectList(db.Distritos.Where(c => c.numeroCanton == list.FirstOrDefault().numeroCanton),
                    "numeroDistrito", "Nombre");

                var generos = new List<SelectListItem>();
                generos.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
                generos.Add(new SelectListItem { Text = "Femenino", Value = "Femenino" });
                ViewBag.Genero = new SelectList(generos, "Text", "Value");

                var roles = new List<SelectListItem>();
                roles.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
                roles.Add(new SelectListItem { Text = "Supervisor", Value = "Supervisor" });
                roles.Add(new SelectListItem { Text = "Agente", Value = "Agente" });
                ViewBag.Role = new SelectList(roles, "Text", "Value");


                ViewBag.SupervisorId = new SelectList(db.Personas, "PersonaId", "Nombre");
                ViewBag.EstadoCivilId = new SelectList(db.EstadosCiviles, "EstadoCivilId", "Nombre");
                ViewBag.NacionalidadId = new SelectList(db.Nacionalidades, "NacionalidadId", "Nombre");
                ViewBag.PuestoId = new SelectList(db.Puestos.Where(p => p.Activo), "PuestoId", "Nombre");
                ViewBag.RazonSocialId = new SelectList(db.RazonesSociales.Where(r=>r.Activo), "RazonSocialId", "Nombre");
                return View(new PersonaViewModel() { FechaIngreso=DateTime.Today});
            }
            catch (Exception)
            {
                return View(new PersonaViewModel());
            }
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonaViewModel view)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Personas";
                    if (!string.IsNullOrEmpty(view.sFechaNacimiento))
                    {
                        view.FechaNacimiento = DateTime.Parse(view.sFechaNacimiento);
                    }
                    if (!string.IsNullOrEmpty(view.sFechaSalida))
                    {
                        view.FechaSalida = DateTime.Parse(view.sFechaNacimiento);
                    }
                    view.FechaIngreso = DateTime.Today;
                    if (view.ImagenFile != null)
                    {
                        pic = FilesHelper.UploadPhoto(view.ImagenFile, folder);
                        pic = string.Format("{0}/{1}", folder, pic);
                    }

                    Persona persona = ToPersona(view);
                    persona.Imagen = pic;
                    db.Personas.Add(persona);
                    await db.SaveChangesAsync();
                    UsersHelper.CreateUserASP(view.Usuario, view.Role, view.Contrasena);
                    return RedirectToAction("Index");
                }
                ViewBag.numeroProvincia = new SelectList(db.Provincias, "numeroProvincia", "Nombre", view.numeroProvincia);

                var list = db.Cantones.Where(c => c.numeroProvincia == view.numeroProvincia);

                ViewBag.numeroCanton = new SelectList(list, "numeroCanton", "Nombre", view.numeroCanton);

                ViewBag.numeroDistrito = new SelectList(db.Distritos.Where(c => c.numeroCanton == view.numeroCanton && c.numeroProvincia == view.numeroProvincia),
                    "numeroDistrito", "Nombre", view.numeroDistrito);

                var generos = new List<SelectListItem>();
                generos.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
                generos.Add(new SelectListItem { Text = "Femenino", Value = "Femenino" });
                ViewBag.Genero = new SelectList(generos, "Text", "Value", view.Genero);

                var roles = new List<SelectListItem>();
                roles.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
                roles.Add(new SelectListItem { Text = "Supervisor", Value = "Supervisor" });
                roles.Add(new SelectListItem { Text = "Agente", Value = "Agente" });
                ViewBag.Role = new SelectList(roles, "Text", "Value", view.Role);

                ViewBag.EstadoCivilId = new SelectList(db.EstadosCiviles, "EstadoCivilId", "Nombre", view.EstadoCivilId);
                ViewBag.NacionalidadId = new SelectList(db.Nacionalidades, "NacionalidadId", "Nombre", view.NacionalidadId);
                ViewBag.PuestoId = new SelectList(db.Puestos.Where(p => p.Activo), "PuestoId", "Nombre", view.PuestoId);
                ViewBag.SupervisorId = new SelectList(db.Personas, "PersonaId", "Nombre", view.SupervisorId);
                ViewBag.RazonSocialId = new SelectList(db.RazonesSociales.Where(p => p.Activo), "RazonSocialId", "Nombre", view.RazonSocialId);

                return View(view);
            }
            catch (Exception ex)
            {
                if (ex.InnerException==null)
                {
                    ViewBag.Error = ex.Message.ToString();
                }
                else
                {
                    ViewBag.Error = ex.InnerException.InnerException.Message.ToString();
                }
                ViewBag.numeroProvincia = new SelectList(db.Provincias, "numeroProvincia", "Nombre", view.numeroProvincia);

                var list = db.Cantones.Where(c => c.numeroProvincia == view.numeroProvincia);

                ViewBag.numeroCanton = new SelectList(list, "numeroCanton", "Nombre", view.numeroCanton);

                ViewBag.numeroDistrito = new SelectList(db.Distritos.Where(c => c.numeroCanton == view.numeroCanton && c.numeroProvincia == view.numeroProvincia),
                    "numeroDistrito", "Nombre", view.numeroDistrito);

                var generos = new List<SelectListItem>();
                generos.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
                generos.Add(new SelectListItem { Text = "Femenino", Value = "Femenino" });
                ViewBag.Genero = new SelectList(generos, "Text", "Value", view.Genero);

                var roles = new List<SelectListItem>();
                roles.Add(new SelectListItem { Text = "Administrador", Value = "Administrador" });
                roles.Add(new SelectListItem { Text = "Supervisor", Value = "Supervisor" });
                roles.Add(new SelectListItem { Text = "Agente", Value = "Agente" });
                ViewBag.Role = new SelectList(roles, "Text", "Value", view.Role);

                ViewBag.EstadoCivilId = new SelectList(db.EstadosCiviles, "EstadoCivilId", "Nombre", view.EstadoCivilId);
                ViewBag.NacionalidadId = new SelectList(db.Nacionalidades, "NacionalidadId", "Nombre", view.NacionalidadId);
                ViewBag.PuestoId = new SelectList(db.Puestos.Where(p => p.Activo), "PuestoId", "Nombre", view.PuestoId);
                ViewBag.SupervisorId = new SelectList(db.Personas, "PersonaId", "Nombre", view.SupervisorId);
                ViewBag.RazonSocialId = new SelectList(db.RazonesSociales.Where(p => p.Activo), "RazonSocialId", "Nombre", view.RazonSocialId);
                return View(view);
            }
        }

        private Persona ToPersona(PersonaViewModel view)
        {
            return new Persona
            {
                Activo=view.Activo,
                ADMCC=view.ADMCC,
                Apellidos=view.Apellidos,
                Bilingue=view.Bilingue,
                Celular=view.Celular,
                CuentaBanco=view.CuentaBanco,
                Direccion=view.Direccion,
                Email=view.Email,
                EstadoCivilId=view.EstadoCivilId,
                FechaIngreso=view.FechaIngreso,
                FechaNacimiento=view.FechaNacimiento,
                FechaSalida=view.FechaSalida,
                Genero=view.Genero,
                Identificacion=view.Identificacion,
                Imagen=view.Imagen,
                MarcaSP=view.MarcaSP,
                MarcaZAP=view.MarcaZAP,
                NacionalidadId=view.NacionalidadId,
                Nombre=view.Nombre,
                numeroCanton=view.numeroCanton,
                numeroDistrito=view.numeroDistrito,
                numeroProvincia=view.numeroProvincia,
                PersonaId=view.PersonaId,
                PuestoId=view.PuestoId,
                Salario=view.Salario,
                SupervisorId=view.SupervisorId,
                Telefono=view.Telefono,
                Usuario=view.Usuario,
                LoginId=view.LoginId,
                RazonSocialId=view.RazonSocialId,
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
                Persona persona = await db.Personas.FindAsync(id);
                if (persona == null)
                {
                    return HttpNotFound();
                }

                PersonaViewModel view = ToView(persona);

                ViewBag.numeroProvincia = new SelectList(db.Provincias, "numeroProvincia", "Nombre", view.numeroProvincia);

                var list = db.Cantones.Where(c => c.numeroProvincia == view.numeroProvincia);

                ViewBag.numeroCanton = new SelectList(list, "numeroCanton", "Nombre", view.numeroCanton);

                ViewBag.numeroDistrito = new SelectList(db.Distritos.Where(c => c.numeroCanton == view.numeroCanton && c.numeroProvincia == view.numeroProvincia),
                    "numeroDistrito", "Nombre", view.numeroDistrito);

                var generos = new List<SelectListItem>();
                generos.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
                generos.Add(new SelectListItem { Text = "Femenino", Value = "Femenino" });
                ViewBag.Genero = new SelectList(generos, "Text", "Value", view.Genero);

                ViewBag.EstadoCivilId = new SelectList(db.EstadosCiviles, "EstadoCivilId", "Nombre", view.EstadoCivilId);
                ViewBag.NacionalidadId = new SelectList(db.Nacionalidades, "NacionalidadId", "Nombre", view.NacionalidadId);
                ViewBag.PuestoId = new SelectList(db.Puestos.Where(p => p.Activo), "PuestoId", "Nombre", view.PuestoId);
                ViewBag.SupervisorId = new SelectList(db.Personas, "PersonaId", "Nombre", view.SupervisorId);
                ViewBag.RazonSocialId = new SelectList(db.RazonesSociales.Where(p => p.Activo), "RazonSocialId", "Nombre", view.RazonSocialId);
                view.Contrasena = "123456";
                view.ConfirmarContrasena = "123456";
                return View(view);
            }
            catch (Exception)
            {
                return View(new PersonaViewModel());
            }
        }

        private PersonaViewModel ToView(Persona persona)
        {
            return new PersonaViewModel
            {
                Activo = persona.Activo,
                ADMCC = persona.ADMCC,
                Apellidos = persona.Apellidos,
                Bilingue = persona.Bilingue,
                Celular = persona.Celular,
                CuentaBanco = persona.CuentaBanco,
                Direccion = persona.Direccion,
                Email = persona.Email,
                EstadoCivilId = persona.EstadoCivilId,
                FechaIngreso = persona.FechaIngreso,
                FechaNacimiento = persona.FechaNacimiento,
                FechaSalida = persona.FechaSalida,
                Genero = persona.Genero,
                Identificacion = persona.Identificacion,
                Imagen = persona.Imagen,
                MarcaSP = persona.MarcaSP,
                MarcaZAP = persona.MarcaZAP,
                NacionalidadId = persona.NacionalidadId,
                Nombre = persona.Nombre,
                numeroCanton = persona.numeroCanton,
                numeroDistrito = persona.numeroDistrito,
                numeroProvincia = persona.numeroProvincia,
                PersonaId = persona.PersonaId,
                PuestoId = persona.PuestoId,
                Salario = persona.Salario,
                SupervisorId = persona.SupervisorId,
                LoginId = persona.LoginId,
                RazonSocialId = persona.RazonSocialId,
                Distrito =persona.Distrito,
                EstadoCivil=persona.EstadoCivil,
                Nacionalidad=persona.Nacionalidad,
                Notificaciones=persona.Notificaciones,
                NotificacionesGenerales=persona.NotificacionesGenerales,
                Puesto=persona.Puesto,
                Subordinados=persona.Subordinados,
                Supervisor=persona.Supervisor,
                Telefono=persona.Telefono,
                Usuario=persona.Usuario,
            };
        }

        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PersonaViewModel view)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    var pic = view.Imagen;
                    var folder = "~/Content/Personas";
                    if (!string.IsNullOrEmpty(view.sFechaNacimiento))
                    {
                        view.FechaNacimiento = DateTime.Parse(view.sFechaNacimiento);
                    }
                    if (!string.IsNullOrEmpty(view.sFechaSalida))
                    {
                        view.FechaSalida = DateTime.Parse(view.sFechaNacimiento);
                    }
                    view.FechaIngreso = DateTime.Today;
                    if (view.ImagenFile != null)
                    {
                        pic = FilesHelper.UploadPhoto(view.ImagenFile, folder);
                        pic = string.Format("{0}/{1}", folder, pic);
                    }

                    Persona persona = ToPersona(view);
                    persona.Imagen = pic;
                    db.Entry(persona).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.numeroProvincia = new SelectList(db.Provincias, "numeroProvincia", "Nombre", view.numeroProvincia);

                var list = db.Cantones.Where(c => c.numeroProvincia == view.numeroProvincia);

                ViewBag.numeroCanton = new SelectList(list, "numeroCanton", "Nombre", view.numeroCanton);

                ViewBag.numeroDistrito = new SelectList(db.Distritos.Where(c => c.numeroCanton == view.numeroCanton && c.numeroProvincia == view.numeroProvincia),
                    "numeroDistrito", "Nombre", view.numeroDistrito);

                var generos = new List<SelectListItem>();
                generos.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
                generos.Add(new SelectListItem { Text = "Femenino", Value = "Femenino" });
                ViewBag.Genero = new SelectList(generos, "Text", "Value", view.Genero);

                ViewBag.EstadoCivilId = new SelectList(db.EstadosCiviles, "EstadoCivilId", "Nombre", view.EstadoCivilId);
                ViewBag.NacionalidadId = new SelectList(db.Nacionalidades, "NacionalidadId", "Nombre", view.NacionalidadId);
                ViewBag.PuestoId = new SelectList(db.Puestos.Where(p => p.Activo), "PuestoId", "Nombre", view.PuestoId);
                ViewBag.SupervisorId = new SelectList(db.Personas, "PersonaId", "Nombre", view.SupervisorId);
                ViewBag.RazonSocialId = new SelectList(db.RazonesSociales.Where(p => p.Activo), "RazonSocialId", "Nombre", view.RazonSocialId);
                return View(view);
            }
            catch (Exception)
            {
                return View(view);
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
                Persona persona = await db.Personas.FindAsync(id);
                if (persona == null)
                {
                    return HttpNotFound();
                }

                db.Personas.Remove(persona);
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
