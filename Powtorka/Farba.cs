using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
 
namespace Powtorka2
{
    public class CenaMinimalnaException : Exception
    {
        public CenaMinimalnaException() : base() { }
        public CenaMinimalnaException(string message) : base(message) { }
        public CenaMinimalnaException(string message, Exception exception) : base(message, exception) { }
    }

    public enum EnumKolor { Biała, Żółta, Czerwona, Zielona, Niebieska}
    public class Farba
    {
        string producent;
        EnumKolor kolor;
        DateTime dataWażności;
        double dodatekDoCeny;
        protected static double cenaPodstawowa;

        public string Producent
        {
            get => producent; set
            {
                if (value.Length < 3) { throw new ArgumentException("Za krotka nazwa producenta"); }
                producent = value;
            }
        }
        public DateTime DataWażności { get => dataWażności; set=> dataWażności = value; }
        public double DodatekDoCeny {  get => dodatekDoCeny; set => dodatekDoCeny = value; }
        public EnumKolor Kolor { get => kolor; set => kolor = value; }

        static Farba()
        {
            cenaPodstawowa = 5;
        }

        public Farba()
        {
            DodatekDoCeny = 0;
        }

        public Farba(string producent, EnumKolor kolor, string dataWażności) : this()
        {
            Producent = producent;
            if(DateTime.TryParseExact(dataWażności, new string[] {"dd-MM-yyyy", "dd/MM/yyyy", "dd-MM-yyyy" }, null,DateTimeStyles.None, out DateTime d ))
            {
                DataWażności = d;
            }
            Kolor = kolor;
            Random rand = new Random();
            DodatekDoCeny = rand.NextDouble()*10;
        }

        public virtual double Cena()
        {
            return cenaPodstawowa + dodatekDoCeny;
        }

        public virtual double SprawdzDateWażności()
        {
            DateTime d = DateTime.Now;
            int dni = (d- DataWażności).Days;
            double c = Cena() - 0.01 * dni;
            if (c < cenaPodstawowa) { throw new CenaMinimalnaException("Nie mozna wiecej obnizyc ceny farby"); }
            return c;
        }



        public override string ToString()
        {
            return $"Farba producenta: {Producent}, koloru {Kolor}, o dacie ważności {DataWażności:dd/MM/yyyy}";
        }

    }
}