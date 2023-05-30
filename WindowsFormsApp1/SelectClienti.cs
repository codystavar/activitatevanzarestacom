using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SelectClienti : Form
    {
        public SelectClienti()
        {
            InitializeComponent();
        }

        private void SelectClienti_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Clienti' table. You can move, or remove it, as needed.

            this.clientiTableAdapter.Fill(this.dataSet1.Clienti);
            this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

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
