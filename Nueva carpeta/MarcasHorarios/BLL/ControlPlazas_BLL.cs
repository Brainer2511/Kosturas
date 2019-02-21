using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class ControlPlazas_BLL
    {
        ControlPlazas datos;

        public ControlPlazas_BLL()
        {
            datos = new ControlPlazas();
        }

        public DataTable ObtenerDatosElite(string desde, string hasta)
        {
            return datos.ObtenerDatosElite(desde, hasta);
        }

        public DataTable ObtenerSplits()
        {
            return datos.ObtenerSplits();
        }

        public void RegistrarSplit(int codigo, string nombre, int? id)
        {
            datos.RegistrarSplit(codigo, nombre, id);
        }

        public DataTable ConsultarLoginIdPersonal()
        {
            return datos.ConsultarLoginIdPersonal();
        }
    }
}
