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
    public partial class EnvioOrden : Form
    {

        DataContextLocal db = new DataContextLocal();
        private Cliente cliente = new Cliente();
        public int ClienteId { get; set; }
        public EnvioOrden(int clienteId = 0)
        {

            ClienteId = clienteId;
            cliente = db.Clientes.Find(clienteId);
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnvioOrden_Load(object sender, EventArgs e)
        {
        this.dtpFecha.Value = dtpFecha.Value.AddDays(2);
            txtpago.Text = Program.TotalOrden;
            label5.Text= Program.TotalOrden;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.TelefonoPrincipal;
            cmbHora.Items.Add("15");
            cmbHora.Items.Add("16");
            cmbHora.Items.Add("17");
            cmbHora.Items.Add("18");

            cmbHora.SelectedIndex = 0;
            cmbMinutos.Items.Add("00");
            cmbMinutos.Items.Add("15");
            cmbMinutos.Items.Add("30");
            cmbMinutos.Items.Add("45");
            cmbMinutos.SelectedIndex = 0;
            cmbTipoPago.Items.Add("");
            var medios =
    from medio in db.MediosPago

    select new { Names = medio.FormaPago };

            cmbTipoPago.DataSource = medios.ToList();
            cmbTipoPago.DisplayMember = "Names";
            cmbTipoPago.SelectedIndex = 0;
            var a = dtpFecha.Value.ToString();
            a = a.Remove(a.Length - 8);
            this.txtFecha.Text =a;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPin pin = new frmPin();
            pin.ShowDialog();
            Ordenes orden = new Ordenes();
            orden.NumeroOrden =Program.servicio;
            orden.FeEnt = DateTime.Now;
            orden.HoraSalida =this.cmbHora.SelectedItem.ToString()+":"+this.cmbMinutos.SelectedItem.ToString();
          //  orden.TotalOrden = Program.TotalOrden;
         //   orden.CantidadPagada = this.txtpago.Text;
            var a = int.Parse(Program.TotalOrden);
            var b = int.Parse(txtpago.Text);
            var c = a - b;
        //    orden.CantidadRestante = c.ToString();
            orden.EmpleadoRealizo = Program.Pin;
          //  orden.NombreCliente = cliente.Nombre;
            if (ckbNopagar.Checked == false)
            {
               if (cmbTipoPago.SelectedIndex==0) {
                orden.MedioPago = "Efectivo";
                }
            }
            else {
                orden.MedioPago = "";
            }
            db.Ordenes.Add(orden);
            db.SaveChanges();

            this.Close();
            frmPrincipal principal = new frmPrincipal();
            principal.Opacity = 1;
            principal.Show();

        }

        private void ckbNopagar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbNopagar.Checked == true)
            {
                this.txtpago.Text = "0";
                this.cmbTipoPago.Visible = false;

            }
            else
            {
                this.txtpago.Text =Program.TotalOrden;
                this.cmbTipoPago.Visible = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }
    }
}
