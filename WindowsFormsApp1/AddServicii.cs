using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddServicii : Form
    {
        int codService = 0;

        public List<ClassServicii> servicii = new List<ClassServicii>();

        private void SelectServiciu(int codService)
        {
            //CodClient
            textBox12.Text = servicii[codService]._CODService;
            textBox1.Text = servicii[codService]._NumeServ;
            textBox2.Text = servicii[codService]._PretServ;
            textBox3.Text = servicii[codService]._Descriere;

        }


        public AddServicii()
        {
            InitializeComponent();
        }

        private void AddServicii_Load(object sender, EventArgs e)
        {

            string SelectServicii = $"SELECT CODService, NumeServ, PretServ, Descriere FROM Servicii;";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(SelectServicii, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ClassServicii serviciu = new ClassServicii(reader["CODService"].ToString(), reader["NumeServ"].ToString(), reader["PretServ"].ToString(),
                    reader["Descriere"].ToString());

                // adaugare in lista obiectul de mai sus
                servicii.Add(serviciu);
            }
            reader.Close();
            stringconnection.connection.Close();


            SelectServiciu(codService);

            // textboxuri disabled
            textBox12.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            codService++;
            SelectServiciu(codService);
            button1.Enabled = true;
            if (codService == servicii.Count - 1)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codService--;
            SelectServiciu(codService);
            button2.Enabled = true;
            if (codService == 0)
            {
                button1.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form AddServicii = new AddServicii();
            this.Hide();
            AddServicii.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox12.Text = "Nou";
            button1.Enabled = false;
            button2.Enabled = false;
            button6.Enabled = false;
            button3.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    if (textBox12.Text == "Nou")
                    {
                        // insert serviciu nou
                        string InsertService = $"INSERT INTO Servicii (NumeServ, PretServ, Descriere)" +
                         $" VALUES ('{textBox1.Text}', {textBox2.Text}, '{textBox3.Text}')";
                        stringconnection.connection.Open();
                        OleDbCommand command2 = new OleDbCommand(InsertService, stringconnection.connection);
                        command2.ExecuteNonQuery();

                        //insert statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Insert Serviciu', 'A inserat serviciul {textBox1.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();


                        MessageBox.Show($"Am inserat serviciul {textBox1.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddServicii = new AddServicii();
                        this.Hide();
                        AddServicii.ShowDialog();
                    }
                    else
                    {
                        // update serviciu
                        string UpdateService = $"UPDATE Servicii SET NumeServ = '{textBox1.Text}', PretServ = {textBox2.Text}, Descriere = '{textBox3.Text}'" +
                         $" WHERE CodService = {textBox12.Text};";
                        OleDbCommand command = new OleDbCommand(UpdateService, stringconnection.connection);
                        stringconnection.connection.Open();
                        command.ExecuteNonQuery();

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Serviciu', 'A updatat serviciul {textBox1.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();

                        MessageBox.Show($"Am updatat serviciul {textBox1.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddServicii = new AddServicii();
                        this.Hide();
                        AddServicii.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate.", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Va rugam sa va asigurati ca numele servicului este unic si ca introduceti numere in Pret Serviciu.", "Error");
                stringconnection.connection.Close();
                Form AddServicii = new AddServicii();
                this.Hide();
                AddServicii.ShowDialog();
            }
        }
    }
}
