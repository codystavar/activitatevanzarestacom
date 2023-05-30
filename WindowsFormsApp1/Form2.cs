using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuVanzare : Form
    {
        // variabila globala de conectare

        // calcul total



        public void calcultotalproduse()
        {
            int sumatotal = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                sumatotal += int.Parse(item.SubItems[2].Text);
            }
            label5.Text = "Total de plata: " + sumatotal.ToString();

        }

        public void calcultotalservicii()
        {
            int sumatotal = 0;
            foreach (ListViewItem item in listView3.Items)
            {
                sumatotal += int.Parse(item.SubItems[4].Text);
            }
            label11.Text = "Total de plata: " + sumatotal.ToString();

        }



        // restare form
        public void resetareform()
        {
            Form MenuVanzare = new MenuVanzare();
            this.Hide();
            MenuVanzare.ShowDialog();
        }
        public MenuVanzare()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form MainMenu = new MainMenu();
            this.Hide();
            MainMenu.ShowDialog();
            this.Close();
        }

        private void MenuVanzare_Load(object sender, EventArgs e)
        {

            // disable tehnician serviciu pana cand este apelat
            label7.Enabled = false;
            comboBox3.Enabled = false;

            // Select client pt combobox1
            string SelectClienti = "SELECT Nume, Prenume FROM Clienti;";
            OleDbCommand command1 = new OleDbCommand(SelectClienti, stringconnection.connection);

            //Select produse pentru listbox1
            string SelectProduse = "Select NumeProd, PretProd, Cantitate FROM Produse WHERE Cantitate > 0";
            OleDbCommand command2 = new OleDbCommand(SelectProduse, stringconnection.connection);

            // select sofer
            string SelectSofer = "Select Nume, Prenume FROM Soferi;";
            OleDbCommand command3 = new OleDbCommand(SelectSofer, stringconnection.connection);

            // select tehnician
            string SelectTehnician = "Select Nume, Prenume from Tehnicieni;";
            OleDbCommand command4 = new OleDbCommand(SelectTehnician, stringconnection.connection);

            // connection open
            stringconnection.connection.Open();
            OleDbDataReader reader = command1.ExecuteReader();
            OleDbDataReader reader2 = command2.ExecuteReader();
            OleDbDataReader reader3 = command3.ExecuteReader();
            OleDbDataReader reader4 = command4.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0) + " " + reader.GetString(1));

            }

            while (reader2.Read())
            {
                int Pret, Cantitate;
                if (int.TryParse(reader2["PretProd"].ToString(), out Pret) && int.TryParse(reader2["Cantitate"].ToString(), out Cantitate))
                {
                    ListViewItem item = new ListViewItem(reader2["NumeProd"].ToString());
                    item.SubItems.Add(reader2["PretProd"].ToString());
                    item.SubItems.Add(reader2["Cantitate"].ToString());
                    listView1.Items.Add(item);
                }
            }

            while (reader3.Read())
            {
                comboBox4.Items.Add(reader3.GetString(0) + " " + reader3.GetString(1));
            }

            while (reader4.Read())
            {
                comboBox2.Items.Add(reader4.GetString(0) + " " + reader4.GetString(1));
            }


            reader.Close();
            reader2.Close();
            reader3.Close();
            reader4.Close();
            stringconnection.connection.Close();

        }



        // buton adauga
        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listView1.SelectedItems)
            {
                string itemName = selectedItem.Text;
                int pretbuc = int.Parse(selectedItem.SubItems[1].Text);
                int cantitate = int.Parse(selectedItem.SubItems[2].Text);

                // Verificare daca exista in listview2 un nume deja existent
                bool itemExists = false;
                foreach (ListViewItem existingItem in listView2.Items)
                {
                    if (existingItem.Text == itemName)
                    {
                        // updatare cantitate cu +1
                        int existingcantitate = int.Parse(existingItem.SubItems[1].Text);
                        existingItem.SubItems[1].Text = (existingcantitate + 1).ToString();

                        // calcul pret || *2 pentru calcul corect
                        int pretitemtotal = pretbuc;
                        pretitemtotal *= (existingcantitate + 1);
                        existingItem.SubItems[2].Text = pretitemtotal.ToString();
                        itemExists = true;
                        break;
                    }

                };

                // add pretdefault pentru afisare
                string pretdefault = pretbuc.ToString();

                // Daca nu exista un produs cu acelasi nume, se va crea unul
                if (!itemExists)
                {
                    ListViewItem newItem = new ListViewItem(itemName);
                    newItem.SubItems.Add("1");
                    newItem.SubItems.Add(pretdefault);
                    listView2.Items.Add(newItem);
                }

                // scadem din cantitate cu 1
                if (cantitate > 1)
                {
                    selectedItem.SubItems[2].Text = (cantitate - 1).ToString();
                }
                else
                {
                    listView1.Items.Remove(selectedItem);
                }
            }

            // calcul label5 (Total de plata adauga)
            calcultotalproduse();
        }

        // variabila pretserv global
        string PretServ = "";
        // adaugare serviciu
        private void button7_Click(object sender, EventArgs e)
        {
            int cantitate = 1;
            int calctotal = 0;

            if (comboBox3.Text != "")
            {
                string SelectedItem = comboBox3.SelectedItem.ToString();
                string SelectedItem2 = comboBox2.SelectedItem.ToString();

                string query = $"SELECT PretServ FROM Servicii WHERE NumeServ = '{SelectedItem}';";

                bool itemExists = false;
                foreach (ListViewItem item in listView3.Items)
                {
                    if (item.Text == SelectedItem)
                    {
                        itemExists = true;
                        cantitate = int.Parse(item.SubItems[3].Text) + 1;
                        item.SubItems[3].Text = cantitate.ToString();
                        int PretServ2 = int.Parse(PretServ);
                        calctotal = PretServ2 * cantitate;
                        item.SubItems[4].Text = calctotal.ToString();

                        break;
                    }
                }


                OleDbCommand command = new OleDbCommand(query, stringconnection.connection);

                stringconnection.connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PretServ = Convert.ToString(reader.GetValue(0));

                    if (!itemExists)
                    {
                        ListViewItem newItem = new ListViewItem(SelectedItem);
                        newItem.SubItems.Add(SelectedItem2);
                        newItem.SubItems.Add(PretServ);
                        newItem.SubItems.Add(cantitate.ToString());
                        newItem.SubItems.Add(PretServ);
                        listView3.Items.Add(newItem);

                    }

                }

                stringconnection.connection.Close();
            }
            else
            {
                MessageBox.Show("Va rugam sa selectati un serviciu.", "Error");
            }

            calcultotalservicii();

        }

        // ---------------------------------------

        // buton stergere
        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listView2.SelectedItems)
            {
                string itemName = selectedItem.Text;
                int cantitate2 = int.Parse(selectedItem.SubItems[1].Text);
                int pretotal = int.Parse(selectedItem.SubItems[2].Text);

                // Verificare daca exista in listview1 un nume deja existent
                bool itemExists = false;
                foreach (ListViewItem existingItem2 in listView1.Items)
                {
                    if (existingItem2.Text == itemName)
                    {
                        //updatare cantitat din listview2 in listview1
                        int existingcantitate = int.Parse(existingItem2.SubItems[2].Text);
                        existingItem2.SubItems[2].Text = (existingcantitate + 1).ToString();

                        //-------------------------
                        //calcul pret

                        int pretitemtotal = (pretotal / cantitate2) * (cantitate2 - 1);
                        selectedItem.SubItems[2].Text = pretitemtotal.ToString();
                        itemExists = true;
                        break;
                    }
                };

                // Daca nu exista un produs cu acelasi nume, se va crea
                if (!itemExists)
                {
                    ListViewItem newItem = new ListViewItem(itemName);
                    int pretunitar = pretotal / cantitate2;
                    newItem.SubItems.Add((pretunitar).ToString());
                    int pretitemtotal = (pretotal / cantitate2) * (cantitate2 - 1);
                    selectedItem.SubItems[2].Text = pretitemtotal.ToString();
                    newItem.SubItems.Add("1");
                    listView1.Items.Add(newItem);

                }

                // scadem din cantitate cu 1
                if (cantitate2 > 1)
                {
                    selectedItem.SubItems[1].Text = (cantitate2 - 1).ToString();
                }
                else
                {
                    listView2.Items.Remove(selectedItem);
                }

                // calcul label5 (Total de plata stergere)
                calcultotalproduse();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            // obtinere CODTehnician
            string selectedTehnician = comboBox2.SelectedItem.ToString();
            string input = selectedTehnician;
            string[] numetehnician = input.Split(' ');
            string Nume = numetehnician[0];
            string Prenume = numetehnician[1];

            string query = $"SELECT CODTehnician FROM Tehnicieni WHERE Nume = '{Nume}' AND Prenume = '{Prenume}';";


            OleDbCommand command1 = new OleDbCommand(query, stringconnection.connection);


            stringconnection.connection.Open();
            //obtinere IDTehnician

            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {

                string IDTehnician = Convert.ToString(reader.GetValue(0));

                // get numele de servicii
                string NumeServ = $"SELECT NumeServ FROM (Servicii INNER JOIN ServiciiTehnician ON " +
                    $"Servicii.CODService = ServiciiTehnician.CodService) WHERE ServiciiTehnician.CodTehnician = {IDTehnician};";

                OleDbCommand command2 = new OleDbCommand(NumeServ, stringconnection.connection);
                OleDbDataReader reader2 = command2.ExecuteReader();

                while (reader2.Read())

                {
                    comboBox3.Items.Add(reader2.GetString(0));

                }

                // close the connection
                label7.Enabled = true;
                comboBox3.Enabled = true;

            }

            stringconnection.connection.Close();
        }

        // buton reset
        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Comanda resetata cu succes. Menu-ul se va redeshide.", "Reset");
            resetareform();
        }


        // buton finalizare comanda
        private void button5_Click(object sender, EventArgs e)
        {
            // verificare sa existe text
            if (comboBox1.Text != "" && comboBox2.Text != "" && listView2.Items.Count > 0 && listView3.Items.Count > 0)
            {

                stringconnection.connection.Open();

                // get client
                string selectedClient = comboBox1.SelectedItem.ToString();
                string[] numclient = selectedClient.Split(' ');
                string NumeClient = numclient[0];
                string PrenumeClient = numclient[1];
                string query1 = $"SELECT CODClient FROM Clienti WHERE Nume = '{NumeClient}' AND Prenume = '{PrenumeClient}'";
                OleDbCommand command1 = new OleDbCommand(query1, stringconnection.connection);
                int codClient = (int)command1.ExecuteScalar();


                // 1..
                // INSERT INTO COMENZI..

                //codificare nrfactura
                string getnrfactura = "SELECT MAX(NrFactura) FROM Comenzi;";
                OleDbCommand command2 = new OleDbCommand(getnrfactura, stringconnection.connection);
                int nrfactura = 0;
                int newfactura = 0;
                DateTime dataCurenta = DateTime.Now;
                // newfactura to insert
                if (command2.ExecuteScalar() != DBNull.Value)
                {
                    nrfactura = (int)command2.ExecuteScalar();
                }

                if (nrfactura == 0)
                {
                    newfactura = 1;
                }
                else
                {
                    newfactura = nrfactura + 1;
                }

                //select CODAgent pentru inserare
                string getCODAgent2 = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                OleDbCommand command4 = new OleDbCommand(getCODAgent2, stringconnection.connection);
                int codagent2 = (int)command4.ExecuteScalar();

                // 
                string query2 = $"INSERT INTO Comenzi (CODClient, NrFactura, DataCom, CodAgent) VALUES ('{codClient}','{newfactura}', '{dataCurenta.ToString("dd/MM/yyyy")}', '{codagent2}');";
                OleDbCommand command3 = new OleDbCommand(query2, stringconnection.connection);
                command3.ExecuteNonQuery();

                //2..
                //INSERT INTO ComenziServicii


                // Select ultima intrare de la COMID
                string getComID = "SELECT @@IDENTITY";
                OleDbCommand idCommand = new OleDbCommand(getComID, stringconnection.connection);
                int ComID = Convert.ToInt32(idCommand.ExecuteScalar());

                //preluare serviciu + tehnician pentru a obtine serviciu tehnician
                //pentru fiecare item listat in cantiate servicii, adaugam si legam de PK
                foreach (ListViewItem item in listView3.Items)
                {
                    //select serviciu + tehnician
                    string numeserv = item.SubItems[0].Text;
                    string numetehnician = item.SubItems[1].Text;
                    //split tehnician
                    string input = numetehnician;
                    string[] tehniciansplit = input.Split(' ');
                    string numeteh = tehniciansplit[0];
                    string prenteh = tehniciansplit[1];
                    // new values
                    int CodTehnician = 0;
                    int CODService = 0;
                    int CODST = 0;



                    //obtine CodTehnician
                    query2 = $"SELECT CodTehnician FROM Tehnicieni WHERE Nume = '{numeteh}' AND Prenume = '{prenteh}';";
                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    OleDbDataReader reader = command3.ExecuteReader();

                    while (reader.Read())
                    {

                        CodTehnician = (int)reader.GetValue(0);

                    }

                    //obtine Codservice
                    query2 = $"SELECT CODService FROM Servicii WHERE NumeServ = '{numeserv}';";
                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    OleDbDataReader reader2 = command3.ExecuteReader();

                    while (reader2.Read())
                    {

                        CODService = (int)reader2.GetValue(0);

                    }

                    // obtine CODST
                    query2 = $"Select CODST FROM ServiciiTehnician WHERE CodTehnician = {CodTehnician} AND CodService = {CODService};";
                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    OleDbDataReader reader3 = command3.ExecuteReader();

                    while (reader3.Read())
                    {

                        CODST = (int)reader3.GetValue(0);

                    }

                    //Introduce in ComenziServicii
                    int cantitate = int.Parse(item.SubItems[3].Text);
                    query2 = $"INSERT INTO ComenziServicii (CantitateServiciu, CODST, ComS) VALUES ('{cantitate}', '{CODST}', '{ComID}');";
                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    command3.ExecuteNonQuery();
                }

                // 3. Insert Comand Transport
                // ...

                string numesofer = comboBox4.Text;
                //split nume sofer
                string splitsofer = numesofer;
                string[] soferseparat = splitsofer.Split(' ');
                string numesof = soferseparat[0];
                string prenumesof = soferseparat[1];
                int CODSofer = 0;

                // obinere CODSofer
                query2 = $"SELECT CODSofer FROM Soferi WHERE Nume = '{numesof}' AND Prenume = '{prenumesof}';";
                command3 = new OleDbCommand(query2, stringconnection.connection);
                OleDbDataReader reader4 = command3.ExecuteReader();
                while (reader4.Read())
                {

                    CODSofer = (int)reader4.GetValue(0);

                }


                // Inserare in comenzi transport
                query2 = $"INSERT INTO ComenziTransport (CODSofer, ComT) VALUES ('{CODSofer}', '{ComID}');";
                command3 = new OleDbCommand(query2, stringconnection.connection);
                command3.ExecuteNonQuery();


                // 4...
                // Insert Comanda Produse
                foreach (ListViewItem item in listView2.Items)
                {
                    string NumeProd = item.SubItems[0].Text;
                    int CantitateProd = int.Parse(item.SubItems[1].Text);
                    int PretProd = int.Parse(item.SubItems[2].Text);
                    int CodProdus = 0;
                    int OldCantitateProd = 0;
                    int NewCantitateProd = 0;

                    //obtine CODProdus
                    query2 = $"SELECT CODProduse FROM Produse WHERE NumeProd = '{NumeProd}';";
                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    OleDbDataReader reader = command3.ExecuteReader();

                    while (reader.Read())
                    {

                        CodProdus = (int)reader.GetValue(0);

                    }

                    query2 = $"SELECT Cantitate FROM Produse WHERE CODProduse = {CodProdus};";
                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    OleDbDataReader reader2 = command3.ExecuteReader();

                    while (reader2.Read())
                    {

                        OldCantitateProd = (int)reader2.GetValue(0);

                    }

                    NewCantitateProd = OldCantitateProd - CantitateProd;


                    // !! [ComP] trebuie bagat intre [ ] fiindca are mai multe litere mari unde in anumite baze de date poate cauza probleme
                    // Access 2021 spre exemplu !!
                    query2 = $"INSERT INTO ComenziProd (Cantitate, CodProduse, [ComP]) VALUES ({CantitateProd}, {CodProdus}, {ComID});";

                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    command3.ExecuteNonQuery();
                    query2 = $"UPDATE Produse SET Cantitate = {NewCantitateProd} WHERE CODProduse = {CodProdus}";
                    command3 = new OleDbCommand(query2, stringconnection.connection);
                    command3.ExecuteNonQuery();

                }

                //update statement in actiuni
                string getCODAgent = $"SELECT CODAgent FROM Agenti WHERE username = '{stringconnection.username}'";
                OleDbCommand command7 = new OleDbCommand(getCODAgent, stringconnection.connection);
                int codagent = (int)command7.ExecuteScalar();

                //get COM max
                string IDComandaMax = $"SELECT MAX(COM) FROM Comenzi";
                OleDbCommand command9 = new OleDbCommand(IDComandaMax, stringconnection.connection);
                int COMANDAMAX = (int)command9.ExecuteScalar();

                //adaugare in log
                string UpdateActiune = $"INSERT INTO Actiuni (TipSchimbare, Descriere, Data, CODAgent) VALUES ('Inserare comanda', 'A inserat comanda nr. {COMANDAMAX}', Now(), {codagent})";

                OleDbCommand command8 = new OleDbCommand(UpdateActiune, stringconnection.connection);
                command8.ExecuteNonQuery();

                stringconnection.connection.Close();

                // restare
                DialogResult vanzarereusita = MessageBox.Show("Comanda a fost inserata cu succes! Doriti sa afisati factura?", "Vanzare reusita", MessageBoxButtons.YesNo);

                if (vanzarereusita == DialogResult.Yes)
                {
                    Form Facturi = new Facturi();
                    this.Hide();
                    Facturi.ShowDialog();
                    this.Close();
                }
                else if (vanzarereusita == DialogResult.No)
                {
                 resetareform();
                }
            }
            else
            {
                MessageBox.Show("Completati toate campurile pentru a insera o comanda.", "Error");
            }
        }


        // selectare numar telefon si email
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                stringconnection.connection.Open();
                string selectedClient = comboBox1.SelectedItem.ToString();
                string[] numclient = selectedClient.Split(' ');
                string NumeClient = numclient[0];
                string PrenumeClient = numclient[1];

                string query1 = $"SELECT CODClient FROM Clienti WHERE Nume = '{NumeClient}' AND Prenume = '{PrenumeClient}'";
                OleDbCommand command1 = new OleDbCommand(query1, stringconnection.connection);
                int codClient = (int)command1.ExecuteScalar();

                // get nr telefon
                string getnrtelefon = $"SELECT Telefon FROM Clienti WHERE CODClient = {codClient};";
                OleDbCommand command2 = new OleDbCommand(getnrtelefon, stringconnection.connection);
                OleDbDataReader reader = command2.ExecuteReader();

                // get email
                string getemail = $"SELECT Email FROM Clienti WHERE CODClient = {codClient};";
                OleDbCommand command3 = new OleDbCommand(getemail, stringconnection.connection);
                OleDbDataReader reader2 = command3.ExecuteReader();

                while (reader.Read())
                {

                    textBox1.Text = reader.GetValue(0).ToString();

                }

                while (reader2.Read())
                {
                    textBox2.Text = reader2.GetValue(0).ToString();
                }


                stringconnection.connection.Close();

            }

        }


        // calcul total 
        private void label5_TextChanged(object sender, EventArgs e)
        {
            string strval1 = label5.Text;
            string[] Ary1 = strval1.Split(' ');
            int val1 = int.Parse(Ary1[Ary1.Length - 1]);

            string strval2 = label11.Text;
            string[] Ary2 = strval2.Split(' ');
            int val2 = int.Parse(Ary2[Ary2.Length - 1]);

            int suma = val1 + val2;
            label15.Text = "Total de plata: " + suma.ToString() + " RON";
        }

        private void label11_TextChanged(object sender, EventArgs e)
        {
            string strval1 = label5.Text;
            string[] Ary1 = strval1.Split(' ');
            int val1 = int.Parse(Ary1[Ary1.Length - 1]);

            string strval2 = label11.Text;
            string[] Ary2 = strval2.Split(' ');
            int val2 = int.Parse(Ary2[Ary2.Length - 1]);

            int suma = val1 + val2;
            label15.Text = "Total de plata: " + suma.ToString() + " RON";
        }

        //stergere serviciu
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in listView3.SelectedItems)
            {
                string itemName = selectedItem.Text;
                int cantitate = int.Parse(selectedItem.SubItems[3].Text);
                int pretotal = int.Parse(selectedItem.SubItems[4].Text);


                foreach (ListViewItem existingItem in listView3.Items)
                {
                    if (existingItem.Text == itemName)
                    {
                        //updatare cantitat din listview2 in listview1
                        int existingcantitate = int.Parse(existingItem.SubItems[3].Text);
                        existingItem.SubItems[4].Text = (existingcantitate - 1).ToString();

                        //-------------------------
                        //calcul total

                        int pretitemtotal = (pretotal / cantitate) * (cantitate - 1);
                        selectedItem.SubItems[4].Text = pretitemtotal.ToString();

                        break;
                    }
                };

                // scadem din cantitate cu 1
                if (cantitate > 1)
                {
                    selectedItem.SubItems[3].Text = (cantitate - 1).ToString();
                }
                else
                {
                    listView3.Items.Remove(selectedItem);
                }

                // calcul label5 (Total de plata stergere)
                calcultotalservicii();
            }
        }
    }
}
