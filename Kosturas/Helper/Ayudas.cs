using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kosturas
{
    public class Ayudas : IDisposable
    {
        DataContextLocal db = new DataContextLocal();

        public Ayudas()
        {
        }

        public static void CheckEstadosOrdenes()
        {
            try
            {
                if (!FindByName("Pedidos Completados"))
                {
                    Add(1, "Pedidos Completados", Color.Blue);
                }
                if (!FindByName("Recogida pero no págada en su totalidad"))
                {
                    Add(2, "Recogida pero no págada en su totalidad", Color.Orange);
                }
                if (!FindByName("Cotizacion/Recerva"))
                {
                    Add(3, "Cotizacion/Recerva", Color.Violet);
                }
                if (!FindByName("Recogida Y el Saldo Pendiente Pagado"))
                {
                    Add(4, "Recogida Y el Saldo Pendiente Pagado", Color.Aqua);
                }
                if (!FindByName("No Recogida Y el Saldo Pendiente Pagado"))
                {
                    Add(5, "No Recogida Y el Saldo Pendiente Pagado", Color.Lime);
                }
                if (!FindByName("No Recogida Y el Saldo no  Pagado"))
                {
                    Add(6, "No Recogida Y el Saldo no  Pagado", Color.Gray);
                }
            }
            catch (Exception)
            {
                
            }
        }


        public static void Add(int id, string nombre, Color color)
        {
            try
            {
                using (DataContextLocal db = new DataContextLocal())
                {
                    var estado = new Estados
                    {
                        EstadoId = id,
                        Nombre = nombre,
                        Color = color,
                    };

                    db.Estados.Add(estado);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool FindByName(string nombre)
        {
            try
            {
                using (DataContextLocal db = new DataContextLocal())
                {
                    if (db.Estados.Where(e => e.Nombre == nombre).Count() > 0)
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
