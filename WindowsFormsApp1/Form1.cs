using System;
using System.Data.OleDb;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddClienti = new AddClienti();
            AddClienti.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // disable labeluri videoformate
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false; 
            label5.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            // label Videoformate/Rapoarte
            label8.Visible = false;
            label30.Visible = false;
            //picturebox videoformate
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;


            // groupbox2
            groupBox2.Visible = false;
            // label rapoarte
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;

            string numeagent = $"SELECT CODAgent, Nume, Prenume FROM Agenti WHERE username ='{stringconnection.username}'";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(numeagent, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string nameagent = reader.GetString(1);
                string prenumeagent = reader.GetString(2);
                label9.Text = $"Utilizator logat:\n {nameagent}" + " " + $"{prenumeagent}";

            }
            reader.Close();
            stringconnection.connection.Close();
        }


        // buton vanzare
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form MenuVanzare = new MenuVanzare();
            MenuVanzare.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // disable labeluri videoformate
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            // label Videoformate
            label8.Visible = true;
            label30.Visible = false;
            // eliminare text intial
            label1.Visible = false;
            // picturebox videoformate
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            //
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = true;

            // groupbox2
            groupBox2.Visible = false;
            // label rapoarte
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;

        }

        // buton log out
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form Login = new Login();
            Login.ShowDialog();
        }

        // Add/edit
        // clienti
        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddClienti = new AddClienti();
            AddClienti.ShowDialog();
        }

        // agenti
        private void label10_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddAgenti = new AddAgenti();
            AddAgenti.ShowDialog();
        }

        // soferi
        private void label7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddSofer = new AddSofer();
            AddSofer.ShowDialog();
        }

        // tehnicieni
        private void label5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddTehnicieni = new AddTehnicieni();
            AddTehnicieni.ShowDialog();
        }

        // produse
        private void label4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddProduse = new AddProduse();
            AddProduse.ShowDialog();
        }

        // servicii
        private void label11_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddServicii = new AddServicii();
            AddServicii.ShowDialog();
        }

        // vehicule
        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddVehicule = new AddVehicule();
            AddVehicule.ShowDialog();
        }

        // buton rapoarte
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;

            // disable labeluri videoformate
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            // label Videoformate
            label8.Visible = false;
            // eliminare text intial
            label1.Visible = false;
            // picturebox videoformate
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            // groupbox2
            groupBox2.Visible = true;
            // label rapoarte
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label28.Visible = true;
            label29.Visible = true;
            // label rapoarte
            label8.Visible = false;
            label30.Visible = true;

        }

        // rapoarte

        // clienti
        private void label13_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form SelectClienti = new SelectClienti();
            SelectClienti.ShowDialog();
        }

        // produse
        private void label14_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form SelectProduseValabile = new SelectProduseValabile();
            SelectProduseValabile.ShowDialog();
        }

        // soferi
        private void label15_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form RaportSelectSofer = new RaportSelectSofer();
            RaportSelectSofer.ShowDialog();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form RaportSTehnician = new RaportSTehnician();
            RaportSTehnician.ShowDialog();

        }

        //agenti
        private void label21_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form listaagenti = new listaagenti();
            listaagenti.ShowDialog();
        }

        // facturi
        private void label23_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form Facturi = new Facturi();
            Facturi.ShowDialog();
        }

        // certificate garantie
        private void label25_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form CertificatGarantie = new CertificatGarantie();
            CertificatGarantie.ShowDialog();
        }

        // avize de insotire
        private void label24_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form avizmarfa = new avizmarfa();
            avizmarfa.ShowDialog();
        }

        // devize estimative
        private void label26_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form devizestimativ = new devizestimativ();
            devizestimativ.ShowDialog();
        }

        // procese verbale
        private void label29_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form ProceseVerbale = new ProceseVerbale();
            ProceseVerbale.ShowDialog();
        }

        // cele mai vandute produse
        private void label18_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form RaportFProduse = new RaportFProduse();
            RaportFProduse.ShowDialog();
        }

        // cele mai folosite servicii
        private void label19_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form RaportFServicii = new RaportFServicii();
            RaportFServicii.ShowDialog();
        }

        // raport top tehnicieni
        private void label20_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form RaportTopClienti = new RaportTopClienti();
            RaportTopClienti.ShowDialog();
        }

        // logs
        private void label28_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form loguri = new loguri();
            loguri.ShowDialog();
        }
    }
    
}
