using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddSofer : Form
    {

        int codSofer = 0;

        public List<ClassSoferi> soferi = new List<ClassSoferi>();
        public List<ClassVehicule> vehicule = new List<ClassVehicule>();

        public AddSofer()
        {
            InitializeComponent();
        }




        //private void SelectVehiculeCurent(int codSofer)
        //{
        //    stringconnection.connection.Open();
        //    string vehiculcurent = $"SELECT Vehicule.Nume, Vehicule.Serie " +
        //                           $"FROM Vehicule " +
        //                           $"LEFT JOIN Soferi ON Vehicule.CodVehicul = Soferi.CodVehicul " +
        //                           $"WHERE Soferi.CODSofer = {codSofer};";
        //    OleDbCommand command3 = new OleDbCommand(vehiculcurent, stringconnection.connection);
        //    OleDbDataReader reader3 = command3.ExecuteReader();
        //    if (reader3.Read())
        //    {
        //        textBox13.Text = reader3.GetString(0) + " " + reader3.GetString(1);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Nu am gasit intrari.", "Error");
        //    }


        //    reader3.Close();
        //    stringconnection.connection.Close();
        //}

        private void SelectSofer(int codSofer)
        {
            //CodClient
            textBox12.Text = soferi[codSofer]._CODSofer;
            textBox1.Text = soferi[codSofer]._Nume;
            textBox2.Text = soferi[codSofer]._Prenume;
            textBox3.Text = soferi[codSofer]._CNP;
            textBox4.Text = soferi[codSofer]._CNPSerie;
            textBox5.Text = soferi[codSofer]._CNPSerieNr;
            textBox6.Text = soferi[codSofer]._CNPUnitElib;
            textBox7.Text = soferi[codSofer]._Strada;
            textBox8.Text = soferi[codSofer]._StrNr;
            textBox9.Text = soferi[codSofer]._Localitate;
            textBox10.Text = soferi[codSofer]._Telefon;
            textBox11.Text = soferi[codSofer]._Email;
            foreach (ClassVehicule V in vehicule)
            {
                if (soferi[codSofer]._CODVehicul == V._CodVehicul)
                {
                    textBox13.Text = V._Nume + " " + V._Serie;
                }
            }
            //SelectVehiculeCurent(codSofer);

        }

        private void AddSofer_Load(object sender, EventArgs e)
        {

            string SelectSoferi = $"SELECT CodSofer, Nume, Prenume, CNP, CNPSerie, CNPSerieNr, CNPUnitElib, Strada, StrNr, Localitate, Telefon," +
$"Email, CODVehicul FROM Soferi;";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(SelectSoferi, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ClassSoferi sofer = new ClassSoferi(reader["CODSofer"].ToString(), reader["Nume"].ToString(), reader["Prenume"].ToString(),
                    reader["CNP"].ToString(), reader["CNPSerie"].ToString(), reader["CNPSerieNr"].ToString(), reader["CNPUnitElib"].ToString(),
                    reader["Strada"].ToString(), reader["StrNr"].ToString(), reader["Localitate"].ToString(), reader["Telefon"].ToString(), reader["Email"].ToString(),
                    reader["CODVehicul"].ToString());

                // adaugare in lista obiectul de mai sus
                soferi.Add(sofer);
            }
            reader.Close();

            string SelectVehicul = "SELECT Vehicule.Nume, Vehicule.Serie " +
                                   "FROM Vehicule " +
                                   "LEFT JOIN Soferi ON Vehicule.CodVehicul = Soferi.CodVehicul " +
                                   "WHERE Soferi.CODVehicul IS NULL";
            OleDbCommand command2 = new OleDbCommand(SelectVehicul, stringconnection.connection);
            OleDbDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2.GetString(0) + " " + reader2.GetString(1));

            }

            reader2.Close();


            // select Vehicule
            string SelectVehicule = $"SELECT CodVehicul, Nume, Serie, An, DataImatri, NrImatri, UltMentenanta FROM Vehicule;";
            OleDbCommand command3 = new OleDbCommand(SelectVehicule, stringconnection.connection);
            OleDbDataReader reader3 = command3.ExecuteReader();

            while (reader3.Read())
            {
                ClassVehicule vehicul = new ClassVehicule(reader3["CodVehicul"].ToString(), reader3["Nume"].ToString(), reader3["Serie"].ToString(),
                    reader3["An"].ToString(), reader3["DataImatri"].ToString(), reader3["NrImatri"].ToString(), reader3["UltMentenanta"].ToString());

                // adaugare in lista obiectul de mai sus
                vehicule.Add(vehicul);
            }
            reader3.Close();



            // VehiculCurent


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
            textBox13.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = false;
            comboBox1.Enabled = false;

            SelectSofer(codSofer);

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
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button6.Enabled = false;
            comboBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
    && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")
                {


                    if (textBox12.Text == "Sofer Nou" && comboBox1.SelectedItem != null && textBox13.Text == "Vehicul Nou")
                    {
                        int codVehicul = 0;

                        string selectedVehicul = comboBox1.SelectedItem.ToString();
                        string[] numv = selectedVehicul.Split(' ');
                        string NumeVeh = numv[0];
                        string Serie = numv[1];
                        string obtinerecod = $"SELECT CODVehicul FROM Vehicule WHERE Nume = '{NumeVeh}' AND Serie = '{Serie}';";
                        stringconnection.connection.Open();
                        OleDbCommand command1 = new OleDbCommand(obtinerecod, stringconnection.connection);
                        codVehicul = (int)command1.ExecuteScalar();

                        // insert sofer nou
                        string InsertSofer = $"INSERT INTO Soferi (Nume, Prenume, CNP, CNPSerie, CNPSerieNr, CNPUnitElib, Strada, StrNr, " +
                         $"Localitate, Telefon, Email, CODVehicul) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', " +
                         $"'{textBox7.Text}', '{textBox8.Text}', '{textBox9.Text}', '{textBox10.Text}', '{textBox11.Text}', {codVehicul});";

                        OleDbCommand command2 = new OleDbCommand(InsertSofer, stringconnection.connection);
                        command2.ExecuteNonQuery();

                        //insert statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Insert Sofer', 'A inserat soferul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();


                        MessageBox.Show($"Am inserat soferul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddSofer = new AddSofer();
                        this.Hide();
                        AddSofer.ShowDialog();
                    }

                    else if (comboBox1 != null && comboBox1.SelectedItem != null)

                    {
                        int codVehicul = 0;

                        string selectedVehicul = comboBox1.SelectedItem.ToString();
                        string[] numv = selectedVehicul.Split(' ');
                        string NumeVeh = numv[0];
                        string Serie = numv[1];
                        string obtinerecod = $"SELECT CODVehicul FROM Vehicule WHERE Nume = '{NumeVeh}' AND Serie = '{Serie}';";



                        stringconnection.connection.Open();
                        OleDbCommand command1 = new OleDbCommand(obtinerecod, stringconnection.connection);
                        codVehicul = (int)command1.ExecuteScalar();

                        string UpdateVehicul = $"UPDATE Soferi SET Nume = '{textBox1.Text}', Prenume = '{textBox2.Text}', CNP = '{textBox3.Text}'" +
                        $", CNPSerie = '{textBox4.Text}', CNPSerieNr = '{textBox5.Text}', CNPUnitElib = '{textBox6.Text}', Strada = '{textBox7.Text}', " +
                        $"StrNr = '{textBox8.Text}', Localitate = '{textBox9.Text}', Telefon = '{textBox10.Text}', Email = '{textBox11.Text} ' " +
                        $", CodVehicul = {codVehicul} WHERE CODSofer = {textBox12.Text};";
                        OleDbCommand command = new OleDbCommand(UpdateVehicul, stringconnection.connection);

                        command.ExecuteNonQuery();

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Sofer', 'A updatat masina soferului {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();

                        MessageBox.Show($"Am updtat soferul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddSofer = new AddSofer();
                        this.Hide();
                        AddSofer.ShowDialog();
                    }

                    else if (comboBox1.SelectedItem == null && textBox12.Text != "Sofer Nou")
                    {
                        // update sofer fara a modifica masina
                        string UpdateVehicul = $"UPDATE Soferi SET Nume = '{textBox1.Text}', Prenume = '{textBox2.Text}', CNP = '{textBox3.Text}'" +
                             $", CNPSerie = '{textBox4.Text}', CNPSerieNr = '{textBox5.Text}', CNPUnitElib = '{textBox6.Text}', Strada = '{textBox7.Text}', " +
                             $"StrNr = '{textBox8.Text}', Localitate = '{textBox9.Text}', Telefon = '{textBox10.Text}', Email = '{textBox11.Text} ' " +
                             $" WHERE CODSofer = {textBox12.Text};";
                        OleDbCommand command = new OleDbCommand(UpdateVehicul, stringconnection.connection);
                        stringconnection.connection.Open();
                        command.ExecuteNonQuery();

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Sofer', 'A updatat soferul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();

                        MessageBox.Show($"Am updatat client-ul {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddSofer = new AddSofer();
                        this.Hide();
                        AddSofer.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate.", "Error");
                    }

                }
                else
                {
                    MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate.", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Va rugam sa completati toate campurile si sa introduceti valori numerice" +
                    " pentru CNP si CNP serie.", "Error");
                stringconnection.connection.Close();
                Form AddSofer = new AddSofer();
                this.Hide();
                AddSofer.ShowDialog();
                this.Close();
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
            textBox12.Text = "Sofer Nou";
            textBox13.Text = "Vehicul Nou";
            comboBox1.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form AddSofer = new AddSofer();
            this.Hide();
            AddSofer.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            codSofer++;
            SelectSofer(codSofer);
            button1.Enabled = true;
            if (codSofer == soferi.Count - 1)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codSofer--;
            SelectSofer(codSofer);
            button2.Enabled = true;
            if (codSofer == 0)
            {
                button1.Enabled = false;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Daca in lista nu apare nici un vehicul, inseamna exista vehicule valabile in acest moment.", "Information");
        }
    }
}
