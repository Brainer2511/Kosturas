using Domain;
using Finanzas.Models;
using System.Linq;
using System.Web.Mvc;

namespace Finanzas.Helpers
{
    public class HorarioRubroHelper
    {
        DataContextLocal db = new DataContextLocal();

        public HorarioRubroHelper()
        {
        }

        public static void CheckHorarioRubros()
        {
            try
            {
                if (!FindByName("Hora Entrada"))
                {
                    Add(1, "Hora Entrada", true);
                }
                if (!FindByName("Hora Salida"))
                {
                    Add(2, "Hora Salida", true);
                }                
            }
            catch
            {

            }
        }

        [HandleError]
        public static void Add(int id, string nombre, bool activa)
        {
            try
            {
                using (DataContextLocal db = new DataContextLocal())
                {
                    var horario = new HorarioRubro
                    {
                        HorarioRubroId = id,
                        Nombre = nombre,
                        Activo = activa,
                    };

                    db.HorarioRubros.Add(horario);
                    db.SaveChanges();
                }
            }
            catch 
            {

            }
        }

        [HandleError]
        public static bool FindByName(string nombre)
        {
            try
            {
                using (DataContextLocal db = new DataContextLocal())
                {
                    if (db.HorarioRubros.Where(e => e.Nombre == nombre).Count() > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}