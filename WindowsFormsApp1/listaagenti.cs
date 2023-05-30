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
    public partial class listaagenti : Form
    {
        public listaagenti()
        {
            InitializeComponent();
        }

        private void listaagenti_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_DataSet4_Factura.Agenti' table. You can move, or remove it, as needed.
            this.agentiTableAdapter.Fill(this._DataSet4_Factura.Agenti);

            this.reportViewer1.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form MainMenu = new MainMenu();
            MainMenu.ShowDialog();
        }
    }
}
