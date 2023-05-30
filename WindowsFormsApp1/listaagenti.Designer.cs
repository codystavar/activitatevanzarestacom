namespace WindowsFormsApp1
{
    partial class listaagenti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listaagenti));
            this.agentiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._DataSet4_Factura = new WindowsFormsApp1._DataSet4_Factura();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.agentiTableAdapter = new WindowsFormsApp1._DataSet4_FacturaTableAdapters.AgentiTableAdapter();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.agentiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_Factura)).BeginInit();
            this.SuspendLayout();
            // 
            // agentiBindingSource
            // 
            this.agentiBindingSource.DataMember = "Agenti";
            this.agentiBindingSource.DataSource = this._DataSet4_Factura;
            // 
            // _DataSet4_Factura
            // 
            this._DataSet4_Factura.DataSetName = "DataSet4-Factura";
            this._DataSet4_Factura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.agentiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.listaagenti.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 53);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(656, 396);
            this.reportViewer1.TabIndex = 0;
            // 
            // agentiTableAdapter
            // 
            this.agentiTableAdapter.ClearBeforeFill = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(576, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 38);
            this.button5.TabIndex = 43;
            this.button5.Text = "Inapoi";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listaagenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "listaagenti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Agenti";
            this.Load += new System.EventHandler(this.listaagenti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.agentiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_Factura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private _DataSet4_Factura _DataSet4_Factura;
        private System.Windows.Forms.BindingSource agentiBindingSource;
        private _DataSet4_FacturaTableAdapters.AgentiTableAdapter agentiTableAdapter;
        private System.Windows.Forms.Button button5;
    }
}