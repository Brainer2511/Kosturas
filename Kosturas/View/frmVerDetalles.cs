using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas.View
{
    public partial class frmVerDetalles : Form
    {
        public int MedioPagoId { get; set; }
        DataContextLocal db = new DataContextLocal();
        public frmVerDetalles(int id=0)
        {
            MedioPagoId = id;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerDetalles_Load(object sender, EventArgs e)
        {
            try
            {
                var a = DateTime.Today.ToShortDateString();
                var desde = a + " 00:00";
                var hasta = a + " 23:59";
                var fdesde = DateTime.Parse(desde);
                var fhasta = DateTime.Parse(hasta);

                dgvOrdenes.DataSource = db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta && q.Pagos.FirstOrDefault().MedioPagoId == MedioPagoId).Select(t => new { t.OrdenId, t.Cliente.Nombre, t.Cliente.TelefonoPrincipal, t.CantidadPagada, t.Pagos.FirstOrDefault().MediosPago.FormaPago, t.FeEnt, t.EmpleadoRealizo }).ToList();

            }
            catch (Exception)
            {

            }
           
        }
    }
}
