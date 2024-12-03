using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powtorka2
{
    enum EnumTyp { lateksowa, winylowa}
    internal class FarbaSpecjalna:Farba
    {
        EnumTyp typ;
        double cenaSpecjalna;

        public double CenaSpecjalna { get => cenaSpecjalna; set => cenaSpecjalna = value; }

        public FarbaSpecjalna():base()
        {
            CenaSpecjalna = 0;
        }
        public FarbaSpecjalna(string producent, EnumKolor kolor, string dataWażności, EnumTyp typ):base(producent, kolor, dataWażności)
        {
            Random rand = new Random();
            CenaSpecjalna = rand.NextDouble()*3 +2;
            this.typ = typ;
        }

        public override double Cena()
        {
            return base.Cena()+CenaSpecjalna;
        }

        public override double SprawdzDateWażności()
        {
            DateTime d = DateTime.Now;
            int dni = (d - DataWażności).Days;
            double c = Cena() - 0.02 * dni;
            if (c < Farba.cenaPodstawowa) { throw new CenaMinimalnaException("Nie mozna wiecej obnizyc ceny farby"); }
            return c;
        }

        public override string ToString()
        {
            return base.ToString() + $" typ: {typ}";
        }


    }
}
