using Domain;
using Finanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finanzas.Helpers
{
    public class TipoPagoHelper
    {
        DataContextLocal db = new DataContextLocal();

        public TipoPagoHelper()
        {
        }

        public static void CheckTipoPagos()
        {
            try
            {
                if (!FindByName("Tarjeta"))
                {
                    Add(1, "Tarjeta", true);
                }
                if (!FindByName("Transferencia"))
                {
                    Add(2, "Transferencia", true);
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public static void Add(int id, string nombre, bool activa)
        {
            try
            {
                using (DataContextLocal db = new DataContextLocal())
                {
                    var tipo = new TipoPago
                    {
                        TipoPagoId = id,
                        Nombre = nombre,
                        Activo = activa,
                    };

                    db.TipoPagos.Add(tipo);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public static bool FindByName(string nombre)
        {
            try
            {
                using (DataContextLocal db = new DataContextLocal())
                {
                    if (db.TipoPagos.Where(e => e.Nombre == nombre).Count() > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}