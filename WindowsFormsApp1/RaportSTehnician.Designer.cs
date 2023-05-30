namespace WindowsFormsApp1
{
    partial class RaportSTehnician
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaportSTehnician));
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._DataSet4_SelectTehnician = new WindowsFormsApp1._DataSet4_SelectTehnician();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.dataTable1TableAdapter = new WindowsFormsApp1._DataSet4_SelectTehnicianTableAdapters.DataTable1TableAdapter();
            this._DataSet4_Factura = new WindowsFormsApp1._DataSet4_Factura();
            this.dataTable1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable1TableAdapter1 = new WindowsFormsApp1._DataSet4_FacturaTableAdapters.DataTable1TableAdapter();
            this.tableAdapterManager = new WindowsFormsApp1._DataSet4_FacturaTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_SelectTehnician)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_Factura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this._DataSet4_SelectTehnician;
            // 
            // _DataSet4_SelectTehnician
            // 
            this._DataSet4_SelectTehnician.DataSetName = "DataSet4-SelectTehnician";
            this._DataSet4_SelectTehnician.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            reportDataSource1.Name = "Select_Tehnician_Service";
            reportDataSource1.Value = this.dataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.SelectRTehnicianService.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(660, 626);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(560, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Inapoi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // _DataSet4_Factura
            // 
            this._DataSet4_Factura.DataSetName = "DataSet4-Factura";
            this._DataSet4_Factura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable1BindingSource1
            // 
            this.dataTable1BindingSource1.DataMember = "DataTable1";
            this.dataTable1BindingSource1.DataSource = this._DataSet4_Factura;
            // 
            // dataTable1TableAdapter1
            // 
            this.dataTable1TableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp1._DataSet4_FacturaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // RaportSTehnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 698);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RaportSTehnician";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raport: Tehnicieni si Servicii prestate";
            this.Load += new System.EventHandler(this.RaportSTehnician_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_SelectTehnician)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_Factura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private _DataSet4_SelectTehnician _DataSet4_SelectTehnician;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private _DataSet4_SelectTehnicianTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private _DataSet4_Factura _DataSet4_Factura;
        private System.Windows.Forms.BindingSource dataTable1BindingSource1;
        private _DataSet4_FacturaTableAdapters.DataTable1TableAdapter dataTable1TableAdapter1;
        private _DataSet4_FacturaTableAdapters.TableAdapterManager tableAdapterManager;
    }
}