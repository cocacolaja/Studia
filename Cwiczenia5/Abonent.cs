using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia5
{
    enum EnumTaryfa { taryfa1 = 1, taryfa2 = 2, taryfa3 = 4 }

    interface IAbonent
    {
        public string PodajDane();
        public void Zadzwon(double czas, EnumTaryfa taryfa);
        public (int, decimal) PodsumowanieRozmow();
    }

    internal class Abonent : IAbonent
    {
        string imie;
        string nazwisko;
        string numerTelefonu;
        List<Polaczenie> polaczenia;

        public string NumerTelefonu {get => numerTelefonu; }

        public Abonent(string imie, string nazwisko, string numerTelefonu)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numerTelefonu = numerTelefonu;
            polaczenia = new(); //!! liste muismy tak zainicjować
        }

        public decimal SumaOplat() => polaczenia.Sum(p => p.Oplata);

        public string PodajDane()
        {
            return $"{imie} {nazwisko}";
        }

        public (int, decimal) PodsumowanieRozmow()
        {
            return (polaczenia.Count(p => p.Wykonane),
                SumaOplat());
        }

        public void Zadzwon(double czas, EnumTaryfa taryfa)
        {
            Random r = new();
            double rnd = r.NextDouble();
            if(rnd<0.3)
            {
                polaczenia.Add(new Polaczenie(0, 0, false));
            }
            else
            {
                polaczenia.Add(new Polaczenie(czas, (decimal)(czas*(int)taryfa), true));
            }
        }

        public override string ToString()
        {
            //Jan Kowalski {777-034-232}, [liczba rozmów: 1, opłata: 20,00 zł]
            return $"{PodajDane()} {{{numerTelefonu}}}," + $"[liczba rozmów: {polaczenia.Count}, " + $"oplata: {SumaOplat():c}]";
        }

    }
}
