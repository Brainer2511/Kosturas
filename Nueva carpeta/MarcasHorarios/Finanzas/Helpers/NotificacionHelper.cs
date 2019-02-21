using Domain;
using Finanzas.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Finanzas.Helpers
{
    //1. Alerta 2. Success 3.Danger 4.Warning 5.Info
    //public class NotificacionHelper:IDisposable
    //{
    //    DataContextLocal db = new DataContextLocal();

    //    public NotificacionHelper()
    //    {
    //    }

    //    [HandleError]
    //    public static async Task CreateNotificationEmployees(string email, string titulo, string nota, int tipoNotificacion, int? subPeriodoEventoId, bool institucion=false)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp= new DataContextLocal())
    //            {
    //                NotificacionGeneralEmpleado notificacion = new NotificacionGeneralEmpleado();
    //                notificacion.Activo = true;
    //                if (UsersHelper.Empleado(email) > 0)
    //                {
    //                    notificacion.EmpleadoId = UsersHelper.Empleado(email);
    //                }
    //                else
    //                {
    //                    notificacion.ClienteId = UsersHelper.Cliente(email);
    //                }
    //                notificacion.Fecha = DateTime.Now;
    //                notificacion.TipoNotificacion = tipoNotificacion;
    //                notificacion.Titulo = titulo;
    //                notificacion.Nota = nota;
    //                notificacion.Institucion = institucion;

    //                DBTemp.NotificacionesGeneralesEmpleados.Add(notificacion);
    //                await DBTemp.SaveChangesAsync();
    //                await CreateNotificationAllEmployee(notificacion.NotificacionGeneralEmpleadoId);
    //                if (subPeriodoEventoId != null)
    //                {
    //                    await AddSubPeriodoEventoNotification(subPeriodoEventoId, null, notificacion.NotificacionGeneralEmpleadoId);
    //                }
    //                await BitacoraHelper.AddBitacora("Notificación Cliente", notificacion.NotificacionGeneralEmpleadoId, "Tabla", email, "Crear");
    //            }
                
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    public static async Task CreateNotificationCustomers(string email, string titulo, string nota, int tipoNotificacion, int? subPeriodoEventoId, bool institucion=false)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp = new DataContextLocal())
    //            {
    //                NotificacionGeneralCliente notificacion = new NotificacionGeneralCliente();
    //                notificacion.Activo = true;
    //                if (UsersHelper.Empleado(email) > 0)
    //                {
    //                    notificacion.EmpleadoId = UsersHelper.Empleado(email);
    //                }

    //                notificacion.Fecha = DateTime.Now;
    //                notificacion.TipoNotificacion = tipoNotificacion;
    //                notificacion.Titulo = titulo;
    //                notificacion.Nota = nota;
    //                notificacion.Institucion = institucion;

    //                DBTemp.NotificacionesGeneralesClientes.Add(notificacion);
    //                await DBTemp.SaveChangesAsync();
    //                await CreateNotificationAllCustomer(notificacion.NotificacionGeneralClienteId);

    //                if (subPeriodoEventoId!=null)
    //                {
    //                    await AddSubPeriodoEventoNotification(subPeriodoEventoId,notificacion.NotificacionGeneralClienteId,null);
    //                }
                    
    //                await BitacoraHelper.AddBitacora("Notificación Cliente", notificacion.NotificacionGeneralClienteId, "Tabla", email, "Crear");
    //            }

    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    public static async Task AddSubPeriodoEventoNotification(int? subPeriodoEventoId, int? notificacionGeneralClienteId, int? notificacionGeneralEmpleadoId)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp= new DataContextLocal())
    //            {
    //                DBTemp.SubPeridosEventoNotificacion.Add(new SubPeriodoEventoNotificacion
    //                {
    //                    Activo=true,
    //                    Fecha=DateTime.Now,
    //                    NotificacionGeneralClienteId=notificacionGeneralClienteId,
    //                    NotificacionGeneralEmpleadoId=notificacionGeneralEmpleadoId,
    //                    SubPeriodoEventoId=subPeriodoEventoId.Value,
    //                });

    //                await DBTemp.SaveChangesAsync();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    public static async Task FindNoMatchNotificationEmployee(string email)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp= new DataContextLocal())
    //            {
    //                var empleadoId = UsersHelper.Empleado(email);
    //                var listNotificationFind = (from notificacion in DBTemp.NotificacionesEmpleados.Where(n => n.EmpleadoId == empleadoId)
    //                                            join general in DBTemp.NotificacionesGeneralesEmpleados
    //                                            on notificacion.NotificacionGeneralEmpleadoId equals general.NotificacionGeneralEmpleadoId 
    //                                            into joinGeneralNotificacion
    //                                            from genera in joinGeneralNotificacion.DefaultIfEmpty()
    //                                            select new NotificacionGeneralEmpleado
    //                                            {
    //                                                Activo=genera.Activo,
    //                                                ClienteId=genera.ClienteId,
    //                                                EmpleadoId=genera.EmpleadoId,
    //                                                Fecha=genera.Fecha,
    //                                                Nota=genera.Nota,
    //                                                Titulo=genera.Titulo,
    //                                                TipoNotificacion=genera.TipoNotificacion,
    //                                                NotificacionGeneralEmpleadoId=genera.NotificacionGeneralEmpleadoId,
    //                                            }).ToList();

    //                foreach (var item in listNotificationFind)
    //                {
    //                    DBTemp.NotificacionesEmpleados.Add(new NotificacionEmpleado
    //                    {
    //                        Activo=true,
    //                        EmpleadoId=empleadoId,
    //                        Fecha=DateTime.Now,
    //                        NotificacionGeneralEmpleadoId=item.NotificacionGeneralEmpleadoId,
    //                    });
    //                }

    //                await DBTemp.SaveChangesAsync();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    public static async Task FindNoMatchNotificationCustomer(string email)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp = new DataContextLocal())
    //            {
    //                var clienteId = UsersHelper.Cliente(email);
    //                var listNotificationFind = (from notificacion in DBTemp.NotificacionesClientes.Where(n => n.ClienteId == clienteId)
    //                                            join general in DBTemp.NotificacionesGeneralesClientes
    //                                            on notificacion.NotificacionGeneralClienteId equals general.NotificacionGeneralClienteId
    //                                            into joinGeneralNotificacion
    //                                            from genera in joinGeneralNotificacion.DefaultIfEmpty()
    //                                            select new NotificacionGeneralCliente
    //                                            {
    //                                                Activo = genera.Activo,
    //                                                EmpleadoId = genera.EmpleadoId,
    //                                                Fecha = genera.Fecha,
    //                                                Nota = genera.Nota,
    //                                                Titulo = genera.Titulo,
    //                                                TipoNotificacion = genera.TipoNotificacion,
    //                                                NotificacionGeneralClienteId = genera.NotificacionGeneralClienteId,
    //                                            }).ToList();

    //                foreach (var item in listNotificationFind)
    //                {
    //                    DBTemp.NotificacionesClientes.Add(new NotificacionCliente
    //                    {
    //                        Activo = true,
    //                        ClienteId = clienteId,
    //                        Fecha = DateTime.Now,
    //                        NotificacionGeneralClienteId = item.NotificacionGeneralClienteId,
    //                    });
    //                }

    //                await DBTemp.SaveChangesAsync();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    private static async Task CreateNotificationAllEmployee(int id)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp= new DataContextLocal())
    //            {
    //                var general = await DBTemp.NotificacionesGeneralesEmpleados.FindAsync(id);

    //                foreach (var item in DBTemp.Empleados.ToList())
    //                {
    //                    DBTemp.NotificacionesEmpleados.Add(new NotificacionEmpleado
    //                    {
    //                        Activo=true,
    //                        EmpleadoId=item.EmpleadoId,
    //                        Fecha=DateTime.Now,
    //                        NotificacionGeneralEmpleadoId=general.NotificacionGeneralEmpleadoId,
    //                    });
    //                }
    //                await DBTemp.SaveChangesAsync();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    private static async Task CreateNotificationAllCustomer(int id)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp = new DataContextLocal())
    //            {
    //                var general = await DBTemp.NotificacionesGeneralesClientes.FindAsync(id);

    //                foreach (var item in DBTemp.Clientes.ToList())
    //                {
    //                    DBTemp.NotificacionesClientes.Add(new NotificacionCliente
    //                    {
    //                        Activo = true,
    //                        ClienteId = item.ClienteId,
    //                        Fecha = DateTime.Now,
    //                        NotificacionGeneralClienteId = general.NotificacionGeneralClienteId,
    //                    });
    //                }

    //                await DBTemp.SaveChangesAsync();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    public static async Task DesactivateAllNotification(string email)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp= new DataContextLocal())
    //            {
    //                if (UsersHelper.Empleado(email) > 0)
    //                {
    //                    var empleadoId = UsersHelper.Empleado(email);

    //                    DBTemp.NotificacionesEmpleados.Where(n => n.EmpleadoId == empleadoId).ToList().ForEach(n => n.Activo = true);
    //                    await DBTemp.SaveChangesAsync();
                           
    //                }
    //                else
    //                {
    //                    var clienteId = UsersHelper.Cliente(email);

    //                    DBTemp.NotificacionesClientes.Where(n => n.ClienteId == clienteId).ToList().ForEach(n => n.Activo = true);
    //                    await DBTemp.SaveChangesAsync();
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    public static async Task DesactivateNotificationEmployee(int id, string userName)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp= new DataContextLocal())
    //            {
    //                var notificacion = await DBTemp.NotificacionesEmpleados.FindAsync(id);
    //                notificacion.Activo = false;
    //                DBTemp.Entry(notificacion).State = EntityState.Modified;
    //                await DBTemp.SaveChangesAsync();
    //                await BitacoraHelper.AddBitacora("Notificación Empleado", notificacion.NotificacionGeneralEmpleadoId, "Tabla", userName, "Desactivar");
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    [HandleError]
    //    public static async Task DesactivateNotificationCustomer(int id, string userName)
    //    {
    //        try
    //        {
    //            using (DataContextLocal DBTemp = new DataContextLocal())
    //            {
    //                var notificacion = await DBTemp.NotificacionesClientes.FindAsync(id);
    //                notificacion.Activo = false;
    //                DBTemp.Entry(notificacion).State = EntityState.Modified;
    //                await DBTemp.SaveChangesAsync();
    //                await BitacoraHelper.AddBitacora("Notificación Empleados", notificacion.NotificacionGeneralClienteId, "Tabla", userName, "Desactivar");
    //            }
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        db.Dispose();
    //    }
    //}
}