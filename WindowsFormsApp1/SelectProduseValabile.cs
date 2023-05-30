using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SelectProduseValabile : Form
    {
        public SelectProduseValabile()
        {
            InitializeComponent();
        }

        private void SelectProduseValabile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSelectProduse.Produse' table. You can move, or remove it, as needed.
            this.produseTableAdapter.Fill(this.dataSelectProduse.Produse);

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
