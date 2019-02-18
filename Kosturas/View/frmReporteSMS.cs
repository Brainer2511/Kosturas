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
    public partial class frmReporteSMS : Form
    {
        DataContextLocal db = new DataContextLocal();
        int rowCount = 0;
        Color ColorEntrada;
        public List<OrdenViewModel> listaSMS = new List<OrdenViewModel>();
       
        public frmReporteSMS()
        {
            InitializeComponent();
        }

        private void frmReporteSMS_Load(object sender, EventArgs e)
        {
            var a = DateTime.Today;// dtDesde.Value.ToShortDateString();

            var b = DateTime.Today;// dtpHasta.Value.ToShortDateString();


            this.txtDesde.Text = a.ToShortDateString();
            this.txtHasta.Text = b.ToShortDateString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerOrdenes_Click(object sender, EventArgs e)
        {
            var a =this.txtDesde.Text;
           

            var b = this.txtHasta.Text;

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtDesde.Text = a;
            this.txtHasta.Text = b;

            CargarReporteSMS(a, b);
        
        }
        void CargarReporteSMS(string a, string b)
        {
            BorrarPanelReporteSMS();


            listaSMS = new List<OrdenViewModel>();







            rowCount = 0;
            var Colores = true;

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);



            var query = db.Provedor.Where(q => q.FechaIngreso >= fdesde && q.FechaIngreso <= fhasta)
               .GroupBy(q => new { q.idServicio,q.FechaIngreso })
               .Select(x => new { ServicoId = x.Key.idServicio, Fecha=x.FirstOrDefault().FechaIngreso,
                   MontoPagos = x.Sum(q=>q.MontoPago), MontoIngresos = x.Sum(q => q.MontoIngreso) })
               .ToList();
         



            foreach (var itemdos in query.ToList())

            {

                var panelViewSMS = new OrdenViewModel();

                var DatosProvedor = db.Afiliados.Find(query.FirstOrDefault().ServicoId);


                panelViewSMS.Panel.Name = itemdos.ServicoId.ToString();
             
                panelViewSMS.Panel.MouseEnter += new EventHandler(Mouseover);
                panelViewSMS.Panel.MouseLeave += new EventHandler(Mouseleave);
                panelViewSMS.Panel.Size = new Size(1265, 30);
                if (Colores == true)
                {
                    panelViewSMS.Panel.BackColor = Color.White;
                    Colores = false;
                }
                else
                {
                    panelViewSMS.Panel.BackColor = Color.WhiteSmoke;
                    Colores = true;
                }

                panelViewSMS.lblId.Text = DatosProvedor.Nombre.ToString();
               
                panelViewSMS.lblId.Size = new Size(200, 25);

                panelViewSMS.lblNombre.Text = itemdos.MontoPagos.ToString();
              
                panelViewSMS.lblNombre.Location = new Point(260, 8);
                panelViewSMS.lblNombre.Size = new Size(200, 25);



                panelViewSMS.lblHoraEntrada.Text = itemdos.Fecha.ToString();
               
                panelViewSMS.lblHoraEntrada.Size = new Size(200, 25);
                panelViewSMS.lblHoraEntrada.Location = new Point(520, 8);



                panelViewSMS.lblLocalizacion.Text = itemdos.MontoIngresos.ToString();
               
                panelViewSMS.lblLocalizacion.Size = new Size(200, 25);
                panelViewSMS.lblLocalizacion.Location = new Point(780, 8);


                panelViewSMS.lblFechaEntrada.Text =DatosProvedor.Porsentaje.ToString();
                
                panelViewSMS.lblFechaEntrada.Location = new Point(1050, 8);
                panelViewSMS.lblFechaEntrada.Size = new Size(200, 25);


             

            



                



                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblId);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblFechaEntrada);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblHoraEntrada);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblLocalizacion);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblNombre);
              

              



                listaSMS.Add(panelViewSMS);
                rowCount += 1;
                tblDetalleSMS.RowCount = rowCount;
                this.tblDetalleSMS.Controls.Add(listaSMS.Last().Panel, 0, rowCount);




            }

        }

        private void BorrarPanelReporteSMS()
        {
            var totaldos = tblDetalleSMS.Controls.Count;
            var litdos = tblDetalleSMS.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tblDetalleSMS.Controls.Remove(tblDetalleSMS.Controls[0]);
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
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
