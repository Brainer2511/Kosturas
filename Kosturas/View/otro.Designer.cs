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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_ReporteFActuradosTableAdapter1 = new Kosturas.DataSet1TableAdapters.sp_ReporteFActuradosTableAdapter();
            this.spReporteFActuradosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet11 = new Kosturas.DataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFActuradosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Kosturas.Reportes.Report4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1600, 865);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_ReporteFActuradosTableAdapter1
            // 
            this.sp_ReporteFActuradosTableAdapter1.ClearBeforeFill = true;
            // 
            // spReporteFActuradosBindingSource
            // 
            this.spReporteFActuradosBindingSource.DataMember = "sp_ReporteFActurados";
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // otro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "otro";
            this.Text = "otro";
            this.Load += new System.EventHandler(this.otro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spReporteFActuradosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1TableAdapters.sp_ReporteFActuradosTableAdapter sp_ReporteFActuradosTableAdapter1;
        private System.Windows.Forms.BindingSource spReporteFActuradosBindingSource;
        private DataSet1 dataSet11;
    }
}