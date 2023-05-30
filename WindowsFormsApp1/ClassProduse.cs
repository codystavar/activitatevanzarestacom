using System;

namespace WindowsFormsApp1
{
    public class ClassProduse : IComparable
    {
        public string _CodProduse { get; private set; }
        public string _NumeProd { get; private set; }
        public string _PretProd { get; private set; }
        public string _Cantitate { get; private set; }
        public string _Descriere { get; private set; }


        //constructor
        public ClassProduse(string CodProduse, string NumeProd, string PretProd, string Cantitate, string Descriere)
        {
            _CodProduse = CodProduse;
            _NumeProd = NumeProd;
            _PretProd = PretProd;
            _Cantitate = Cantitate;
            _Descriere = Descriere;

        }

        public ClassProduse(ClassProduse c)

        {
            _CodProduse = c._CodProduse;
            _NumeProd = c._NumeProd;
            _Cantitate = c._Cantitate;
            _Descriere = c._Descriere;
        }

        // ordonare
        public int CompareTo(object B)
        {
            return _CodProduse.CompareTo((B as ClassProduse)._CodProduse);
        }
    }

}
