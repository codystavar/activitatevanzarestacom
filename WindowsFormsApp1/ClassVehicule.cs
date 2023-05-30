using System;

namespace WindowsFormsApp1
{
    public class ClassVehicule : IComparable
    {
        public string _CodVehicul { get; private set; }
        public string _Nume { get; private set; }
        public string _Serie { get; private set; }
        public string _An { get; private set; }
        public string _DataImatri { get; private set; }
        public string _NrImatri { get; private set; }
        public string _UltMentenanta { get; private set; }


        public ClassVehicule(string CodVehicul, string Nume, string Serie, string An, string DataImatri, string NrImatiri, string UltMentenanta)
        {
            _CodVehicul = CodVehicul;
            _Nume = Nume;
            _Serie = Serie;
            _An = An;
            _DataImatri = DataImatri;
            _NrImatri = NrImatiri;
            _UltMentenanta = UltMentenanta;

        }

        public ClassVehicule(ClassVehicule c)
        {
            _CodVehicul = c._CodVehicul;
            _Nume = c._Nume;
            _Serie = c._Serie;
            _An = c._An;
            _DataImatri = c._DataImatri;
            _NrImatri = c._NrImatri;
            _UltMentenanta = c._UltMentenanta;
        }


        // ordonare
        public int CompareTo(object B)
        {
            return _CodVehicul.CompareTo((B as ClassVehicule)._CodVehicul);
        }

    }
}

