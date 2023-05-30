using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddTehnicieni : Form
    {
        int codTehnician = 0;

        public List<ClassTehnicieni> tehnicieni = new List<ClassTehnicieni>();



        private void SelectTehnician(int codTehnician)
        {
            //CodClient
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox12.Text = tehnicieni[codTehnician]._CODTehnician;
            textBox1.Text = tehnicieni[codTehnician]._Nume;
            textBox2.Text = tehnicieni[codTehnician]._Prenume;
            textBox3.Text = tehnicieni[codTehnician]._Telefon;
            textBox4.Text = tehnicieni[codTehnician]._Email;
            textBox5.Text = tehnicieni[codTehnician]._Strada;
            textBox6.Text = tehnicieni[codTehnician]._StrNr;
            textBox7.Text = tehnicieni[codTehnician]._Localitate;

            // select servicii active
            string SelectServicii = $"SELECT CODService, NumeServ FROM Servicii;";


            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(SelectServicii, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bool serviciuactiv = false;

                // verificam daca serviciul este atasat de tehnician
                string Selectcod = $"SELECT CodTehnician, CodService FROM ServiciiTehnician WHERE CodService = {reader.GetInt32(0)}";
                OleDbCommand command2 = new OleDbCommand(Selectcod, stringconnection.connection);
                OleDbDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())
                {
                    if (reader2["CodTehnician"].ToString() == textBox12.Text)
                    {
                        listBox2.Items.Add(reader.GetString(1));
                        serviciuactiv = true;
                        break;
                    }
                }

                // daca serviciul nu e atasat de tehnician, adaugam in listbox1
                if (!serviciuactiv)
                {
                    listBox1.Items.Add(reader.GetString(1));
                }

                reader2.Close(); // inchidem readerul dupa fiecare iteratie
            }

            reader.Close();
            stringconnection.connection.Close();

        }





        public AddTehnicieni()
        {
            InitializeComponent();
        }

        private void Tehnicieni_Load(object sender, EventArgs e)
        {
            // select tehnicieni

            string SelectTehnicieni = $"SELECT CODTehnician, Nume, Prenume, Telefon, Email, Strada, StrNr, Localitate FROM Tehnicieni ORDER By CODTehnician;";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(SelectTehnicieni, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ClassTehnicieni tehnician = new ClassTehnicieni(reader["CODTehnician"].ToString(), reader["Nume"].ToString(), reader["Prenume"].ToString(),
                    reader["Telefon"].ToString(), reader["Email"].ToString(), reader["Strada"].ToString(), reader["StrNr"].ToString(),
                    reader["Localitate"].ToString());

                // adaugare in lista obiectul de mai sus
                tehnicieni.Add(tehnician);
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
            button3.Enabled = false;
            button1.Enabled = false;

            SelectTehnician(codTehnician);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            codTehnician++;
            SelectTehnician(codTehnician);
            button1.Enabled = true;
            if (codTehnician == tehnicieni.Count - 1)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codTehnician--;
            SelectTehnician(codTehnician);
            button2.Enabled = true;
            if (codTehnician == 0)
            {
                button1.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
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
            textBox12.Text = "Tehnician Nou";

            string NumeServicii = $"SELECT NumeServ FROM Servicii;";


            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(NumeServicii, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader.GetString(0));
            }
            stringconnection.connection.Close();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form AddTehnicieni = new AddTehnicieni();
            this.Hide();
            AddTehnicieni.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null && listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems != null && listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
              && textBox7.Text != "" && listBox2.Items.Count > 0)
                {

                    if (textBox12.Text == "Tehnician Nou")
                    {
                        string InsertTehnician = $"INSERT INTO Tehnicieni (Nume, Prenume, Telefon, Email, Strada, StrNr, Localitate) " +
                                                 $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', {textBox6.Text}, '{textBox7.Text}');";
                        stringconnection.connection.Open();
                        OleDbCommand command2 = new OleDbCommand(InsertTehnician, stringconnection.connection);
                        command2.ExecuteNonQuery();

                        // preluam tehnician ID
                        int insertedTechnicianID;
                        string selectMaxCodT = "SELECT MAX(CodTehnician) FROM Tehnicieni;";
                        OleDbCommand command3 = new OleDbCommand(selectMaxCodT, stringconnection.connection);
                        OleDbDataReader maxCodT = command3.ExecuteReader();
                        if (maxCodT.Read() && !maxCodT.IsDBNull(0))
                        {
                            insertedTechnicianID = (int)maxCodT.GetValue(0);
                        }
                        else
                        {
                            
                            MessageBox.Show("Nu se poate obtine ID-ul tehnicianului.");
                            return;
                        }

                        // inserare service nou
                        foreach (string selectedItems in listBox2.Items)
                        {
                            string SelectCodService = $"SELECT CODService FROM Servicii WHERE NumeServ = '{selectedItems}'";

                            OleDbCommand command4 = new OleDbCommand(SelectCodService, stringconnection.connection);
                            OleDbDataReader reader = command4.ExecuteReader();

                            if (reader.Read())
                            {
                                // serviciul exista in baza de date
                                int codService = reader.GetInt32(0);
                                string InsertServiciu = $"INSERT INTO ServiciiTehnician (CodTehnician, CodService) VALUES ({insertedTechnicianID}, {codService})";
                                OleDbCommand command7 = new OleDbCommand(InsertServiciu, stringconnection.connection);
                                command7.ExecuteNonQuery();
                            }
                            else
                            {
                                // serviciul nu exista in baza de date
                                MessageBox.Show($"Serviciul '{selectedItems}' nu exista in baza de date.");
                            }

                            reader.Close();
                        }


                    //update statement in actiuni
                    string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                    OleDbCommand command6 = new OleDbCommand(getCODAgent, stringconnection.connection);
                    int codagent = (int)command6.ExecuteScalar();

                    string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Insert Tehnician', 'A inserat tehnicianul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                    OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                    command5.ExecuteNonQuery();


                    MessageBox.Show($"Am inserat tehnicianul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddTehnicieni = new AddTehnicieni();
                        this.Hide();
                        AddTehnicieni.ShowDialog();
                    }
                    else
                    {
                        // update tehnician
                        string UpdateTehnician = $"UPDATE Tehnicieni SET Nume = '{textBox1.Text}', Prenume = '{textBox2.Text}', Telefon = '{textBox3.Text}', " +
                         $"Email = '{textBox4.Text}', Strada = '{textBox5.Text}', StrNr = {textBox6.Text}, " +
                         $"Localitate = '{textBox7.Text}' WHERE CODTehnician = {textBox12.Text};";
                        OleDbCommand command = new OleDbCommand(UpdateTehnician, stringconnection.connection);
                        stringconnection.connection.Open();
                        command.ExecuteNonQuery();

                        foreach (string selectedItems in listBox2.Items)
                        {
                                string SelectServicii = $"SELECT COUNT(ServiciiTehnician.CodService) FROM (ServiciiTehnician INNER JOIN Servicii ON ServiciiTehnician.CodService = Servicii.CODService) " +
                                $"WHERE ServiciiTehnician.CodTehnician = {textBox12.Text} " +
                                $"AND Servicii.NumeServ = '{selectedItems}'";
                            OleDbCommand command2 = new OleDbCommand(SelectServicii, stringconnection.connection);
                            int count = (int)command2.ExecuteScalar();


                            if (count == 0)
                            {
                                string SelectCodService = $"SELECT CODService FROM Servicii WHERE NumeServ = '{selectedItems}';";
                                OleDbCommand command4 = new OleDbCommand(SelectCodService, stringconnection.connection);
                                OleDbDataReader reader = command4.ExecuteReader();

                                if (reader.Read())
                                {
                                    // Serviciul nu exista, il adaugam
                                    string InsertServiciu = $"INSERT INTO ServiciiTehnician (CodTehnician, CodService) VALUES ({textBox12.Text},{reader["CODService"]})";
                                    OleDbCommand command3 = new OleDbCommand(InsertServiciu, stringconnection.connection);
                                    command3.ExecuteNonQuery();
                                }
                                else
                                {
                                    // Serviciul nu exista in baza de date
                                    MessageBox.Show("Serviciul nu exista in baza de date.");
                                }
                            }

                        }

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command6 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command6.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Tehnician', 'A updatat tehnicianul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();

                        MessageBox.Show($"Am updatat tehnicianul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddTehnicieni = new AddTehnicieni();
                        this.Hide();
                        AddTehnicieni.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate.", "Error");
                }
        }
            catch
            {
                MessageBox.Show($"Va rugam sa inserati numeric in tabela Str. Nr." +
                    $"\nValoarea introdusa este: {textBox6.Text} ", "Error");
                stringconnection.connection.Close();
                Form AddTehnicieni = new AddTehnicieni();
                this.Hide();
        AddTehnicieni.ShowDialog();
            }
}
    }
}
