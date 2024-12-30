using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KolosG
{
    public abstract class Osoba
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string numerTelefonu { get; set; }
        public string pesel;
        public DateTime dataUrodzenia { get; private set; }

        public string Pesel
        {
            get => pesel;
            set
            {
                if (Regex.IsMatch(value, @"^\d{11}$"))
                    throw new FormatException("Pesel musi skladac sie z 11 cyfr");
                else pesel = value;
            }
        }
        public string NumerTelefonu
        {
            get => numerTelefonu;
            set
            {
                if (Regex.IsMatch(value, @"^\d{9}$"))
                    throw new FormatException("Numer telefonu musi skladac sie z 9 cyfr");
                else numerTelefonu = value;
            }
        }

        protected Osoba(string imie, string nazwisko, string numerTelefonu, string pesel, DateTime dataUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numerTelefonu = numerTelefonu;
            this.pesel = Pesel;
            this.dataUrodzenia = dataUrodzenia;
            //tu nie dziala tryparse
            //if (DateTime.TryParseExact(dataUrodzenia,
            //    new[] { "dd-MM-yyyy", "yyyy-MM-dd" },
            //     CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            //{
            //    DataUrodzenia = parsedDate;
            //}
            //else
            //{
            //    throw new ArgumentException("Niepoprawny format daty urodzenia. Użyj formatu dd-MM-yyyy lub yyyy-MM-dd.");
            //}
        }

        protected Osoba()
        {
        }

        public override string ToString()
        {
            return $"Imię: {imie}, Nazwisko: {nazwisko}, PESEL: {Pesel}, Numer telefonu: {numerTelefonu}";
        }
    }
}