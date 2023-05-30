using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddVehicule : Form
    {

        int codVehicul = 0;

        public List<ClassVehicule> vehicule = new List<ClassVehicule>();

        public AddVehicule()
        {
            InitializeComponent();
        }

        private void SelectVehicul(int codVehicul)
        {
            //CodClient
            textBox12.Text = vehicule[codVehicul]._CodVehicul;
            textBox1.Text = vehicule[codVehicul]._Nume;
            textBox2.Text = vehicule[codVehicul]._Serie;
            textBox3.Text = vehicule[codVehicul]._An;
            textBox4.Text = vehicule[codVehicul]._DataImatri;
            textBox5.Text = vehicule[codVehicul]._NrImatri;
            textBox6.Text = vehicule[codVehicul]._UltMentenanta;

        }

        private void AddVehicule_Load(object sender, EventArgs e)
        {

            // select
            string SelectVehicule = $"SELECT CodVehicul, Nume, Serie, An, DataImatri, NrImatri, UltMentenanta FROM Vehicule;";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(SelectVehicule, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ClassVehicule vehicul = new ClassVehicule(reader["CodVehicul"].ToString(), reader["Nume"].ToString(), reader["Serie"].ToString(),
                    reader["An"].ToString(), reader["DataImatri"].ToString(), reader["NrImatri"].ToString(), reader["UltMentenanta"].ToString());

                // adaugare in lista obiectul de mai sus
                vehicule.Add(vehicul);
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
            button1.Enabled = false;
            button3.Enabled = false;


            SelectVehicul(codVehicul);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            codVehicul++;
            SelectVehicul(codVehicul);
            button1.Enabled = true;
            if (codVehicul == vehicule.Count - 1)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codVehicul--;
            SelectVehicul(codVehicul);
            button2.Enabled = true;
            if (codVehicul == 0)
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
            button3.Enabled = true;
            button4.Enabled = false;
            button6.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox12.Text = "Vehicul Nou";
            button1.Enabled = false;
            button2.Enabled = false;
            button6.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
                    && !textBox2.Text.Contains(" "))
                {

                    if (textBox12.Text == "Vehicul Nou")
                    {
                        // insert client nou
                        string InsertClienti = $"INSERT INTO Vehicule (Nume, Serie, An, DataImatri, NrImatri, UltMentenanta)" +
                         $" VALUES ('{textBox1.Text}', '{textBox2.Text}', {textBox3.Text}, '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}');";
                        stringconnection.connection.Open();
                        OleDbCommand command2 = new OleDbCommand(InsertClienti, stringconnection.connection);
                        command2.ExecuteNonQuery();

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Insert Vehicul', 'A inserat vehiculul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();


                        MessageBox.Show($"Am inserat masina {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddVehicule = new AddVehicule();
                        this.Hide();
                        AddVehicule.ShowDialog();
                    }
                    else
                    {
                        // update vehicul deja exstent
                        string UpdateVehicul = $"UPDATE Vehicule SET Nume = '{textBox1.Text}', Serie = '{textBox2.Text}', An = {textBox3.Text}, " +
                         $"DataImatri = '{textBox4.Text}', NrImatri = '{textBox5.Text}', UltMentenanta = '{textBox6.Text}' WHERE CODVehicul = {textBox12.Text};";
                        OleDbCommand command = new OleDbCommand(UpdateVehicul, stringconnection.connection);
                        stringconnection.connection.Open();
                        command.ExecuteNonQuery();

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Vehicul', 'A updatat vehiculul {textBox1.Text} {textBox2.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();

                        MessageBox.Show($"Am updatat masina {textBox1.Text} {textBox2.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        Form AddVehicule = new AddVehicule();
                        this.Hide();
                        AddVehicule.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate." +
                        "\nSeria nu trebuie sa contina spatii.", "Error");
                }
            }
            catch
            {
                MessageBox.Show($"Va rugam sa introduceti valori numeriece in An. \nAn Introdus: {textBox3.Text}.", "Error");
                stringconnection.connection.Close();
                Form AddVehicule = new AddVehicule();
                this.Hide();
                AddVehicule.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form AddVehicule = new AddVehicule();
            this.Hide();
            AddVehicule.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
            this.Close();
        }
    }
}
