using Domain;
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
   
    public partial class frmImpresionesAutomaticas : Form
    {
        public DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public frmImpresionesAutomaticas()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ImpresionesAutomaticas impresiones = new ImpresionesAutomaticas();

            impresiones.NumeroImprecion = txtNumeroImpresion.Text;
            if (rbPlantillaCliente.Checked == true)
            {
                impresiones.TipoImpresion = rbPlantillaCliente.Text;
            }
            if (rbPlantillaPersonalizada.Checked == true)
            {
                impresiones.TipoImpresion = rbPlantillaPersonalizada.Text;
            }
            if (rbVenta.Checked == true)
            {
                impresiones.TipoImpresion = rbVenta.Text;
            }
          
             if (rbPlantillaTienda.Checked == true)
            {
                impresiones.TipoImpresion = rbPlantillaTienda.Text;
            }
            if (rbOrden.Checked == true)
            {
                impresiones.TipoImpresion = rbOrden.Text;
            }

           
            impresiones.Precio = ckbPrecio.Checked;
            impresiones.CodigoBarras = ckbCodigoBarras.Checked;
            impresiones.Servicio = cmbServicios.SelectedIndex.ToString();




            db.impresiones.Add(impresiones);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
            dvgImpresiones.DataSource = db.impresiones.ToList();
        }

        private void frmImpresionesAutomaticas_Load(object sender, EventArgs e)
        {
            dvgImpresiones.DataSource = db.impresiones.ToList();

         

            var servicios =
     from a in db.Servicios
    // where a.position == "Supervisor" && a.department == "Quality Assurance"
     select new { Names = a.NombreServicio};

            cmbServicios.DataSource = servicios.ToList();
            cmbServicios.DisplayMember = "Names";
           // cmbServicios.ValueMember = "Id";

           
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
