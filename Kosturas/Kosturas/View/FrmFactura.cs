using Kosturas.Model;
using Microsoft.Reporting.WinForms;
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
    public partial class FrmFactura : Form
    {
        DataContextLocal db = new DataContextLocal();
        public int OrdenId { get; set; }
        public FrmFactura(int idOrden)
        {
            OrdenId = idOrden;
            InitializeComponent();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            try
            {
                this.sp_ReporteFActuradosTableAdapter.Fill(this.dataSet1.sp_ReporteFActurados, OrdenId);
                ReportParameter report = new ReportParameter("Path", @"file://C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\"+OrdenId.ToString()+
                   ".png", true);
                this.reportViewer1.LocalReport.SetParameters(report);

                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();

                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
               
                ReportParameter report = new ReportParameter("Path", @"file://C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\"+ OrdenId.ToString()+
                 ".png", true);
                this.reportViewer1.LocalReport.SetParameters(report);
                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();
                this.reportViewer1.RefreshReport();
            }
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.sp_ReporteFActura' Puede moverla o quitarla según sea necesario.



         
        }
    }
}
