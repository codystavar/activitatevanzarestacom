using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Facturi : Form
    {
        int comandaintiala = 0;


        public Facturi()
        {
            InitializeComponent();
        }

        private void Facturi_Load(object sender, EventArgs e)
        {
            
            button3.Enabled = false;
            string getnrcomanda = $"SELECT MAX(COM) FROM Comenzi;";
            stringconnection.connection.Open();
            OleDbCommand idCommand = new OleDbCommand(getnrcomanda, stringconnection.connection);
            int nrcomanda = Convert.ToInt32(idCommand.ExecuteScalar());
            stringconnection.connection.Close();

            //load report
            this.dataTable1TableAdapter.Fill(this._DataSet4_Factura.DataTable1, nrcomanda);
            this.dataTable2TableAdapter.Fill(this._DataSet4_Factura.DataTable2, nrcomanda);
            this.dataTable3TableAdapter.Fill(this._DataSet4_Factura.DataTable3, nrcomanda);
            this.dataTable4TableAdapter.Fill(this._DataSet4_Factura.DataTable4, nrcomanda);

            this.reportViewer1.RefreshReport();

            comandaintiala = nrcomanda;
            textBox1.Text = $"{comandaintiala}";

        }


        //buton search
        private void button1_Click(object sender, EventArgs e)
        {
            string getmincom = $"SELECT MIN(COM) FROM Comenzi;";
            string getmaxcom = $"SELECT MAX(COM) FROM Comenzi;";
            stringconnection.connection.Open();
            OleDbCommand idCommand = new OleDbCommand(getmincom, stringconnection.connection);
            OleDbCommand idCommand2 = new OleDbCommand(getmaxcom, stringconnection.connection);

            OleDbDataReader reader = idCommand.ExecuteReader();
            reader.Read();
            string min = reader.GetValue(0).ToString();
            reader.Close();

            OleDbDataReader reader2 = idCommand2.ExecuteReader();
            reader2.Read();
            string max = reader2.GetValue(0).ToString();
            reader2.Close();

            stringconnection.connection.Close();

            if (int.TryParse(textBox1.Text, out int num2) && num2 <= int.Parse(min))
            {
                button2.Enabled = false;
                button3.Enabled = true;

            }
            else if (int.TryParse(textBox1.Text, out int num3) && num3 >= int.Parse(max))
            {
                button3.Enabled = false;
                button2.Enabled = true;
            }

                    if (textBox1.Text != "" && int.TryParse(textBox1.Text, out int num) && num > 0)

                    {
                        this.dataTable1TableAdapter.Fill(this._DataSet4_Factura.DataTable1, int.Parse(textBox1.Text));
                        this.dataTable2TableAdapter.Fill(this._DataSet4_Factura.DataTable2, int.Parse(textBox1.Text));
                        this.dataTable3TableAdapter.Fill(this._DataSet4_Factura.DataTable3, int.Parse(textBox1.Text));
                        this.dataTable4TableAdapter.Fill(this._DataSet4_Factura.DataTable4, int.Parse(textBox1.Text));

                        this.reportViewer1.RefreshReport();
                        comandaintiala = int.Parse(textBox1.Text);

                    }
                    else
                    {
                        
                        MessageBox.Show("Va rugam introduceti o valoare numerica mai mare decat 0.", "Error");
                        textBox1.Text = $"{min}";

                        this.dataTable1TableAdapter.Fill(this._DataSet4_Factura.DataTable1, int.Parse(textBox1.Text));
                        this.dataTable2TableAdapter.Fill(this._DataSet4_Factura.DataTable2, int.Parse(textBox1.Text));
                        this.dataTable3TableAdapter.Fill(this._DataSet4_Factura.DataTable3, int.Parse(textBox1.Text));
                        this.dataTable4TableAdapter.Fill(this._DataSet4_Factura.DataTable4, int.Parse(textBox1.Text));

                        this.reportViewer1.RefreshReport();

                        button3.Enabled = true;
                        button2.Enabled = false;
                        
                    }
                    
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        
        // buton next
        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            int comandaidcur;
            if (textBox1.Text != "" && int.TryParse(textBox1.Text, out int rezultat))
            {
                comandaidcur = rezultat;
            }
            else
            {
                comandaidcur = comandaintiala;
            }
            string getnextcomanda = $"SELECT MIN(COM) FROM Comenzi WHERE COM>{comandaidcur};";
            stringconnection.connection.Open();
            OleDbCommand idCommand = new OleDbCommand(getnextcomanda, stringconnection.connection);
            int nextcomanda = Convert.ToInt32(idCommand.ExecuteScalar());
            stringconnection.connection.Close();
            textBox1.Text = $"{nextcomanda}";
            button3.Enabled = true;
            this.dataTable1TableAdapter.Fill(this._DataSet4_Factura.DataTable1, nextcomanda);
            this.dataTable2TableAdapter.Fill(this._DataSet4_Factura.DataTable2, nextcomanda);
            this.dataTable3TableAdapter.Fill(this._DataSet4_Factura.DataTable3, nextcomanda);
            this.dataTable4TableAdapter.Fill(this._DataSet4_Factura.DataTable4, nextcomanda);
            this.reportViewer1.RefreshReport();

            string getmaxcom = $"SELECT MAX(COM) FROM Comenzi";
            stringconnection.connection.Open();
            OleDbCommand idCommand2 = new OleDbCommand(getmaxcom, stringconnection.connection);
            int maxcom = Convert.ToInt32(idCommand2.ExecuteScalar());
            stringconnection.connection.Close();

            if (nextcomanda == maxcom)
            {
                button3.Enabled = false;
                button2.Enabled = true;
            }
            comandaintiala = nextcomanda;
        }

        //buton previous
        private void button2_Click(object sender, EventArgs e)
        {
                button3.Enabled = true;
                int comandaidcur;
                if (textBox1.Text != "" && int.TryParse(textBox1.Text, out int rezultat))
                {
                comandaidcur = rezultat;
                }
                else
                 {
                comandaidcur = comandaintiala;
                }
                string getprevcomanda = $"SELECT MAX(COM) FROM Comenzi WHERE COM<{comandaidcur};";
                stringconnection.connection.Open();
                OleDbCommand idCommand = new OleDbCommand(getprevcomanda, stringconnection.connection);
        
                int prevnrcomanda = Convert.ToInt32(idCommand.ExecuteScalar());
                stringconnection.connection.Close();
                textBox1.Text = $"{prevnrcomanda}";
                button3.Enabled = true;
                this.dataTable1TableAdapter.Fill(this._DataSet4_Factura.DataTable1, prevnrcomanda);
                this.dataTable2TableAdapter.Fill(this._DataSet4_Factura.DataTable2, prevnrcomanda);
                this.dataTable3TableAdapter.Fill(this._DataSet4_Factura.DataTable3, prevnrcomanda);
                this.dataTable4TableAdapter.Fill(this._DataSet4_Factura.DataTable4, prevnrcomanda);
                this.reportViewer1.RefreshReport();

                string getmincom = $"SELECT MIN(COM) FROM Comenzi";
                stringconnection.connection.Open();
                OleDbCommand idCommand2 = new OleDbCommand(getmincom, stringconnection.connection);
                int mincom = Convert.ToInt32(idCommand2.ExecuteScalar());
                stringconnection.connection.Close();

                if (prevnrcomanda == mincom)
                {
                    button2.Enabled = false;
                    button3.Enabled = true;
                }
                comandaintiala = prevnrcomanda;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form MainMenu = new MainMenu();
            MainMenu.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form avizmarfa = new avizmarfa();
            avizmarfa.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form CertificatGarantie = new CertificatGarantie();
            CertificatGarantie.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form ProceseVerbale = new ProceseVerbale();
            ProceseVerbale.ShowDialog();
        }

        private void devizeEstimativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form devizestimativ = new devizestimativ();
            devizestimativ.ShowDialog();
        }
    }
}
