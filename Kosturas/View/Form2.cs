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
    public partial class Form2 : Form
    {
        public int OrdenId { get; set; }
        public int DetalleId { get; set; }
        public Form2(int idOrden = 0, int idDetalle = 0)
        {
            DetalleId = idDetalle;
            OrdenId = idOrden;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.sp_ReporteFActuradosTableAdapter.Fill(this.dataSet4.sp_ReporteFActurados, OrdenId);

            this.reportViewer1.RefreshReport();
        }
    }
}
