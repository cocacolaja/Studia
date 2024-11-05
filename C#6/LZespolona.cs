using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia6
{
    internal class LZespolona
    {
        double re;
        double im;

        public LZespolona(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            return $"{re:f2}{(im > 0 ? "+" : "-")}{Math.Abs(im):f2}j";
        }

        // przeładowanie operatorów
        //przeciazamy metode dodawania
        public static LZespolona operator+(LZespolona x, LZespolona y)
        {
            return new(x.re + y.re, x.im + y.im);
        }

        //przeciazamy metode odejmowania
        public static LZespolona operator -(LZespolona x, LZespolona y)
        {
            return new(x.re - y.re, x.im - y.im);
        }

        // (x.re,x.im)(y.re,y.im) = (x.re*y.re-y.im*x.im, xre*y.im + x.im*y.re)
        public static LZespolona operator*(LZespolona x, LZespolona y)
        {
            return new(x.re * y.re - y.im * x.im, x.re * y.im + x.im * y.re);
        }

        public static LZespolona operator/(LZespolona x, LZespolona y)
        {
            // dodać sprawdzeni czy dzielnik !=0
            return new(((x.re * y.re) + (x.im * y.im)) / (y.re * y.re + y.im * y.im), ((x.im * y.re) - (x.re * y.im)) / (y.re * y.re + y.im * y.im)); // nie ma ^2 ???
        }

        public static LZespolona Conj(LZespolona x)
        {
            return new(x.re, -x.im);
        }

        // modul
        public static double Abs(LZespolona x)
        {
            return Math.Sqrt(x.re*x.re + x.im*x.im);
        }

       
    }
}
