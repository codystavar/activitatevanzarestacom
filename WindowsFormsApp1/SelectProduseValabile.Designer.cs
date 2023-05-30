namespace WindowsFormsApp1
{
    partial class SelectProduseValabile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectProduseValabile));
            this.produseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSelectProduseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSelectProduse = new WindowsFormsApp1.DataSelectProduse();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.produseTableAdapter = new WindowsFormsApp1.DataSelectProduseTableAdapters.ProduseTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.produseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectProduseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectProduse)).BeginInit();
            this.SuspendLayout();
            // 
            // produseBindingSource
            // 
            this.produseBindingSource.DataMember = "Produse";
            this.produseBindingSource.DataSource = this.dataSelectProduseBindingSource;
            // 
            // dataSelectProduseBindingSource
            // 
            this.dataSelectProduseBindingSource.DataSource = this.dataSelectProduse;
            this.dataSelectProduseBindingSource.Position = 0;
            // 
            // dataSelectProduse
            // 
            this.dataSelectProduse.DataSetName = "DataSelectProduse";
            this.dataSelectProduse.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.produseBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 49);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(636, 585);
            this.reportViewer1.TabIndex = 0;
            // 
            // produseTableAdapter
            // 
            this.produseTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(532, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Inapoi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectProduseValabile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 638);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SelectProduseValabile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raport: Gama/Tabel Produse";
            this.Load += new System.EventHandler(this.SelectProduseValabile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.produseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectProduseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectProduse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSelectProduse dataSelectProduse;
        private System.Windows.Forms.BindingSource dataSelectProduseBindingSource;
        private System.Windows.Forms.BindingSource produseBindingSource;
        private DataSelectProduseTableAdapters.ProduseTableAdapter produseTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}