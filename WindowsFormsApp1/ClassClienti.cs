using System;

namespace WindowsFormsApp1
{
    public class ClassClienti : IComparable
    {
        public string _CodClient { get; private set; }
        public string _Nume { get; private set; }
        public string _Prenume { get; private set; }
        public string _Strada { get; private set; }
        public string _StrNr { get; private set; }
        public string _Localitate { get; private set; }
        public string _Telefon { get; private set; }
        public string _Email { get; private set; }
        public string _RegCom { get; private set; }
        public string _CIF { get; private set; }
        public string _IBAN { get; private set; }
        public string _Banca { get; private set; }

        // constructor
        public ClassClienti(string CodClient, string Nume, string Prenume, string Strada, string StrNr, string Localitate,
            string Telefon, string Email, string RegCom, string CIF, string IBAN, string Banca)
        {
            _CodClient = CodClient;
            _Nume = Nume;
            _Prenume = Prenume;
            _Strada = Strada;
            _StrNr = StrNr;
            _Localitate = Localitate;
            _Telefon = Telefon;
            _Email = Email;
            _RegCom = RegCom;
            _CIF = CIF;
            _IBAN = IBAN;
            _Banca = Banca;

        }

        public ClassClienti(ClassClienti c)
        {
            _CodClient = c._CodClient;
            _Nume = c._Nume;
            _Prenume = c._Prenume;
            _Strada = c._Strada;
            _StrNr = c._StrNr;
            _Localitate = c._Localitate;
            _Telefon = c._Telefon;
            _Email = c._Email;
            _RegCom = c._RegCom;
            _IBAN = c._IBAN;
            _Banca = c._Banca;
        }

        // ordonare
        public int CompareTo(object B)
        {
            return _CodClient.CompareTo((B as ClassClienti)._CodClient);
        }

    }
}
