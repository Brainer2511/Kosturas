using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class UtilitarioDAL
    {
        //variable utilizada para conversión de fechas epoch
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Método para convertir una fecha hora en formato epoch a una fecha hora en formato dd-MM-yyyy hh:mm:ss
        /// </summary>
        /// <param name="unixTime">dato tipo long con la fecha en formato epoch</param>
        /// <returns>Datetime con la fecha resultante</returns>
        public static DateTime FromUnixTime(long unixTime)
        {
            return epoch.AddSeconds(unixTime);
        }
    }
}
