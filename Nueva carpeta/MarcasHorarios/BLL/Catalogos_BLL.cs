using System;
using System.Data;

namespace BCC_Horarios_Y_Marcas
{
    public class Catalogos_BLL
    {
        Catalogos Datos;

        public Catalogos_BLL()
        {
            Datos = new Catalogos();
        }

        /// <summary>
        /// Consulta los datos de un catálogo en especifico a partir de su id
        /// </summary>
        /// <param name="idCatalogo">Identificador único de un catálogo</param>
        /// <returns>DataTable con los items asociados al catálogo</returns>
        public DataTable ConsultarItemsCatalogo(int idCatalogo)
        {
            return Datos.ConsultarItemsCatalogo(idCatalogo);
        }

        /// <summary>
        /// Consulta los datos de un catálogo en especifico a partir de su id y el item padre
        /// </summary>
        /// <param name="idCatalogo">Identificador único de un catálogo</param>
        /// <param name="itemPadre">Identificador único del item que es padre de otros item en un mismo catálogo</param>
        /// <returns>DataTable con los items asociados al catálogo</returns>
        public DataTable ConsultarItemsCatalogo(int idCatalogo, int itemPadre)
        {
            return Datos.ConsultarItemsCatalogo(idCatalogo,itemPadre);
        }
    }
}
