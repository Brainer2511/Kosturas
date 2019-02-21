using Domain;
using Finanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finanzas.Helpers
{
    public class EstadoCivilHelper : IDisposable
    {
        DataContextLocal db = new DataContextLocal();

        public EstadoCivilHelper()
        {
        }

        public static void CheckEstadosCiviles()
        {
            try
            {
                if (!FindByName("Soltero"))
                {
                    Add(1, "Soltero", true);
                }
                if (!FindByName("Casado"))
                {
                    Add(2, "Casado", true);
                }
                if (!FindByName("Divorciado"))
                {
                    Add(3, "Divorciado", true);
                }
                if (!FindByName("Unión Libre"))
                {
                    Add(4, "Unión Libre", true);
                }
                if (!FindByName("Viudo"))
                {
                    Add(5, "Viudo", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HandleError]
        public static void Add(int estadoCivilId, string nombre, bool activa)
        {
            try
            {
                using (DataContextLocal db = new DataContextLocal())
                {
                    var estadoCivil = new EstadoCivil
                    {
                        EstadoCivilId = estadoCivilId,
                        Nombre = nombre,
                        Activa = activa,
                    };

                    db.EstadosCiviles.Add(estadoCivil);
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
                    if (db.EstadosCiviles.Where(e => e.Nombre == nombre).Count() > 0)
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