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
    public partial class frmVerPagos : Form
    {
        public int MedioPagoid { get; set; }
        public DateTime Fechadesde { get; set; }
        public DateTime Fechahasta { get; set; }

        DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public frmVerPagos(int Pagoid,DateTime fechadesde, DateTime fechahasta)
        {
            Fechadesde = fechadesde;
            Fechahasta = fechahasta;
            MedioPagoid = Pagoid;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerPagos_Load(object sender, EventArgs e)
        {

            Fechahasta = Fechahasta.AddHours(23).AddMinutes(59);
            lblTotalPagos.Text = db.Pagos.Where(q => q.MedioPagoId == MedioPagoid && q.Fecha >= Fechadesde && q.Fecha <= Fechahasta).Sum(q=>q.Monto).ToString();
            dvgPagos.DataSource = db.Pagos.Where(q => q.MedioPagoId==MedioPagoid&&  q.Fecha >= Fechadesde && q.Fecha <= Fechahasta).Select(t=>new {t.OrdenId,t.Ordenes.Cliente.Nombre,t.Ordenes.Cliente.TelefonoPrincipal,t.Monto,t.MediosPago.FormaPago,t.EmpleadoRealizo }).ToList();
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
