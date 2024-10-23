namespace Cwiczenia4
{
    class Program
    {
        static void Main()
        {
            try
            {
                Paczka p1 = new("NadawcaA", 9);
                Paczka p2 = new("NadawcaB", 5);

                PaczkaPolecona pp1 = new("NadawcaC", 11);
                PaczkaPolecona pp2 = new("NadawcaD", 4);
                MagazynFIFO mKolejka = new("Magazyn Paczek\n"); //"zmienna typu Magazyn FIFO" odniesienie sie do tego magazynu paczek, moze miec dowolna nazwe
                mKolejka.Umiesc(p1);
                mKolejka.Umiesc(p2);
                mKolejka.Umiesc(pp1);
                mKolejka.Umiesc(pp2);
                Console.WriteLine(mKolejka);
                Paczka pp = mKolejka.Pobierz();
                Console.WriteLine(pp);
                Console.WriteLine(mKolejka);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}