using System;
// domowe
// obsługa braku danych w miejsce ToString braku danych wypisanie braku
//zad 7

namespace Cwiczenia2
{
    class Program
    {
        static void Main()
        {
            Osoba os = new("Joanna", "Brodzik", EnumPlec.K);
            // wywołanie konstruktora domyslnego
            //{ Pesel = "11111111313" }; //new string('0', 11) }; //w peselu 11 zer

            Osoba os2 = new("Kazimierz", "Jablonski", EnumPlec.M)
            {
                Pesel = "01123088332"
            };

            Osoba os3 = new("Beata", "Nowak", "1992 - 10 - 22", "99041398765", EnumPlec.K);

            Console.WriteLine(os);
            Console.WriteLine(os2);
            Console.WriteLine(os3);
        }
    }
}

