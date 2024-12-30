using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolosG
{
    public class Klient : Osoba
    {
        static int IDKlienta = 0;

        public Klient()
        {
        }

        public Klient(string imie, string nazwisko, string numerTelefonu, string pesel, DateTime dataUrodzenia)
            : base(imie, nazwisko, numerTelefonu, pesel, dataUrodzenia)
        {
            IDKlienta++;
        }
    }
}