using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class ClassAgenti : IComparable
    {
        public string _CodAgent { get; private set; }
        public string _Nume { get; private set; }
        public string _Prenume { get; private set; }
        public string _Telefon { get; private set; }
        public string _Email { get; private set; }
        public string _Strada { get; private set; }
        public string _StrNr { get; private set; }
        public string _Localitate { get; private set; }
        public string _username { get; private set; }
        public string _password { get; private set; }


        // constructor
        public ClassAgenti(string CodAgent, string Nume, string Prenume, string Telefon, string Email, string Strada, string StrNr,
            string Localitate, string username, string password)
        {
            _CodAgent = CodAgent;
            _Nume = Nume;
            _Prenume = Prenume;
            _Telefon = Telefon;
            _Email = Email;
            _Strada = Strada;
            _StrNr = StrNr;
            _Localitate = Localitate;
            _username = username;
            _password = password;

        }

        public ClassAgenti(ClassAgenti c)
        {
            _CodAgent = c._CodAgent;
            _Nume = c._Nume;
            _Prenume = c._Prenume;
            _Telefon = c._Telefon;
            _Email = c._Email;
            _Strada = c._Strada;
            _StrNr = c._StrNr;
            _Localitate = c._Localitate;
            _username = c._username;
            _password = c._password;

        }

        // ordonare
        public int CompareTo(object B)
        {
            return _CodAgent.CompareTo((B as ClassAgenti)._CodAgent);
        }


    }
}
