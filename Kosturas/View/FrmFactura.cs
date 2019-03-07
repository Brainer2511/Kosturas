using Kosturas.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

                var connectionString = "Data Source=SQL5030.site4now.net; Initial Catalog=DB_A27AB6_djarquin01;User Id=DB_A27AB6_djarquin01_admin;Password=Shenlong123;";


                SqlConnection conx = new SqlConnection(connectionString);
                String spconsulta;

                spconsulta = "sp_ReporteFActurados";
                SqlDataAdapter sql = new SqlDataAdapter(spconsulta, conx);
                conx.Open();
                sql.SelectCommand.CommandType = CommandType.StoredProcedure;
                sql.SelectCommand.Parameters.Add("@idOrden", SqlDbType.Int).Value = OrdenId;



                DataTable data = new DataTable("Prueba");

                sql.Fill(data);

                if (data.Rows.Count > 0)
                {

                }
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dataSet1", data));





                this.reportViewer1.LocalReport.Refresh();
                conx.Close();


                //this.sp_ReporteFActuradosTableAdapter.Fill(this.dataSet1.sp_ReporteFActurados, OrdenId);
                ReportParameter report = new ReportParameter("Path", @"file://"+Application.ExecutablePath + @"\CodigosBarras\"+OrdenId.ToString()+
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
