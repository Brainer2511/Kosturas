namespace Kosturas.View
{
    partial class ReporteImagen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spReporteFActuradosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Kosturas.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReporteFActuradosTableAdapter = new Kosturas.DataSet1TableAdapters.sp_ReporteFActuradosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFActuradosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spReporteFActuradosBindingSource
            // 
            this.spReporteFActuradosBindingSource.DataMember = "sp_ReporteFActurados";
            this.spReporteFActuradosBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spReporteFActuradosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.EnableHyperlinks = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Kosturas.Reportes.ReportOrdenTrabajo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(920, 865);
            this.reportViewer1.TabIndex = 2;
            // 
            // sp_ReporteFActuradosTableAdapter
            // 
            this.sp_ReporteFActuradosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 865);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ReporteImagen";
            this.Text = "ReporteImagen";
            this.Load += new System.EventHandler(this.ReporteImagen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFActuradosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spReporteFActuradosBindingSource;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.sp_ReporteFActuradosTableAdapter sp_ReporteFActuradosTableAdapter;
    }
}