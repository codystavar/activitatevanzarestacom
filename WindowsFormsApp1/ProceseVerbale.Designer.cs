﻿namespace WindowsFormsApp1
{
    partial class ProceseVerbale
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProceseVerbale));
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._DataSet4_Factura = new WindowsFormsApp1._DataSet4_Factura();
            this.dataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataTable1TableAdapter = new WindowsFormsApp1._DataSet4_FacturaTableAdapters.DataTable1TableAdapter();
            this.dataTable2TableAdapter = new WindowsFormsApp1._DataSet4_FacturaTableAdapters.DataTable2TableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.deschideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.devizeEstimativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_Factura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            this.dataTable1BindingSource.DataSource = this._DataSet4_Factura;
            // 
            // _DataSet4_Factura
            // 
            this._DataSet4_Factura.DataSetName = "DataSet4-Factura";
            this._DataSet4_Factura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable2BindingSource
            // 
            this.dataTable2BindingSource.DataMember = "DataTable2";
            this.dataTable2BindingSource.DataSource = this._DataSet4_Factura;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTable1BindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.dataTable2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.ProceseVerbale.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(4, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(679, 607);
            this.reportViewer1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button4.Location = new System.Drawing.Point(587, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 42);
            this.button4.TabIndex = 7;
            this.button4.Text = "Inapoi";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.Location = new System.Drawing.Point(294, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Next";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Location = new System.Drawing.Point(213, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Previous";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search (Comanda ID)";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(481, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.Location = new System.Drawing.Point(375, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // dataTable2TableAdapter
            // 
            this.dataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deschideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(687, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // deschideToolStripMenuItem
            // 
            this.deschideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.devizeEstimativeToolStripMenuItem});
            this.deschideToolStripMenuItem.Name = "deschideToolStripMenuItem";
            this.deschideToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.deschideToolStripMenuItem.Text = "Deschide";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DoubleClickEnabled = true;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem1.Text = "Facturi";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DoubleClickEnabled = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem2.Text = "Avize de insotire a marfii";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DoubleClickEnabled = true;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(203, 22);
            this.toolStripMenuItem3.Text = "Certificate Garantie";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // devizeEstimativeToolStripMenuItem
            // 
            this.devizeEstimativeToolStripMenuItem.Name = "devizeEstimativeToolStripMenuItem";
            this.devizeEstimativeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.devizeEstimativeToolStripMenuItem.Text = "Devize Estimative";
            this.devizeEstimativeToolStripMenuItem.Click += new System.EventHandler(this.devizeEstimativeToolStripMenuItem_Click);
            // 
            // ProceseVerbale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 674);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProceseVerbale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procese Verbale";
            this.Load += new System.EventHandler(this.ProceseVerbale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DataSet4_Factura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        private _DataSet4_Factura _DataSet4_Factura;
        private System.Windows.Forms.BindingSource dataTable2BindingSource;
        private _DataSet4_FacturaTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private _DataSet4_FacturaTableAdapters.DataTable2TableAdapter dataTable2TableAdapter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deschideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem devizeEstimativeToolStripMenuItem;
    }
}