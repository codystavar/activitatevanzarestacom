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
    public partial class loguri : Form
    {
        public loguri()
        {
            InitializeComponent();
        }

        private void loguri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetLoguri.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSetLoguri.DataTable1);

            this.reportViewer1.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
            this.Close();
        }
    }
}
