using Domain;
using Finanzas.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Finanzas.Helpers
{
    public class BitacoraHelper:IDisposable
    {
        private static DataContextLocal db = new DataContextLocal();

        //[HandleError]
        //public static async Task AddBitacora(string nombreObjeto,int objetoId, string tipoObjeto, string userName,string tipoEvento)
        //{
        //    try
        //    {
        //        var bitacora = new Bitacora
        //        {
        //            FechaEvento = DateTime.Now,
        //            LoginName = userName,
        //            NombreObjeto = nombreObjeto,
        //            ObjetoId = objetoId,
        //            TipoEvento = tipoEvento,
        //            TipoObjeto = tipoObjeto,

        //        };
        //        db.Bitacoras.Add(bitacora);
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public void Dispose()
        {
            db.Dispose();
        }
    }
}