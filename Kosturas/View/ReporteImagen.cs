using Kosturas.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace Kosturas.View
{
    public partial class ReporteImagen : Form
    {
        DataContextLocal db = new DataContextLocal();

        public int OrdenId { get; set; }
        public int DetalleId { get; set; }
        public ReporteImagen(int idOrden = 0, int idDetalle = 0)
        {
            DetalleId = idDetalle;
            OrdenId = idOrden;
            InitializeComponent();
        }

        private void ReporteImagen_Load(object sender, EventArgs e)
        {


            try
            {
                this.sp_ReporteFActuradosTableAdapter.Fill(this.dataSet1.sp_ReporteFActurados, DetalleId);
                ReportParameter report = new ReportParameter("Path", @"file://" + Path.GetDirectoryName(Application.ExecutablePath) + @"\CodigosBarras\" + OrdenId.ToString() +
                    ".png", true);
                this.reportViewer1.LocalReport.SetParameters(report);

                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {

                ReportParameter report = new ReportParameter("Path", @"file://C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\" + OrdenId.ToString() +
                   ".png", true);
                this.reportViewer1.LocalReport.SetParameters(report);


                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();
                this.reportViewer1.RefreshReport();
            }

   
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
        

            }
            catch (Exception ex)
            {

            }
            // TODO: esta línea
            // var query=  db.CodigoBarras.Where(q => q.OrdenId == 4).Select(t => new { t.OrdenId, t.Imagen }).ToList();


            //using (var ms = new MemoryStream(query.FirstOrDefault().Imagen))
            //{
            //    pictureBox1.Image = Image.FromStream(ms);
            //}
            //  pictureBox1.Image =System.Drawing.Image.GetPixelFormatSize(query.FirstOrDefault().Imagen);
        }
    }
}
