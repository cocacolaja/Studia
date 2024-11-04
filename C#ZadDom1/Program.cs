using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Zaddom1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Test2();
        }

        public static void Test1()
        {
            Ksiazka ksiazka1 = new Ksiazka("Język ANSI C", "1998-05-23", EnumWydawcy.Helion);
            Console.WriteLine(ksiazka1.ToString());

            Ksiazka ksiazka2 = new Ksiazka("C# dla zaawansowanych", "2009-09-15", EnumWydawcy.Springer);
            Console.WriteLine(ksiazka2.ToString());
        }

        public static void Test2()
        {
            try
            {
                // Próba utworzenia abonenta z poprawnym numerem
                Abonent abonent1 = new Abonent("Jan", "Kowalski", "123-456-789", "Warszawa");
                Console.WriteLine(abonent1.ToString());

                // Próba ustawienia niepoprawnego numeru telefonu - powinien zostać rzucony wyjątek
                abonent1.NumerTelefonu = "123-45-678"; // Niepoprawny format, za mało cyfr
            }
            catch (BlednyNumerException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            try
            {
                // Próba utworzenia abonenta z niepoprawnym numerem
                Abonent abonent2 = new Abonent("Anna", "Nowak", "123456789", "Kraków"); // Niepoprawny format
                Console.WriteLine(abonent2.ToString());
            }
            catch (BlednyNumerException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }

        public static string ZmienNaRzymskie(int miesiac)
        {
            switch (miesiac)
            {
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                case 5: return "V";
                case 6: return "VI";
                case 7: return "VII";
                case 8: return "VIII";
                case 9: return "IX";
                case 10: return "X";
                case 11: return "XI";
                case 12: return "XII";
                default: throw new ArgumentOutOfRangeException("Miesiąc musi być w zakresie 1-12.");
            }
        }

    }

    enum EnumWydawcy { Helion, Miniatura, Marabut, Kwadratura, Rosikon, Prodoks, Springer }

    internal class Ksiazka
    {
        static long indeks;

        string tytul;
        DateTime dataWydania;
        EnumWydawcy wydawca;
        protected string isbn; //ustawienie chronionego isbn, zeby miec do niego dostep w ksiazka telefoniczna

        static Ksiazka()
        {
            indeks = 1;
        }

        public Ksiazka(string tytul, string dataWydania, Enum EnumWydawcy)
        {
            this.tytul = tytul;
            this.dataWydania = DateTime.Parse(dataWydania);
            this.wydawca = wydawca;
            isbn = $"ISBN-{this.dataWydania.Year}-{this.dataWydania.Month}-{this.dataWydania.Day}-{indeks}";
            //isbn = $"ISBN-{this.dataWydania.Year}-{ZmienNaRzymskie(this.dataWydania.Month)}-{this.dataWydania.Day}-{indeks}";
            indeks += 1;
        }

        public override string ToString() 
        {
            string miesiac = dataWydania.ToString("MMMM", new CultureInfo("pl-PL"));
            return $"{isbn}: {tytul}, {wydawca} {{data wydania: {miesiac}-{dataWydania.Year}}}";
        }
    }

    public class BlednyNumerException : Exception
    {
        public BlednyNumerException(string message) : base(message) { }
    }

    internal class Abonent
    {
        string imie;
        string nazwisko;
        string numerTelefonu;
        internal string miasto; //miałam problem z dostępem w funkcji wyszukaj

        public bool SprawdzNumer(string numer)
        {
            string znaki = @"\d{3}-\d{3}-\d{3}$";
            Regex regex = new Regex(znaki);
            return regex.IsMatch(numer);
        }

        public string NumerTelefonu
        {
            get => numerTelefonu;
            set
            {
                if (SprawdzNumer(value)){
                    numerTelefonu = value;
                }
                else
                {
                    throw new BlednyNumerException("Numer telefonu ma niepoprawny format. Podaj numer telefonu w formacie 000-000-000");
                }
            }
        }

        public string Miasto
        {
            get => miasto;
        }

        public Abonent(string imie, string nazwisko, string numerTelefonu, string miasto) 
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numerTelefonu=numerTelefonu;
            this.miasto = miasto;
        }

        public override string ToString()
        {
            return $"{imie} {nazwisko}, {miasto}, {numerTelefonu}";
        }

    }

    internal class KsiazkaTelefoniczna : Ksiazka
    {
        Dictionary<string, Abonent> abonenci;

        public KsiazkaTelefoniczna(string tytul, string dataWydania, Enum EnumWydawcy):base(tytul, dataWydania,EnumWydawcy)
        {
            abonenci = new();
            isbn += "-KT";
        }

        public void DodajAbonenta(Abonent abonent)
        {
            if (!abonenci.ContainsKey(abonent.NumerTelefonu)) //sprawdzamy czy istnieje; musimy to zrobic jak mamy slownik
            {
                abonenci.Add(abonent.NumerTelefonu, abonent);
            }
            else
            {
                Console.WriteLine($"Telefon o numerze {abonent.NumerTelefonu} należy do abonenta {abonenci[abonent.NumerTelefonu].ToString()}.");
            }
        }

        public void UsunAbonenta(string telefon)
        {
            if (abonenci.ContainsKey(telefon))
            {
                abonenci.Remove(telefon);
            }
            else
            {
                Console.WriteLine($"Telefon o numerze {telefon} nie jest w ksiazce telefonicznej.");
            }
        }

        public List<Abonent> WyszukajAbonentow(string Miasto)
        {
            List<Abonent> wyniki = new ();
            foreach (var abonent in abonenci.Values)
            {
                if (abonent.Miasto.Equals(Miasto, StringComparison.OrdinalIgnoreCase))
                {
                    wyniki.Add(abonent);
                }
            }
            return wyniki;
        }

        public override string ToString()
        {
            string info = base.ToString() + "\nAbonenci:\n";
            foreach (var abonent in abonenci.Values)
            {
                info += abonent.ToString() + "\n";
            }
            return info;
        }

    }
}
