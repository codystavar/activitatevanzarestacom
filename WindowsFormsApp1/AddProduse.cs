using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddProduse : Form
    {
        int codProdus = 0;

        //creare lista
        public List<ClassProduse> produse = new List<ClassProduse>();

        private void SelectProduse(int codProdus)
        {
            textBox12.Text = produse[codProdus]._CodProduse;
            textBox1.Text = produse[codProdus]._NumeProd;
            textBox2.Text = produse[codProdus]._PretProd;
            textBox3.Text = produse[codProdus]._Cantitate;
            textBox4.Text = produse[codProdus]._Descriere;

        }


        public AddProduse()
        {
            InitializeComponent();

        }


        private void AddProduse_Load(object sender, EventArgs e)
        {
            // select
            string Produse = $"SELECT CODProduse, NumeProd, PretProd, Cantitate, Descriere FROM Produse;";
            stringconnection.connection.Open();
            OleDbCommand command = new OleDbCommand(Produse, stringconnection.connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ClassProduse produs = new ClassProduse(reader["CodProduse"].ToString(), reader["NumeProd"].ToString(),
                    reader["PretProd"].ToString(), reader["Cantitate"].ToString(), reader["Descriere"].ToString());

                produse.Add(produs);
            }
            reader.Close();
            stringconnection.connection.Close();

            SelectProduse(codProdus);

            textBox12.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            codProdus++;
            SelectProduse(codProdus);
            button1.Enabled = true;
            if (codProdus == produse.Count - 1)
            {
                button2.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            codProdus--;
            SelectProduse(codProdus);
            button2.Enabled = true;
            if (codProdus == 0)
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
            button1.Enabled = false;
            button2.Enabled = false;
            button6.Enabled = false;
            button3.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox12.Text = "Produs Nou";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && int.Parse(textBox3.Text) > 0)
                {
                    if (textBox12.Text == "Produs Nou")
                    {
                        //insert Produs Nou
                        string InsertProdus = $"INSERT INTO Produse (NumeProd, PretProd, Cantitate, Descriere) " +
                                              $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}');";
                        stringconnection.connection.Open();

                        //insert statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Insert Produs', 'A inserat produsul {textBox1.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();



                        OleDbCommand command2 = new OleDbCommand(InsertProdus, stringconnection.connection);
                        command2.ExecuteNonQuery();
                        MessageBox.Show($"Am inserat produsul cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        this.Dispose();
                        Form AddProduse = new AddProduse();
                        AddProduse.ShowDialog();
                    }
                    else
                    {
                        string UpdateClienti = $"UPDATE Produse SET NumeProd = '{textBox1.Text}', PretProd = '{textBox2.Text}', Cantitate = '{textBox3.Text}'" +
                        $", Descriere = '{textBox4.Text}' WHERE CODProduse = {textBox12.Text};";
                        OleDbCommand command = new OleDbCommand(UpdateClienti, stringconnection.connection);
                        stringconnection.connection.Open();

                        //update statement in actiuni
                        string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                        OleDbCommand command4 = new OleDbCommand(getCODAgent, stringconnection.connection);
                        int codagent = (int)command4.ExecuteScalar();

                        string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Update Produs', " +
                            $"'A updatat updatat produsul {textBox1.Text}', Now(), {codagent})";

                        OleDbCommand command5 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                        command5.ExecuteNonQuery();


                        command.ExecuteNonQuery();
                        MessageBox.Show($"Am updatat produsul {textBox1.Text} cu succes!", "Succes!");
                        stringconnection.connection.Close();
                        this.Dispose();
                        Form AddProduse = new AddProduse();
                        AddProduse.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("Va rugam completati toate campurile. Campurile goale nu vor fi update/inserate.", "Error");
                }
            }
            catch
            {
                MessageBox.Show($"Va rugam sa introduceti doar numere in cantitate. \nCantitate introdusa: {textBox3.Text}.", "Error");
                stringconnection.connection.Close();
                this.Dispose();
                Form AddProduse = new AddProduse();
                AddProduse.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form AddProduse = new AddProduse();
            AddProduse.ShowDialog(); ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form MainMenu = new MainMenu();
            MainMenu.ShowDialog();
        }
    }
}
