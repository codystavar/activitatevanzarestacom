using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class getusername
    {
        public string Username { get; set; }

        public event EventHandler UserLogged;

        public void Login(string username)
        {
            Username = username;
            UserLogged?.Invoke(this, EventArgs.Empty);
        }
    }
}
