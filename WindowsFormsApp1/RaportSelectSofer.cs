using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RaportSelectSofer : Form
    {
        public RaportSelectSofer()
        {
            InitializeComponent();
        }

        private void RaportSelectSofer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet3.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet3.DataTable1);

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
