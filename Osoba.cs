using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenia2Gr2
{
    public enum EnumPlec { K, M }

    class PeselComparator : Comparer<Osoba>
    {
        public override int Compare(Osoba? x, Osoba? y)
        {
            if(x is null || y is null) { return 1; }
            return x.Pesel.CompareTo(y.Pesel);
        }
    }

    public abstract class Osoba : IEquatable<Osoba>
    {   // Pola (dane)
        string imie;
        string nazwisko;
        DateTime dataUrodzenia;
        string pesel;
        EnumPlec plec;

        // Właściwości (metody)
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string Pesel
        {
            get => pesel;
            init
            {
                if (!Regex.IsMatch(value, @"\d{11}"))
                {
                    throw new
                        ArgumentException
                        ("Pesel musi mieć 11 cyfr");
                }
                pesel = value;
            }
        }
        public Osoba()
        {
            imie = string.Empty;
            nazwisko = string.Empty;
            Pesel = new string('0', 11);
        }
        public Osoba(string imie, string nazwisko, EnumPlec plec) : this()
        {
            Imie = imie;
            Nazwisko = nazwisko;
            this.plec = plec;
        }
        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec) 
            : this(imie, nazwisko, plec)
        {
            Pesel = pesel;
            if (DateTime.TryParseExact(dataUrodzenia,
                new[] { "dd-MM-yyyy", 
                "yyyy-MM-dd", "dd-MMM-yy"},
                null, DateTimeStyles.None,
                out DateTime d))
            {
                DataUrodzenia = d;
            }
        }
        public override string ToString()
        {
            StringBuilder s = new();
            if (!string.IsNullOrEmpty(Imie)) { s.Append($"{Imie} "); }
            if (!string.IsNullOrEmpty(Nazwisko)) { s.Append($"{Nazwisko} "); }
            s.Append($"({plec})");
            if (DataUrodzenia != default) { s.Append($", {DataUrodzenia:yyyy-MM-dd} [{Wiek()}] "); }
            if (Pesel != new string('0',11)) { s.Append($"({Pesel})"); }
            return s.ToString();
        }
        public int Wiek()
        {
            int w = DateTime.Now.Year - DataUrodzenia.Year;
            int w2 = (DateTime.Now - DataUrodzenia).Days / 365;
            return w2;
        }

        public bool Equals(Osoba? other)
        {
            if(other == null) { return false; }
            return Pesel.Equals(other.Pesel);
        }
    }
}
