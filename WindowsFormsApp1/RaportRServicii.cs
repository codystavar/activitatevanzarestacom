using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RaportTopClienti : Form
    {
        public RaportTopClienti()
        {
            InitializeComponent();
        }

        private void RaportTopClienti_Load(object sender, EventArgs e)
        {

            this.serviciiTotaleTableAdapter.Fill(this.dataSet5.ServiciiTotale);
            this.serviciiTotaleTableAdapter.Fill(this.dataSet5.ServiciiTotale);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
        }
    }
}
