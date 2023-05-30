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
    public partial class RaportFServicii : Form
    {
        public RaportFServicii()
        {
            InitializeComponent();
        }

        private void RaportFServicii_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet5.Servicii' table. You can move, or remove it, as needed.
            this.serviciiTableAdapter.Fill(this.dataSet5.Servicii);

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
