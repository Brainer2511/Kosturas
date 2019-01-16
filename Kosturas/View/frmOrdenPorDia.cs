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
        Color ColorEntrada;
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
           

            var Dia = dtprecogida.Value.DayOfWeek;

            var datos= db.Empleados.ToList();

            foreach (var itemdos in datos)

            {
                if (Dia.ToString() == "Monday") { 
                if (itemdos.Rol == "E") { 
                var horas= int.Parse(itemdos.HorasLunes.ToString());
                 resultado=resultado+horas;
                label10.Text = resultado.ToString();
                var nombre = itemdos.Nombre;
                label8.Text +=nombre + " , ";
                }
                }
                if (Dia.ToString() == "Tuesday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasMartes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
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
            ActualizarPanelTrabajadores();
            BorrarPanelDetalleOrdenes();
            BorrarPanelOrdenes();
            BorrarPanelDetallePagos();
            var a = dtprecogida.Value.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtFecha.Text = a;
          
            var query = (from l in db.Ordenes where l.FeEnt >= fdesde && l.FeEnt <= fhasta select l).ToList();
          
                
            Panel = new Panel();

            Panel.Size = new Size(1384, 37);

       //     Panel.BackColor = Color.Silver;
            var datos =query.Count();
            var prendaView = new Panel();
            int d = 0;
            int f = 0;
            var Colores = true;
            foreach (var itemdos in query)
             
            {
                label19.Text = itemdos.EmpleadoRealizo;
                label14.Text = itemdos.EmpleadoRealizo;
                var aumentocredito = new Panel();
                aumentocredito.Size = new Size(1384, 37);
                aumentocredito.Click += new EventHandler(ClickCargarOrden);
                aumentocredito.MouseEnter += new EventHandler(Mouseover);
                aumentocredito.MouseLeave += new EventHandler(Mouseleave);
                if (Colores == true)
                {
                    aumentocredito.BackColor = Color.White;
                    Colores = false;
                }
                else
                {
                    aumentocredito.BackColor = Color.WhiteSmoke;
                    Colores = true;
                }
               
                aumentocredito.Name = itemdos.OrdenId.ToString();


                var lblId = new Label();
       
                lblId.Location = new Point(0,8);
                lblId.Size = new Size(100, 25);
        if (!string.IsNullOrEmpty(itemdos.OrdenId.ToString())) { lblId.Text = itemdos.OrdenId.ToString(); } else { lblId.Text = ""; }
                
            
                var lblNombre = new Label();
           
                lblNombre.Size = new Size(200,25);
                lblNombre.Location = new Point(110, 8);
    if (!string.IsNullOrEmpty(itemdos.Cliente.Nombre.ToString())) { lblNombre.Text = itemdos.Cliente.Nombre.ToString(); } else { lblNombre.Text = ""; }
              

                var lblFechaEntrada = new Label();
                
                lblFechaEntrada.Size = new Size(150, 25);
                lblFechaEntrada.Location = new Point(315, 8);
                if (!string.IsNullOrEmpty(itemdos.FechaEnt.ToString())) { lblFechaEntrada.Text = itemdos.FechaEnt.ToString(); } else { lblFechaEntrada.Text = ""; }

               

                var lblLocalizacion = new Label();
                
                lblLocalizacion.Location = new Point(545, 8);
                lblLocalizacion.Size = new Size(50, 25);
    if (!string.IsNullOrEmpty(itemdos.Localizacion.ToString())) { lblLocalizacion.Text = itemdos.Localizacion.ToString(); } else { lblLocalizacion.Text =""; }


             
                var lblHoraEntrada = new Label();
              
                lblHoraEntrada.Location = new Point(680, 8);
                lblHoraEntrada.Size = new Size(110, 25);
                if (!string.IsNullOrEmpty(itemdos.HoraSalida.ToString())) { lblHoraEntrada.Text = itemdos.HoraSalida.ToString(); } else { lblHoraEntrada.Text = ""; }


              

                var lblTotal = new Label();
              
                lblTotal.Location = new Point(810, 8);
                lblTotal.Size = new Size(150, 25);
                if (!string.IsNullOrEmpty(itemdos.TotalOrden.ToString())) { lblTotal.Text = itemdos.TotalOrden.ToString(); } else { lblTotal.Text = ""; }



           

                var lblMontoPagado = new Label();
              
                lblMontoPagado.Location = new Point(980, 8);
                lblMontoPagado.Size = new Size(150, 25);
                if (!string.IsNullOrEmpty(itemdos.CantidadPagada.ToString())) { lblMontoPagado.Text = itemdos.CantidadPagada.ToString(); } else { lblMontoPagado.Text = ""; }


              

                var lblMontoRestante = new Label();
                
                lblMontoRestante.Location = new Point(1150, 8);
                lblMontoRestante.Size = new Size(150, 25);

                if (!string.IsNullOrEmpty(itemdos.CantidadRestante.ToString())) { lblMontoRestante.Text = itemdos.CantidadRestante.ToString(); } else { lblMontoRestante.Text = ""; }

               

                aumentocredito.Controls.Add(lblId);
                aumentocredito.Controls.Add(lblNombre);
                aumentocredito.Controls.Add(lblLocalizacion);
                aumentocredito.Controls.Add(lblFechaEntrada);

                aumentocredito.Controls.Add(lblHoraEntrada);
                aumentocredito.Controls.Add(lblTotal);
                aumentocredito.Controls.Add(lblMontoPagado);
                aumentocredito.Controls.Add(lblMontoRestante);

                this.tlpOrdenesTotales.Controls.Add(aumentocredito);
            }

        }
        void ClickCargarOrden(object sender, EventArgs e)
        {
            BorrarPanelDetalleOrdenes();
            BorrarPanelDetallePagos();
            Panel btn = sender as Panel;
            var id = int.Parse(btn.Name);



      

            var orden = db.Ordenes.Find(id);



            foreach (var prenda in orden.Prendas)

            {
                
                var panelPrenda = new Panel();
                
                panelPrenda.Size = new Size(1020, 30);
                panelPrenda.Click += new EventHandler(ClickCargarOrden);
                panelPrenda.BackColor = Color.DarkGray;
                panelPrenda.Name = prenda.DetalleOrdenPrendaId.ToString();

                var lblNombrePrenda = new Label();
                lblNombrePrenda.Location = new Point(0, 6);
                lblNombrePrenda.Text = prenda.Prenda.TipoRopa.ToString()+"X"+prenda.Cantidad;
           


                panelPrenda.Controls.Add(lblNombrePrenda);
                this.tblDetalleOrdenesClientes.Controls.Add(panelPrenda);
                foreach (var tarea in prenda.DetalleTareas)
                {
                    var panelTarea = new Panel();
                  
                    panelTarea.Size = new Size(1020, 40);
                    panelTarea.Click += new EventHandler(ClickCargarOrden);
                    panelTarea.MouseEnter += new EventHandler(MouseoverDos);
                    panelTarea.MouseLeave += new EventHandler(MouseleaveDos);
                    panelTarea.BackColor = Color.White;
                    panelTarea.Name = tarea.DetalleOrdenPrendaId.ToString();

                    var lblIdOrden = new Label();
                    lblIdOrden.BackColor = Color.Red;
                    lblIdOrden.Location = new Point(0, 8);
                    lblIdOrden.Size = new Size(90, 15);
                    lblIdOrden.Text =prenda.OrdenId.ToString();
                    panelTarea.Controls.Add(lblIdOrden);

                    var lblNombreTarea = new Label();
                    lblNombreTarea.BackColor = Color.Red;
                    lblNombreTarea.Location = new Point(110, 8);
                    lblNombreTarea.Size = new Size(120, 15);
                    lblNombreTarea.Text = tarea.Detalle.Tarea.NombreTareas.ToString();
                    panelTarea.Controls.Add(lblNombreTarea);

                    var lblDetalleTarea = new Label();
                    lblDetalleTarea.BackColor = Color.Red;
                    lblDetalleTarea.Location = new Point(245, 8);
                    lblDetalleTarea.Size = new Size(150, 15);
                    lblDetalleTarea.Text = tarea.Detalle.DetalleTareas.ToString();
                    panelTarea.Controls.Add(lblDetalleTarea);

                    var lblPrecio = new Label();
                    lblPrecio.BackColor = Color.Red;
                    lblPrecio.Location = new Point(400, 8);
                    lblPrecio.Size = new Size(97, 15);
                    lblPrecio.Text = tarea.Detalle.Precio.ToString();
                    panelTarea.Controls.Add(lblPrecio);


                    var lblTotalPrecio = new Label();
                    lblTotalPrecio.BackColor = Color.Red;
                    lblTotalPrecio.Location = new Point(517, 8);
                    lblTotalPrecio.Size = new Size(97, 15);
                    lblTotalPrecio.Text = tarea.Detalle.Precio.ToString();
                    panelTarea.Controls.Add(lblTotalPrecio);

                    this.tblDetalleOrdenesClientes.Controls.Add(panelTarea);
                }
                  


              

            }


            //foreach (var item in query.Prenda.Orden.Prendas)

            //{


            //    var PanelPagos = new Panel();
            //    PanelPagos.Size = new Size(529, 30);
            //    PanelPagos.MouseEnter += new EventHandler(MouseoverDos);
            //    PanelPagos.MouseLeave += new EventHandler(MouseleaveDos);
            //    PanelPagos.BackColor = Color.White;
            //    PanelPagos.Name = item.DetalleOrdenPrendaId.ToString();

            //    var lblFecha = new Label();
            //    lblFecha.Location = new Point(0, 8);
            //    lblFecha.Size=new Size(97, 15);
             
            //    var fecha= item.Orden.FechaEnt.ToString();
            //    lblFecha.Text = fecha.Remove(fecha.Length - 8).ToString();


            //    var lblCantidadPagaga = new Label();
            //    lblCantidadPagaga.Location = new Point(98, 8);
            //    lblCantidadPagaga.Size = new Size(97,15);
            //    lblCantidadPagaga.Text = item.Orden.CantidadPagada.ToString();

            //    PanelPagos.Controls.Add(lblFecha);
            //    PanelPagos.Controls.Add(lblCantidadPagaga);





            //    this.tlpPagos.Controls.Add(PanelPagos);


         

            //}

        }

        void ActualizarPanelTrabajadores()
        {
            label10.Text = "";
            label8.Text = "";
            resultado = 0;
            var Dia = dtprecogida.Value.DayOfWeek;

            var datos = db.Empleados.ToList();

            foreach (var itemdos in datos)

            {
                if (Dia.ToString() == "Monday")
                {
                    if (itemdos.Rol == "E")
                    {
                        var horas = int.Parse(itemdos.HorasLunes.ToString());
                        resultado = resultado + horas;
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
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
                        label10.Text = resultado.ToString();
                        var nombre = itemdos.Nombre;
                        label8.Text += nombre + " , ";
                    }
                }
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


        void Mouseover(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
            ColorEntrada = btr.BackColor;
            
            object id = btr.Name;
            id = btr.BackColor = Color.LightBlue;
           


        }
        void Mouseleave(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
         

            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;
          


        }

        void MouseoverDos(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
            ColorEntrada = btr.BackColor;

            object id = btr.Name;
            id = btr.BackColor = Color.OliveDrab;



        }
        void MouseleaveDos(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;



        }

        private void frmOrdenPorDia_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
            Pen pen = new Pen(Color.White);
            e.Graphics.DrawLine(pen, 14, 40, 387, 40);

            Pen pendos = new Pen(Color.White);
            e.Graphics.DrawLine(pendos, 14, 80, 387, 80);
        }
    }
}
