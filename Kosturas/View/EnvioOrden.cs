using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        Color ColorEntrada;
        private Ordenes orden = new Ordenes();
        Empleado Empleado = new Empleado();
        int resultado = 0;
        public int ClienteId { get; set; }
        public int OrdenId { get; set; }
        public EnvioOrden(int clienteId = 0,int ordenId=0)
        {

            ClienteId = clienteId;
            OrdenId = ordenId;
            cliente = db.Clientes.Find(clienteId);
            orden = db.Ordenes.Find(ordenId);
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnvioOrden_Load(object sender, EventArgs e)
        {
            
       

            this.lblCalcularCambio.Visible = false;
            this.lblCAmbio.Visible = false;
            this.lblresultado.Visible = false;
            this.txtCalcularCambio.Visible = false;
            ActualizarPanelTrabajadores();
           
            this.dtpFecha.Value = dtpFecha.Value.AddDays(2);
         
            lblVisitas.Text = orden.Prendas.Sum(w=>w.Cantidad).ToString();
           lblTotalDos.Text= orden.TotalOrden.ToString();
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
           
           

            cmbTipoPago.DataSource =db.MediosPago.ToList();
            cmbTipoPago.DisplayMember = "FormaPago";
            cmbTipoPago.ValueMember = "MedioPagoId";

            cmbTipoPago.SelectedIndex = 0;
            var a = dtpFecha.Value.ToString();
            a = a.Remove(a.Length - 8);
            this.txtFecha.Text =a;
            txtpago.Text = orden.TotalOrden.ToString();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();
            this.Opacity = 1;


            Ordenes orden = db.Ordenes.Find(OrdenId);
            orden.NumeroOrden = orden.OrdenId.ToString();
            orden.HoraSalida =this.cmbHora.SelectedItem.ToString()+":"+this.cmbMinutos.SelectedItem.ToString();
         
            var a = int.Parse(orden.TotalOrden.ToString());
            var b = int.Parse(txtpago.Text);
            var c = a - b;
            orden.CantidadRestante = c;
            orden.EmpleadoRealizo = Program.Pin;
            orden.CantidadPagada = double.Parse(txtpago.Text);
            orden.FechaSalida = txtFecha.Text;
            
            db.Entry(orden).State = EntityState.Modified;
            db.SaveChanges();
            if (ckbNopagar.Checked == false) { 
            Pagos pago = new Pagos();
            pago.Fecha = DateTime.Today;
            pago.EmpleadoRealizo = Program.Pin;
            pago.Monto = double.Parse(txtpago.Text);
            pago.MedioPagoId = int.Parse(cmbTipoPago.SelectedValue.ToString());
            pago.OrdenId = orden.OrdenId;
        
            db.Pagos.Add(pago);
            db.SaveChanges();
            }
            Cliente cliente = db.Clientes.Find(ClienteId);
            if (cliente.Visitas == null) {cliente.Visitas = "1"; cliente.Visitas = cliente.Visitas; } else
            {
                var Visita = int.Parse(cliente.Visitas); Visita += 1;
                cliente.Visitas = Visita.ToString();
            }
           
        
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            this.Close();
          

        }

        private void ckbNopagar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbNopagar.Checked == true)
            {
                this.txtpago.Text = "0";
                this.txtCalcularCambio.Text = "0";
                this.cmbTipoPago.Visible = false;
                this.lblCalcularCambio.Visible = false;
                this.lblCAmbio.Visible = false;
                this.lblresultado.Visible = false;
                this.txtCalcularCambio.Visible = false;

            }
            else
            {
                this.txtpago.Text =orden.TotalOrden.ToString();
                this.cmbTipoPago.Visible = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }
        void ActualizarPanelTrabajadores()
        {
            label10.Text = "";
            label8.Text = "";
            label14.Text = "";
            label6.Text = "";
            resultado = 0;
           var FechaHoy = DateTime.Today;
            var Dia = FechaHoy.DayOfWeek;

            var datos = db.Empleados.ToList();

            foreach (var itemdos in datos)

            {
                if (Dia.ToString() == "Monday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasLunes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Tuesday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasMartes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Wednesday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasMiercoles.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Thursday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasJueves.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Friday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasViernes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Saturday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasSabado.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
                if (Dia.ToString() == "Sunday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasDomingo.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString() + ":" + "00";
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
            }

            //var ordenes = db.OrdenDetalleTareas.Where(q => q.Prenda.Orden.FeEnt == DateTime.Today).ToList().Select(q => q.Duracion).Sum();
            //var otra = ordenes / 60;

            //var prueba = resultado * 60;

            //var sfdg = prueba - ordenes;

            //var sdh = sfdg / 60;
            //label14.Text = sdh.ToString() + ":" + "00";
            //var fddg = resultado - sdh;

            //label6.Text = fddg.ToString() + ":" + "00";
        }

        private void cmbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (cmbTipoPago.SelectedIndex==0)
            {

                this.lblCalcularCambio.Visible = true;
                this.lblCAmbio.Visible = true;
                this.lblresultado.Visible = true;
                this.txtCalcularCambio.Visible = true;

            }
            else
            {

                this.lblCalcularCambio.Visible = false;
                this.lblCAmbio.Visible = false;
                this.lblresultado.Visible = false;
                this.txtCalcularCambio.Visible = false;
            }
        }

        private void txtCalcularCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            String x = "";


            x = this.txtCalcularCambio.Text + e.KeyChar;

            if (e.KeyChar == '\b')
            {
                if (x.Length == 1)
                {
                    x = x.Remove(x.Length - 1);
                   
                }
                else
                {
                    x = x.Remove(x.Length - 2);
                   
                }
            }


           

                var total = int.Parse(this.txtpago.Text);
            if (x != "") { 
            var residuo= int.Parse(x);
                var Resultado =  residuo- total;
                lblresultado.Text = Resultado.ToString();
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x1=40;
            int y1=40;

            for (int i = 0; i < 6; i++)
            {
                Pen pen = new Pen(Color.White);
                e.Graphics.DrawLine(pen, 14, x1, 230, y1);
                x1 = x1 + 55;
                y1 = y1 + 55;
            }
         
        }

        private void EnvioOrden_Paint(object sender, PaintEventArgs e)
        {
            int x1 = 250;
            int y1 = 250;

            for (int i = 0; i < 3; i++)
            {
                Pen pen = new Pen(Color.Gray);
                e.Graphics.DrawLine(pen, 14, x1, 635, y1);
                x1 = x1 + 50;
                y1 = y1 + 50;
            }

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPanelTrabajadores();
            var a = dtpFecha.Value.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtFecha.Text = a;


            var ordenes = db.OrdenDetalleTareas.Where(q => q.Prenda.Orden.FeEnt >= fdesde && q.Prenda.Orden.FeEnt <= fhasta).ToList().Select(q => q.Duracion).Sum();
            var otra = ordenes / 60;

            var prueba = resultado * 60;

            var sfdg = prueba - ordenes;

            var sdh = sfdg / 60;
            label14.Text = sdh.ToString() + ":" + "00";
            var fddg = resultado - sdh;

            label6.Text = fddg.ToString() + ":" + "00";
        }

        private void btnNumero_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnNumero_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
