using Kosturas.Model;
using Kosturas.ViewModels;
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
    public partial class frmIngresos : Form
    {
        DataContextLocal db = new DataContextLocal();
        int rowCount = 0;
        Color ColorEntrada;
        public List<OrdenViewModel> listaPagos = new List<OrdenViewModel>();
        public List<OrdenViewModel> listaIngresos = new List<OrdenViewModel>();
        public frmIngresos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerOrdenes_Click(object sender, EventArgs e)
        {
            var a = this.txtDesde.Text;

            var b = this.txtHasta.Text;

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtDesde.Text = a;
            this.txtHasta.Text = b;

            ClickCargarPagos(a, b);
            ClickCargarTotalIngresos(a, b);
            cargarTotalIngresos(a, b);
        }

        private void frmIngresos_Load(object sender, EventArgs e)
        {
            var a = DateTime.Today.ToShortDateString();// dtDesde.Value.ToShortDateString();

            var b = DateTime.Today.ToShortDateString();// dtpHasta.Value.ToShortDateString();


            this.txtDesde.Text = a;
            this.txtHasta.Text = b;
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            var a = dtDesde.Value.ToShortDateString();



            this.txtDesde.Text = a;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            var b = dtpHasta.Value.ToShortDateString();


            this.txtHasta.Text = b;
        }
        void cargarTotalIngresos(string a, string b)
        {
            try
            {
                var desde = a + " 00:00";
                var hasta = b + " 23:59";
                var fdesde = DateTime.Parse(desde);
                var fhasta = DateTime.Parse(hasta);
                var query = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).ToList();
                if (query.Count > 0)
                {
                    this.lblTotalIngresos.Text = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).Sum(q => q.Monto).ToString();

                }
            }
            catch (Exception)
            {

            
            }

           

        }
        void ClickCargarTotalIngresos(string a, string b)
        {
            try
            {
                BorrarPanelTotalPagos();


                listaIngresos = new List<OrdenViewModel>();







                rowCount = 0;


                var desde = a + " 00:00";
                var hasta = b + " 23:59";
                var fdesde = DateTime.Parse(desde);
                var fhasta = DateTime.Parse(hasta);


                var query = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta)
                    .GroupBy(q => new { q.MedioPagoId, q.MediosPago.FormaPago, q.Fecha, })
                    .Select(x => new { MedioPagoId = x.Key.MedioPagoId, Fecha = x.Key.Fecha, MedioPAgo = x.Key.FormaPago, Total = x.Sum(q => q.Monto) })
                    .ToList();



                foreach (var itemdos in query.ToList())

                {

                    var panelViewPagosTotales = new OrdenViewModel();




                    panelViewPagosTotales.Panel.Name = itemdos.MedioPagoId.ToString();
                    panelViewPagosTotales.Panel.Size = new Size(430, 30);
                    panelViewPagosTotales.Panel.BackColor = Color.WhiteSmoke;



                    panelViewPagosTotales.lblId.Text = "Total " + itemdos.MedioPAgo;


                    panelViewPagosTotales.lblNombre.Text = itemdos.Total.ToString();
                    panelViewPagosTotales.lblNombre.Size = new Size(100, 25);









                    panelViewPagosTotales.Panel.Controls.Add(panelViewPagosTotales.lblId);
                    panelViewPagosTotales.Panel.Controls.Add(panelViewPagosTotales.lblNombre);




                    listaIngresos.Add(panelViewPagosTotales);
                    rowCount += 1;
                    tlpPagos.RowCount = rowCount;
                    this.tlpPagos.Controls.Add(listaIngresos.Last().Panel, 0, rowCount);





                }
            }
            catch (Exception)
            {

               
            }

          

            

        }
        void ClickCargarPagos(string a, string b)
        {
            try
            {
                BorrarPanelPagos();


                listaPagos = new List<OrdenViewModel>();







                rowCount = 0;
                var Colores = true;

                var desde = a + " 00:00";
                var hasta = b + " 23:59";
                var fdesde = DateTime.Parse(desde);
                var fhasta = DateTime.Parse(hasta);



                var query = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta)
                   .GroupBy(q => new { q.MedioPagoId, q.MediosPago.FormaPago, q.Fecha, })
                   .Select(x => new { MedioPagoId = x.Key.MedioPagoId, Fecha = x.Key.Fecha, MedioPAgo = x.Key.FormaPago, Total = x.Sum(q => q.Monto) })
                   .ToList();




                foreach (var itemdos in query.ToList())

                {

                    var panelViewPagos = new OrdenViewModel();




                    panelViewPagos.Panel.Name = itemdos.MedioPagoId.ToString();
                    panelViewPagos.Panel.MouseEnter += new EventHandler(Mouseover);
                    panelViewPagos.Panel.MouseLeave += new EventHandler(Mouseleave);
                    panelViewPagos.Panel.Size = new Size(800, 30);
                    if (Colores == true)
                    {
                        panelViewPagos.Panel.BackColor = Color.White;
                        Colores = false;
                    }
                    else
                    {
                        panelViewPagos.Panel.BackColor = Color.WhiteSmoke;
                        Colores = true;
                    }

                    panelViewPagos.lblId.Text = itemdos.Fecha.ToString();


                    panelViewPagos.lblNombre.Text = itemdos.MedioPAgo.ToString();
                    panelViewPagos.lblNombre.Size = new Size(100, 25);



                    panelViewPagos.lblHoraEntrada.Text = "Codigo";

                    panelViewPagos.lblHoraEntrada.Size = new Size(100, 25);
                    panelViewPagos.lblHoraEntrada.Location = new Point(250, 8);



                    panelViewPagos.lblLocalizacion.Text = itemdos.Total.ToString();
                    panelViewPagos.lblLocalizacion.Size = new Size(100, 25);
                    panelViewPagos.lblLocalizacion.Location = new Point(380, 8);


                    panelViewPagos.lblFechaEntrada.Text = itemdos.Total.ToString();
                    panelViewPagos.lblFechaEntrada.Location = new Point(530, 8);
                    panelViewPagos.lblFechaEntrada.Size = new Size(100, 25);








                    panelViewPagos.lblMontoPagado.Text = "Ver Lista Pagos";
                    panelViewPagos.lblMontoPagado.Name = itemdos.MedioPagoId.ToString();
                    panelViewPagos.lblMontoPagado.ForeColor = Color.Red;
                    panelViewPagos.lblMontoPagado.Size = new Size(120, 25);
                    panelViewPagos.lblMontoPagado.Location = new Point(670, 8);

                    panelViewPagos.lblMontoPagado.Click += new EventHandler(ClickCargarListaPagos);




                    panelViewPagos.Panel.Controls.Add(panelViewPagos.lblId);
                    panelViewPagos.Panel.Controls.Add(panelViewPagos.lblFechaEntrada);
                    panelViewPagos.Panel.Controls.Add(panelViewPagos.lblHoraEntrada);
                    panelViewPagos.Panel.Controls.Add(panelViewPagos.lblLocalizacion);
                    panelViewPagos.Panel.Controls.Add(panelViewPagos.lblNombre);


                    panelViewPagos.Panel.Controls.Add(panelViewPagos.lblMontoPagado);



                    listaPagos.Add(panelViewPagos);
                    rowCount += 1;
                    tlpPagos.RowCount = rowCount;
                    this.tblDetallePagos.Controls.Add(listaPagos.Last().Panel, 0, rowCount);




                }
            }
            catch (Exception)
            {

            }

            

        }
        void ClickCargarListaPagos(object sender, EventArgs e)
        {

            Label btn = sender as Label;
            var id = int.Parse(btn.Name);

            frmVerPagos pagos = new frmVerPagos(id,DateTime.Parse(txtDesde.Text), DateTime.Parse(txtHasta.Text));
            pagos.Location = new Point(525, 320);
            pagos.ShowDialog();
        }
        private void BorrarPanelTotalPagos()
        {
            var totaldos = tlpPagos.Controls.Count;
            var litdos = tlpPagos.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tlpPagos.Controls.Remove(tlpPagos.Controls[0]);
            }

        }
        private void BorrarPanelPagos()
        {
            var totaldos = tblDetallePagos.Controls.Count;
            var litdos = tblDetallePagos.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tblDetallePagos.Controls.Remove(tblDetallePagos.Controls[0]);
            }

        }
        void Mouseover(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;



            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;


        }
        void Mouseleave(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;





            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;

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

        private void btnVerOrdenes_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnVerOrdenes_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
