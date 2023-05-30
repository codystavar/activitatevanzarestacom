using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RaportSTehnician : Form
    {
        public RaportSTehnician()
        {
            InitializeComponent();
        }

        private void RaportSTehnician_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'DataSet4_SelectTehnician.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this._DataSet4_SelectTehnician.DataTable1);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
