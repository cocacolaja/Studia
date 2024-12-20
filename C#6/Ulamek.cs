using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia6
{
    internal class Ulamek
    {

        int licznik;
        int mianownik;


        public Ulamek(int licznik, int mianownik)
        {
            if (mianownik == 0) {
                throw new ArgumentException("Mianownik nie może być zerem.");
            }

            this.licznik = licznik;
            this.mianownik = mianownik;
        }

        public override string ToString()
        {
            return Postac(this);
        }

        // przeładowanie operatorów
        //przeciazamy metode dodawania
        public static Ulamek operator +(Ulamek x, Ulamek y)
        {
            if (x.mianownik == y.mianownik)
            {
                return new(x.licznik + y.licznik, x.mianownik);
            }
            else if (x.mianownik % y.mianownik == 0)
            {
                return new(x.licznik + y.licznik * (x.mianownik / y.mianownik), x.mianownik);
            }
            else if (y.mianownik % x.mianownik == 0)
            {
                return new(y.licznik + x.licznik * (y.mianownik / x.mianownik), y.mianownik);
            }
            else
            {
                return new(x.licznik * y.mianownik + y.licznik * x.mianownik, x.mianownik * y.mianownik);
            }
        }

        //przeciazamy metode odejmowania
        public static Ulamek operator -(Ulamek x, Ulamek y)
        {
            if (x.mianownik == y.mianownik)
            {
                return new(x.licznik - y.licznik, x.mianownik);
            }
            else if (x.mianownik % y.mianownik == 0)
            {
                return new(x.licznik - y.licznik * (x.mianownik / y.mianownik), x.mianownik);
            }
            else if (y.mianownik % x.mianownik == 0)
            {
                return new(y.licznik - x.licznik * (y.mianownik / x.mianownik), y.mianownik);
            }
            else
            {
                return new(x.licznik * y.mianownik - y.licznik * x.mianownik, x.mianownik * y.mianownik);
            }
        }

        // (x.re,x.im)(y.re,y.im) = (x.re*y.re-y.im*x.im, xre*y.im + x.im*y.re)
        public static Ulamek operator *(Ulamek x, Ulamek y)
        {
            return new(x.licznik * y.licznik, x.mianownik * y.mianownik);
        }

        public static Ulamek operator /(Ulamek x, Ulamek y)
        {
            return new(x.licznik * y.mianownik, x.mianownik * y.licznik);
        }
        private static int NWD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a); // NWD zawsze dodatni
        }

        public static Ulamek Skracanie(Ulamek x)
        {
            int nwd = NWD(x.licznik, x.mianownik);
            return new(x.licznik /nwd, x.mianownik /nwd);
        }

        public static string Postac(Ulamek x)
        {
            int reszta = x.licznik % x.mianownik;
            int calkowite = (x.licznik - reszta) / x.mianownik;
            if (x.licznik > x.mianownik)
            {
                return ($"{calkowite}({reszta}/{x.mianownik})");
            }
            else
            {
                return ($"{x.licznik}/{x.mianownik}");
            }
        }

        public static double Dziesietny(Ulamek x)
        {
            return (double)x.licznik / x.mianownik;
        }

    }
}
