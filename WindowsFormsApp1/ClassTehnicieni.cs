using System;

namespace WindowsFormsApp1
{
    public class ClassTehnicieni : IComparable
    {
        public string _CODTehnician { get; private set; }
        public string _Nume { get; private set; }
        public string _Prenume { get; private set; }
        public string _Telefon { get; private set; }
        public string _Email { get; private set; }
        public string _Strada { get; private set; }
        public string _StrNr { get; private set; }
        public string _Localitate { get; private set; }

        // constructor
        public ClassTehnicieni(string CODTehnician, string Nume, string Prenume, string Telefon, string Email, string Strada,
            string StrNr, string Localitate)
        {

            _CODTehnician = CODTehnician;
            _Nume = Nume;
            _Prenume = Prenume;
            _Telefon = Telefon;
            _Email = Email;
            _Strada = Strada;
            _StrNr = StrNr;
            _Localitate = Localitate;

        }

        public ClassTehnicieni(ClassTehnicieni c)
        {
            _CODTehnician = c._CODTehnician;
            _Nume = c._Nume;
            _Prenume = c._Prenume;
            _Telefon = c._Telefon;
            _Email = c._Email;
            _Strada = c._Strada;
            _StrNr = c._StrNr;
            _Localitate = c._Localitate;
        }

        // ordonare
        public int CompareTo(object B)
        {
            return _CODTehnician.CompareTo((B as ClassTehnicieni)._CODTehnician);
        }

    }
}
