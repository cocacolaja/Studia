// do domu klasa ułamek, zdefionowac wszystkie operacje podstw., skrócić,
// przedstawic jako czesc calkowita i ulamek, wymyslic cos jak zadanie 1, wybranie najw z listy albo cos w tym stylu, kazdy inne(posortowac
// wyslac zadanie domowe
// dopisać w zadaniu 1 sortowanie ze zdjęcia

namespace Cwiczenia6
{
    class Program
    {
        static void Test1()
        {
            LZespolona z1 = new(5, 6);
            LZespolona z2 = new(-5, 2);

            Console.WriteLine(z1);
            Console.WriteLine(z2);

            Console.WriteLine(z1 + z2);
            Console.WriteLine(z1 - z2);
            Console.WriteLine(z1 * z2);
            Console.WriteLine(z1 / z2);
        }

        static void Zadanie1()
        {
            //lista liczb zespolonych gdzie liczby zespolone to l. losowe i posortowć wedlug modulu
            Random rand = new Random();
            List<LZespolona> lzespolone = new();


            for (int i = 0; i < 10; i++)
            {
                LZespolona z = new(rand.NextDouble() * 20 - 10 + 1, rand.NextDouble() * 20 - 10 + 1);
                lzespolone.Add(z);
            }

            lzespolone.ForEach(lz => Console.WriteLine($"{lz}, " + $"{LZespolona.Abs(lz):f2}"));

            lzespolone.Sort((lz1,lz2)=> LZespolona.Abs(lz1).CompareTo(LZespolona.Abs(lz2))
                            
            Console.WriteLine("Po sortowaniu");
                            
            lzespolone.ForEach(lz => Console.WriteLine($"{lz}, " + $"{LZespolona.Abs(lz):f2}"));
                            
        }

        static void Main()
        {
            //Test1();
            Zadanie1();
        }
    }
}
