namespace Kosturas.View
{
    partial class otro
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSServicios = new Kosturas.DSServicios();
            this.spReporteFActuraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ReporteFActuraTableAdapter = new Kosturas.DSServiciosTableAdapters.sp_ReporteFActuraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFActuraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet4";
            reportDataSource1.Value = this.spReporteFActuraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.EnableHyperlinks = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Kosturas.Reportes.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSServicios
            // 
            this.dSServicios.DataSetName = "DSServicios";
            this.dSServicios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spReporteFActuraBindingSource
            // 
            this.spReporteFActuraBindingSource.DataMember = "sp_ReporteFActura";
            this.spReporteFActuraBindingSource.DataSource = this.dSServicios;
            // 
            // sp_ReporteFActuraTableAdapter
            // 
            this.sp_ReporteFActuraTableAdapter.ClearBeforeFill = true;
            // 
            // otro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "otro";
            this.Text = "otro";
            this.Load += new System.EventHandler(this.otro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFActuraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spReporteFActuraBindingSource;
        private DSServicios dSServicios;
        private DSServiciosTableAdapters.sp_ReporteFActuraTableAdapter sp_ReporteFActuraTableAdapter;
    }
}