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
    public partial class frmOrdenPorDia : Form
    {

        DataContextLocal db = new DataContextLocal();
        Empleado Empleado = new Empleado();
        int rowCount = 0;
        int resultado = 0;
        public Panel Panel { get; set; }
        public List<Panel> listapaneles = new List<Panel>();
        public frmOrdenPorDia()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrdenPorDia_Load(object sender, EventArgs e)
        {
            var datos= db.Empleados.ToList();

            foreach (var itemdos in datos)

            {
                var horas= int.Parse(itemdos.HorasLunes.ToString());
                 resultado=resultado+horas;
                label10.Text = resultado.ToString();
                var nombre = itemdos.Nombre;
                label8.Text +=nombre+",";
            }
                
            var a = dtprecogida.Value.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            var query = from l in db.Ordenes where l.FeEnt >= fdesde && l.FeEnt<=fhasta select l;
         //  this.dbgOdenesTotales.DataSource = query.Select(x => new { x.NumeroOrden, x.NombreCliente, x.FeEnt,x.Localizacion,x.HoraSalida, x.TotalOrden, x.CantidadPagada,x.CantidadRestante }).ToList();

            this.txtFecha.Text = a;
        }


private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BorrarPanelDetalleOrdenes();
            BorrarPanelOrdenes();
            BorrarPanelDetallePagos();
            var a = dtprecogida.Value.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtFecha.Text = a;
          
            var query = from l in db.Ordenes where l.FeEnt >= fdesde && l.FeEnt <= fhasta select l;

            Panel = new Panel();

            Panel.Size = new Size(1384, 37);

            Panel.BackColor = Color.Silver;
            var datos =query.Count();
            var prendaView = new Panel();
            int d = 0;
            int f = 0;
            foreach (var itemdos in query)

            {
                var aumentocredito = new Panel();
                aumentocredito.Size = new Size(1384, 37);
                aumentocredito.Click += new EventHandler(ClickCargarOrden);
                aumentocredito.BackColor = Color.Silver;
                aumentocredito.Name = itemdos.OrdenId.ToString();

                var Email = new Label();
                Email.Location = new Point(0,0);
                Email.Text = itemdos.OrdenId.ToString();
                var fecha = new Label();
                fecha.Location = new Point(60, 0);
                fecha.Text = itemdos.FechaEnt.ToString();
                var total = new Label();
                total.Location = new Point(200, 0);
                total.Text = itemdos.FechaEnt.ToString();

                aumentocredito.Controls.Add(Email);
                aumentocredito.Controls.Add(fecha);
                aumentocredito.Controls.Add(total);
                
                this.tlpOrdenesTotales.Controls.Add(aumentocredito);
            }

        }
        void ClickCargarOrden(object sender, EventArgs e)
        {
            BorrarPanelDetalleOrdenes();
            BorrarPanelDetallePagos();
            Panel btn = sender as Panel;
            var id = int.Parse(btn.Name);

            var query = db.OrdenDetalleTareas.Find(id);

            var querydos = db.Ordenes.Find(id);



            foreach (var itemdos in query.Prenda.DetalleTareas)

            {
                
                var aumentocreditodos = new Panel();
                aumentocreditodos.Size = new Size(841, 37);
                aumentocreditodos.Click += new EventHandler(ClickCargarOrden);
                aumentocreditodos.BackColor = Color.DarkGray;
                aumentocreditodos.Name = itemdos.DetalleOrdenPrendaId.ToString();

                var Emaildos = new Label();
                Emaildos.Location = new Point(0, 0);
                Emaildos.Text = itemdos.Prenda.Prenda.TipoRopa.ToString();
           


                aumentocreditodos.Controls.Add(Emaildos);
             

                var aumentocredito = new Panel();
                aumentocredito.Size = new Size(841, 37);
                aumentocredito.Click += new EventHandler(ClickCargarOrden);
                aumentocredito.BackColor = Color.White;
                aumentocredito.Name = itemdos.DetalleOrdenesId.ToString();

                var fecha = new Label();
                fecha.Location = new Point(60, 0);
                fecha.Text = itemdos.Detalle.DetalleTareas.ToString();
                aumentocredito.Controls.Add(fecha);


                this.tblDetalleOrdenesClientes.Controls.Add(aumentocreditodos);


                this.tblDetalleOrdenesClientes.Controls.Add(aumentocredito);

            }


            foreach (var item in query.Prenda.Orden.Prendas)

            {

               

                var Emaildos = new Label();
                Emaildos.Location = new Point(0, 0);
                var fecha= item.Orden.FechaEnt.ToString();
                Emaildos.Text = fecha.Remove(fecha.Length - 8).ToString();


                var Email = new Label();
                Email.Location = new Point(60, 0);
                Email.Text = item.Orden.CantidadPagada.ToString();


           


                

                this.tlpPagos.Controls.Add(Emaildos);


                this.tlpPagos.Controls.Add(Email);

            }

        }
        private void button29_MouseEnter(object sender, EventArgs e)
        {

            this.button29.BackColor = System.Drawing.Color.OliveDrab;
            this.button29.ForeColor = System.Drawing.Color.White;
        }

        private void button29_MouseLeave(object sender, EventArgs e)
        {

            this.button29.BackColor = System.Drawing.SystemColors.Control;
            this.button29.ForeColor = System.Drawing.Color.Black;
        }

        private void button34_MouseEnter(object sender, EventArgs e)
        {

            this.button34.BackColor = System.Drawing.Color.OliveDrab;
            this.button34.ForeColor = System.Drawing.Color.White;
        }

        private void button34_MouseLeave(object sender, EventArgs e)
        {

            this.button34.BackColor = System.Drawing.SystemColors.Control;
            this.button34.ForeColor = System.Drawing.Color.Black;
        }

        private void button32_MouseEnter(object sender, EventArgs e)
        {

            this.button32.BackColor = System.Drawing.Color.OliveDrab;
            this.button32.ForeColor = System.Drawing.Color.White;
        }

        private void button32_MouseLeave(object sender, EventArgs e)
        {

            this.button32.BackColor = System.Drawing.SystemColors.Control;
            this.button32.ForeColor = System.Drawing.Color.Black;
        }

        private void button31_MouseEnter(object sender, EventArgs e)
        {

            this.button31.BackColor = System.Drawing.Color.OliveDrab;
            this.button31.ForeColor = System.Drawing.Color.White;
        }

        private void button31_MouseLeave(object sender, EventArgs e)
        {

            this.button31.BackColor = System.Drawing.SystemColors.Control;
            this.button31.ForeColor = System.Drawing.Color.Black;
        }

        private void button35_MouseEnter(object sender, EventArgs e)
        {

            this.button35.BackColor = System.Drawing.Color.OliveDrab;
            this.button35.ForeColor = System.Drawing.Color.White;
        }

        private void button35_MouseLeave(object sender, EventArgs e)
        {

            this.button35.BackColor = System.Drawing.SystemColors.Control;
            this.button35.ForeColor = System.Drawing.Color.Black;
        }

        private void button30_MouseEnter(object sender, EventArgs e)
        {

            this.button30.BackColor = System.Drawing.Color.OliveDrab;
            this.button30.ForeColor = System.Drawing.Color.White;
        }

        private void button30_MouseLeave(object sender, EventArgs e)
        {

            this.button30.BackColor = System.Drawing.SystemColors.Control;
            this.button30.ForeColor = System.Drawing.Color.Black;
        }

        private void button33_MouseEnter(object sender, EventArgs e)
        {

            this.button33.BackColor = System.Drawing.Color.OliveDrab;
            this.button33.ForeColor = System.Drawing.Color.White;
        }

        private void button33_MouseLeave(object sender, EventArgs e)
        {

            this.button33.BackColor = System.Drawing.SystemColors.Control;
            this.button33.ForeColor = System.Drawing.Color.Black;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {

            this.button7.BackColor = System.Drawing.Color.OliveDrab;
            this.button7.ForeColor = System.Drawing.Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {

            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.ForeColor = System.Drawing.Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {

            this.button4.BackColor = System.Drawing.Color.OliveDrab;
            this.button4.ForeColor = System.Drawing.Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {

            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.ForeColor = System.Drawing.Color.Black;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {

            this.button8.BackColor = System.Drawing.Color.OliveDrab;
            this.button8.ForeColor = System.Drawing.Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {

            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            this.button2.BackColor = System.Drawing.Color.OliveDrab;
            this.button2.ForeColor = System.Drawing.Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.ForeColor = System.Drawing.Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {

            this.button5.BackColor = System.Drawing.Color.OliveDrab;
            this.button5.ForeColor = System.Drawing.Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {

            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.ForeColor = System.Drawing.Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

            this.button1.BackColor = System.Drawing.Color.OliveDrab;
            this.button1.ForeColor = System.Drawing.Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.Color.Black;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {

            this.button9.BackColor = System.Drawing.Color.OliveDrab;
            this.button9.ForeColor = System.Drawing.Color.White;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {

            this.button9.BackColor = System.Drawing.SystemColors.Control;
            this.button9.ForeColor = System.Drawing.Color.Black;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {

            this.button6.BackColor = System.Drawing.Color.OliveDrab;
            this.button6.ForeColor = System.Drawing.Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {

            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.ForeColor = System.Drawing.Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {

            this.button3.BackColor = System.Drawing.Color.OliveDrab;
            this.button3.ForeColor = System.Drawing.Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.ForeColor = System.Drawing.Color.Black;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {

            this.button11.BackColor = System.Drawing.Color.OliveDrab;
            this.button11.ForeColor = System.Drawing.Color.White;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {

            this.button11.BackColor = System.Drawing.SystemColors.Control;
            this.button11.ForeColor = System.Drawing.Color.Black;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {

            this.button10.BackColor = System.Drawing.Color.OliveDrab;
            this.button10.ForeColor = System.Drawing.Color.White;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {

            this.button10.BackColor = System.Drawing.SystemColors.Control;
            this.button10.ForeColor = System.Drawing.Color.Black;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {

            this.button13.BackColor = System.Drawing.Color.OliveDrab;
            this.button13.ForeColor = System.Drawing.Color.White;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {

            this.button13.BackColor = System.Drawing.SystemColors.Control;
            this.button13.ForeColor = System.Drawing.Color.Black;
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {

            this.button14.BackColor = System.Drawing.Color.OliveDrab;
            this.button14.ForeColor = System.Drawing.Color.White;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {

            this.button14.BackColor = System.Drawing.SystemColors.Control;
            this.button14.ForeColor = System.Drawing.Color.Black;
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {

            this.button12.BackColor = System.Drawing.Color.OliveDrab;
            this.button12.ForeColor = System.Drawing.Color.White;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {

            this.button12.BackColor = System.Drawing.SystemColors.Control;
            this.button12.ForeColor = System.Drawing.Color.Black;
        }

        private void dbgOdenesTotales_ColumnDataPropertyNameChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //this.dbgOdenesTotales.BackColor = System.Drawing.Color.OliveDrab;
            //this.dbgOdenesTotales.ForeColor = System.Drawing.Color.White;
        }

        private void dbgOdenesTotales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void dbgOdenesTotales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;
            if (a != -1)
            {
            
              //  var t = dbgOdenesTotales.SelectedRows[0].Cells[0].Value.ToString();

       
                //var query = from l in db.Ordenes where l.NumeroOrden==t select l;
                //this.dgvPagosPorcliente.DataSource = query.Select(x => new { x.FeEnt, x.CantidadPagada,x.MedioPago, x.EmpleadoRealizo}).ToList();
              
            }
        }


        private void BorrarPanelDetalleOrdenes()
        {
            var totaldos = tblDetalleOrdenesClientes.Controls.Count;
            var litdos = tblDetalleOrdenesClientes.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tblDetalleOrdenesClientes.Controls.Remove(tblDetalleOrdenesClientes.Controls[0]);
            }

        }
        private void BorrarPanelDetallePagos()
        {
            var totaldos = tlpPagos.Controls.Count;
            var litdos = tlpPagos.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tlpPagos.Controls.Remove(tlpPagos.Controls[0]);
            }

        }
        private void BorrarPanelOrdenes()
        {
            var totaldos = tlpOrdenesTotales.Controls.Count;
            var litdos = tlpOrdenesTotales.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tlpOrdenesTotales.Controls.Remove(tlpOrdenesTotales.Controls[0]);
            }

        }
    }
}
