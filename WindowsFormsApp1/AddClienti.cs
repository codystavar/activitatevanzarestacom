using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddClienti : Form
    {
        int codClient = 0;


        // create lista
        public List<ClassClienti> clienti = new List<ClassClienti>();

        public AddClienti()
        {
            InitializeComponent();
        }


        private void SelectClient(int codClient)
        {
            //CodClient
            textBox12.Text = clienti[codClient]._CodClient;
            textBox1.Text = clienti[codClient]._Nume;
            textBox2.Text = clienti[codClient]._Prenume;
            textBox3.Text = clienti[codClient]._Strada;
            textBox4.Text = clienti[codClient]._StrNr;
            textBox5.Text = clienti[codClient]._Localitate;
            textBox6.Text = clienti[codClient]._Telefon;
            textBox7.Text = clienti[codClient]._Email;
            textBox8.Text = clienti[codClient]._RegCom;
            textBox9.Text = clienti[codClient]._CIF;
            textBox10.Text = clienti[codClient]._IBAN;
            textBox11.Text = clienti[codClient]._Banca;

        }
        private void AddClienti_Load(object sender, EventArgs e)
        {


            // select
            string SelectClienti = $"SELECT CodClient, Nume, Prenume, Strada, StrNr, Localitate, Telefon, Email, RegCom, CIF, IBAN," +
$"Banca FROM Clienti;";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(SelectClienti, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ClassClienti client = new ClassClienti(reader["CodClient"].ToString(), reader["Nume"].ToString(), reader["Prenume"].ToString(),
                    reader["Strada"].ToString(), reader["StrNr"].ToString(), reader["Localitate"].ToString(), reader["Telefon"].ToString(),
                    reader["Email"].ToString(), reader["RegCom"].ToString(), reader["CIF"].ToString(), reader["IBAN"].ToString(), reader["Banca"].ToString());

                // adaugare in lista obiectul de mai sus
                clienti.Add(client);
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
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = false;

            SelectClient(codClient);

        }


        // buton next
        private void button2_Click(object sender, EventArgs e)
        {
            codClient++;
            SelectClient(codClient);
            button1.Enabled = true;
            if (codClient == clienti.Count - 1)
            {
                button2.Enabled = false;
            }
        }

        // buton prev
        private void button1_Click(object sender, EventArgs e)
        {

            codClient--;
            SelectClient(codClient);
            button2.Enabled = true;
            if (codClient == 0)
            {
                button1.Enabled = false;
            }
        }

        // buton update
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
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button6.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
    && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")
                {

                    if (textBox12.Text == "Client Nou")
                    {
                        // insert client nou
                        string InsertClienti = $"INSERT INTO Clienti (Nume, Prenume, Strada, StrNr, Localitate, Telefon, Email, RegCom, " +
                         $"CIF, IBAN, Banca) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', " +
                         $"'{textBox7.Text}', '{textBox8.Text}', '{textBox9.Text}', '{textBox10.Text}', '{textBox11.Text}');";
                        stringconnection.connection.Open();


                    //insert statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Insert Client', 'A inserat clientul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();

                        OleDbCommand command2 = new OleDbCommand(InsertClienti, stringconnection.connection);
                        command2.ExecuteNonQuery();
                        MessageBox.Show($"Am inserat clientul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        this.Dispose();
                        Form Addclienti = new AddClienti();
                        Addclienti.ShowDialog();
                    }
                    else
                    {
                        // update client deja exstent
                        string UpdateClienti = $"UPDATE Clienti SET Nume = '{textBox1.Text}', Prenume = '{textBox2.Text}', Strada = '{textBox3.Text}'" +
                         $", StrNr = '{textBox4.Text}', Localitate = '{textBox5.Text}', Telefon = '{textBox6.Text}', Email = '{textBox7.Text}', " +
                         $"RegCom = '{textBox8.Text}', CIF = '{textBox9.Text}', IBAN = '{textBox10.Text}', Banca = '{textBox11.Text}' WHERE CODClient = {textBox12.Text};";
                        OleDbCommand command = new OleDbCommand(UpdateClienti, stringconnection.connection);


                        stringconnection.connection.Open();

                        command.ExecuteNonQuery();

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command2 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command2.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Client', 'A updatat clientul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                         OleDbCommand command3 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                         command3.ExecuteNonQuery();

                        MessageBox.Show($"Am updatat clientul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        this.Dispose();
                        Form Addclienti = new AddClienti();
                        Addclienti.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate.", "Error");
                }
            }
            catch
            {
                MessageBox.Show($"Campul Str. Nr. contine caractere non-numerice: {textBox4.Text}. Va rugam sa introduceti numere.", "Error");
                stringconnection.connection.Close();
                Form Addclienti = new AddClienti();
                this.Hide();
                Addclienti.ShowDialog();
            }

        }

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
            textBox10.Enabled = true;
            textBox11.Enabled = true;
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
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "Client Nou";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form MainMenu = new MainMenu();
            MainMenu.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddClienti = new AddClienti();;
            AddClienti.ShowDialog();
        }
    }
}
