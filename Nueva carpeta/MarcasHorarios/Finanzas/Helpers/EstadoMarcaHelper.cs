using Domain;
using Finanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finanzas.Helpers
{
    public class EstadoMarcaHelper : IDisposable
    {
        DataContextLocal db = new DataContextLocal();

        public EstadoMarcaHelper()
        {

        }

        public static void CheckEstadoMarcas()
        {
            try
            {
                if (!FindByName("Normal"))
                {
                    Add(1, "Normal", true);
                }
                if (!FindByName("Omitir"))
                {
                    Add(2, "Omitir", true);
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
                    var item = new EstadoMarca
                    {
                        EstadoMarcaId = id,
                        Nombre = nombre,
                        Activa = activa,
                    };

                    db.EstadoMarcas.Add(item);
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
                    if (db.EstadoMarcas.Where(e => e.Nombre == nombre).Count() > 0)
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