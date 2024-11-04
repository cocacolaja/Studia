using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenia2
{
    enum EnumPlec { K, M } // typ enum moze przyjmować tylko okreslone przez nas wartości
    class Osoba
    {
        string imie;
        string nazwisko;
        string adres;
        DateTime dataUrodzenia;
        string pesel;
        EnumPlec plec;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Adres { get => adres; set => adres = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string Pesel
        {
            get => pesel;
            init// init - wartość można ustawić tylko gdy tworymy obiekt, nie moge pozniej
            {
                if (!Regex.IsMatch(value, @"\d{11}")) // regex.ismatch sprawdza czy sa te same znaki, @"\d" liczby a 11 bo 11 liczb ma być
                {
                    throw new ArgumentException("Pesel musi mieć 11 cyfr");
                }
                pesel = value;
            }
        }
        public Osoba() //konstruktor- public nazwaklasy (jakie parametry chcemy twaorzyć) : this ()//jak uzywamy poprzednich konstrudktorow
        {
            Pesel = new string('0', 11);
        }
        public Osoba(string imie, string nazwisko, EnumPlec plec) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            this.plec = plec;
        }

        public Osoba(string imie, string nazwiwsko, string dataUrodzenia, string pesel, EnumPlec plec) : this(imie, nazwiwsko, plec)
        {
            Pesel = pesel;
            if (DateTime.TryParseExact(dataUrodzenia, new string[] { "dd-MM-yyyy", "yyyy-MM-dd" }, null, DateTimeStyles.None, out DateTime d)) ;
            {
                DataUrodzenia = d;

            }

        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} ({plec}), ur. {DataUrodzenia:yyyy-MM-dd} PESEL: {Pesel}";
        }

        public int Wiek() //metoda liczenia wieku
        {
            int w = DateTime.Now.Year - DataUrodzenia.Year;
            int w2 = (DateTime.Now - DataUrodzenia).Days / 365;
            return w2;
        }
    }
}
