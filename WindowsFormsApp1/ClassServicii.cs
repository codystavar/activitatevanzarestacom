using System;

namespace WindowsFormsApp1
{
    public class ClassServicii : IComparable
    {
        public string _CODService { get; private set; }
        public string _NumeServ { get; private set; }
        public string _PretServ { get; private set; }
        public string _Descriere { get; private set; }


        public ClassServicii(string CODService, string NumeServ, string PretServ, string Descriere)
        {
            _CODService = CODService;
            _NumeServ = NumeServ;
            _PretServ = PretServ;
            _Descriere = Descriere;

        }

        public ClassServicii(ClassServicii c)
        {
            _CODService = c._CODService;
            _NumeServ = c._NumeServ;
            _PretServ = c._PretServ;
            _Descriere = c._Descriere;
        }


        // ordonare
        public int CompareTo(object B)
        {
            return _CODService.CompareTo((B as ClassServicii)._CODService);
        }

    }
}
