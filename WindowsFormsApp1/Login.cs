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
    public partial class Login : Form
    {
        private getusername getusername = new getusername();

        public Login()
        {
            InitializeComponent();
        }


        // buton login
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty)
            {

                stringconnection.username = textBox1.Text;
                string selectlogin = $"SELECT * FROM Agenti WHERE username = '{textBox1.Text}' AND password = '{textBox2.Text}';";
                stringconnection.connection.Open();
                OleDbCommand command = new OleDbCommand(selectlogin, stringconnection.connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    stringconnection.connection.Close();
                    Form MainMenu = new MainMenu();
                    this.Hide();
                    MainMenu.ShowDialog();
                    this.Close();

                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Username sau parola gresita.", "Error");
 
                }

            }
            else
            {
                MessageBox.Show("Va rugam sa completati ambele campuri.", "Error");
            }
            stringconnection.connection.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
