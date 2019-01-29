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
    public partial class frmOpcionesOrdenes : Form
    {
        public DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public frmOpcionesOrdenes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            OpcionesOrdenes opcionesOrdenes = new OpcionesOrdenes();

            opcionesOrdenes.NombreOpcion = txtNombreOpcion.Text;
            opcionesOrdenes.NumeroOpcion = txtNumeroOpcion.Text;
            opcionesOrdenes.TipoOpcion = cmbTipoOpcion.SelectedIndex.ToString();
            opcionesOrdenes.Precio = txtPrecio.Text;




            db.opcionesOrdenes.Add(opcionesOrdenes);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
            dgvOpcionesOrdenes.DataSource = db.opcionesOrdenes.ToList();
        }

        private void frmOpcionesOrdenes_Load(object sender, EventArgs e)
        {
            dgvOpcionesOrdenes.DataSource = db.opcionesOrdenes.ToList();
            this.cmbTipoOpcion.Items.Add("Color");
            this.cmbTipoOpcion.Items.Add("Fabrica");
            this.cmbTipoOpcion.Items.Add("Manchas");
            this.cmbTipoOpcion.Items.Add("Pequeños Articulos");
            this.cmbTipoOpcion.Items.Add("Otros");
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
