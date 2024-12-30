using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Runtime.Serialization;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace KolosG
{
    [DataContract]
    class NazwaComparer : Comparer<Wynajecie>
    {
        public override int Compare(Wynajecie? x, Wynajecie? y)
        {
            if (y.nazwaKlienta == null || x.nazwaKlienta == null) return 1;
            return x.nazwaKlienta.CompareTo(y.nazwaKlienta);
        }
    }
    public class Wynajecie : IComparable<Wynajecie>
    {

        static int biezaceWynajecie { get; set; }
        [DataMember]
        public string numerWynajecia { get; set; }
        [DataMember]
        public string nazwaKlienta { get; set; }
        [DataMember]
        public Mieszkanie wynajeteMieszkanie { get; set; }
        [DataMember]
        DateTime dataWynajecia { get; set; }
        [DataMember]
        DateTime dataZwolnienia { get; set; }

        static Wynajecie()
        {
            biezaceWynajecie = 100;
        }

        public Wynajecie()
        {
        }

        public Wynajecie(string NazwaKlienta, Mieszkanie wynajeteMieszkanie, DateTime dataWynajecia, DateTime dataZwolnienia) : this()
        {
            this.wynajeteMieszkanie = wynajeteMieszkanie;
            this.dataWynajecia = dataWynajecia;
            this.dataZwolnienia = dataZwolnienia;
            this.nazwaKlienta = NazwaKlienta;
            numerWynajecia = $"{biezaceWynajecie}/{DateTime.Now.Month}/{DateTime.Now.Year}";
        }

        public string NazwaKlienta
        {
            get => nazwaKlienta;
            set
            {
                if (value.Length <= 3) throw new ZlaNazwaexception();
                nazwaKlienta = value;
            }
        }

        public override string ToString()
        {
            return $"Wyn.Numer: {numerWynajecia}, Klient:{nazwaKlienta}, Mieszkanie:{wynajeteMieszkanie},\n" +
                $"{wynajeteMieszkanie.adres}, data wynajecia:{dataWynajecia}, data zwolnienia:{dataZwolnienia}" +
                $", czy wolne - {wynajeteMieszkanie.wolny}";
        }

        public double ObliczCene()
        {
            double cena = 0;
            int dni = (dataZwolnienia - dataWynajecia).Days;
            cena = (double)Mieszkanie.cenaPodstawowa * dni;
            return cena;
        }

        public int CompareTo(Wynajecie? obj)
        {
            if (obj == null) return 1;

            return dataZwolnienia.CompareTo(obj.dataZwolnienia);
        }


    }

    [Serializable]
    internal class ZlaNazwaexception : Exception
    {
        public ZlaNazwaexception()
        {
        }

        public ZlaNazwaexception(string? message) : base(message)
        {
        }

        public ZlaNazwaexception(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}