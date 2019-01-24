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
    public partial class frmVerOrdenes : Form
    {
        DataContextLocal db = new DataContextLocal();
        public frmVerOrdenes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerOrdenes_Load(object sender, EventArgs e)
        {
            var a = ("2019-01-22");
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            dgvOrdenes.DataSource = db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta).Select(t => new { t.OrdenId, t.FeEnt,t.TotalOrden,t.CantidadPagada }).ToList();
        }
    }
}
