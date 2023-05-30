using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddAgenti : Form
    {
        int codAgent = 0;

        // create lista
        public List<ClassAgenti> agenti = new List<ClassAgenti>();


        public AddAgenti()
        {
            InitializeComponent();
        }


        private void SelectAgent(int codAgent)
        {
            //CodClient
            textBox12.Text = agenti[codAgent]._CodAgent;
            textBox1.Text = agenti[codAgent]._Nume;
            textBox2.Text = agenti[codAgent]._Prenume;
            textBox3.Text = agenti[codAgent]._Telefon;
            textBox4.Text = agenti[codAgent]._Email;
            textBox5.Text = agenti[codAgent]._Strada;
            textBox6.Text = agenti[codAgent]._StrNr;
            textBox7.Text = agenti[codAgent]._Localitate;
            textBox8.Text = agenti[codAgent]._username;
            textBox9.Text = agenti[codAgent]._password;

        }

        //buton reset
        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddAgenti = new AddAgenti();
            AddAgenti.ShowDialog();
        }

        //buton inapoi
        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form MainMenu = new MainMenu();
            MainMenu.ShowDialog();
        }

        // buton new
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button6.Enabled = false;
            button3.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox12.Text = "Agent Nou";
        }



        private void AddAgenti_Load(object sender, EventArgs e)
        {
            // select
            string SelectAgenti = $"SELECT CodAgent, Nume, Prenume, Telefon, Email, Strada, StrNr, Localitate, username, password FROM Agenti";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(SelectAgenti, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ClassAgenti agent = new ClassAgenti(reader["CodAgent"].ToString(), reader["Nume"].ToString(), reader["Prenume"].ToString(),
                    reader["Telefon"].ToString(), reader["Email"].ToString(), reader["Strada"].ToString(), reader["StrNr"].ToString(),
                    reader["Localitate"].ToString(), reader["username"].ToString(), reader["password"].ToString());

                // adaugare in lista obiectul de mai sus
                agenti.Add(agent);
            }
            reader.Close();
            stringconnection.connection.Close();


            // textboxuri disabled
            textBox12.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;

            button3.Enabled = false;
            button1.Enabled = false;

            SelectAgent(codAgent);
        }


        //buton previous
        private void button1_Click(object sender, EventArgs e)
        {
            codAgent--;
            SelectAgent(codAgent);
            button2.Enabled = true;
            if (codAgent == 0)
            {
                button1.Enabled = false;
            }
        }

        //buton next
        private void button2_Click(object sender, EventArgs e)
        {
            codAgent++;
            SelectAgent(codAgent);
            button1.Enabled = true;
            if (codAgent == agenti.Count - 1)
            {
                button2.Enabled = false;
            }
        }

        //buton update
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        //buton save
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
&& textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {

                if (textBox12.Text == "Agent Nou")
                {
                    // insert agent nou
                    string InsertAgenti = $"INSERT INTO Agenti (Nume, Prenume, Telefon, Email, Strada, StrNr, Localitate, username, [password]) " +
                     $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', " +
                     $"'{textBox7.Text}', '{textBox8.Text}', '{textBox9.Text}');";
                    stringconnection.connection.Open();


                    //insert statement in actiuni
                    string getCODAgent2 = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                    OleDbCommand command4 = new OleDbCommand(getCODAgent2, stringconnection.connection);
                    int codagent2 = (int)command4.ExecuteScalar();

                    string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Insert Agent', 'A inserat Agentul {textBox1.Text} {textBox2.Text}', Now(), {codagent2})";

                    OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                    command5.ExecuteNonQuery();

                    OleDbCommand command2 = new OleDbCommand(InsertAgenti, stringconnection.connection);
                    command2.ExecuteNonQuery();
                    MessageBox.Show($"Am inserat agentul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                    stringconnection.connection.Close();
                    this.Dispose();
                    Form AddAgenti = new AddAgenti();
                    AddAgenti.ShowDialog();
                }
                else
                {
                    // update agent deja exstent [password] e rezervat in majoritatea SGDB
                    string UpdateAgenti = $"UPDATE Agenti SET Nume = '{textBox1.Text}', Prenume = '{textBox2.Text}', Telefon = '{textBox3.Text}', " +
                        $"Email = '{textBox4.Text}', Strada = '{textBox5.Text}', StrNr = '{textBox6.Text}', Localitate = '{textBox7.Text}', " +
                        $"username = '{textBox8.Text}', [password] = '{textBox9.Text}' WHERE CODAgent = {textBox12.Text};";
                    OleDbCommand command = new OleDbCommand(UpdateAgenti, stringconnection.connection);


                    stringconnection.connection.Open();
                    command.ExecuteNonQuery();

                    //update statement in actiuni
                    string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                    OleDbCommand command2 = new OleDbCommand(getCODAgent, stringconnection.connection);
                    int codagent = (int)command2.ExecuteScalar();

                    string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Agent', 'A updatat agentul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                    OleDbCommand command3 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                    command3.ExecuteNonQuery();

                    MessageBox.Show($"Am updatat agentul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                    stringconnection.connection.Close();
                    this.Dispose();
                    Form AddAgenti = new AddAgenti();
                    AddAgenti.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate.", "Error");
            }
        }
            catch
            {
                MessageBox.Show($"Va rugam sa va asigurati ca ati inserat numere in campul Str. Nr. si/sau numele de utilizator este unic.", "Error");
                stringconnection.connection.Close();
                this.Dispose();
                Form AddAgenti = new AddAgenti();
                AddAgenti.ShowDialog();
            }
}
    }
}
