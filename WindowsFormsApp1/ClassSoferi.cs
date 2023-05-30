using System;

namespace WindowsFormsApp1
{
    public class ClassSoferi : IComparable
    {
        public string _CODSofer { get; private set; }
        public string _Nume { get; private set; }
        public string _Prenume { get; private set; }
        public string _CNP { get; private set; }
        public string _CNPSerie { get; private set; }
        public string _CNPSerieNr { get; private set; }
        public string _CNPUnitElib { get; private set; }
        public string _Strada { get; private set; }
        public string _StrNr { get; private set; }
        public string _Localitate { get; private set; }
        public string _Telefon { get; private set; }
        public string _Email { get; private set; }
        public string _CODVehicul { get; private set; }

        // constructor
        public ClassSoferi(string CODSofer, string Nume, string Prenume, string CNP, string CNPSerie, string CNPSerieNr,
            string CNPUnitElib, string Strada, string StrNr, string Localitate, string Telefon, string Email, string CODVehicul)
        {
            _CODSofer = CODSofer;
            _Nume = Nume;
            _Prenume = Prenume;
            _CNP = CNP;
            _CNPSerie = CNPSerie;
            _CNPSerieNr = CNPSerieNr;
            _CNPUnitElib = CNPUnitElib;
            _Strada = Strada;
            _StrNr = StrNr;
            _Localitate = Localitate;
            _Telefon = Telefon;
            _Email = Email;
            _CODVehicul = CODVehicul;
        }

        public ClassSoferi(ClassSoferi c)
        {
            _CODSofer = c._CODSofer;
            _Nume = c._Nume;
            _Prenume = c._Prenume;
            _CNP = c._CNP;
            _CNPSerie = c._CNPSerie;
            _CNPSerieNr = c._CNPSerieNr;
            _CNPUnitElib = c._CNPUnitElib;
            _Strada = c._Strada;
            _StrNr = c._StrNr;
            _Localitate = c._Localitate;
            _Telefon = c._Telefon;
            _Email = c._Email;
            _CODVehicul = c._CODVehicul;

        }

        // ordonare
        public int CompareTo(object B)
        {
            return _CODSofer.CompareTo((B as ClassSoferi)._CODSofer);
        }

    }
}