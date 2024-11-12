namespace Cwiczenia2Gr2
{
    class Program
    {
        static void Main()
        {
            CzlonekZespolu cz1 = new("Joanna", "Brodzik","01-05-1999","12345678911", EnumPlec.K,
                "12-06-2023", "grafik");
            CzlonekZespolu cz2 = new("Kazimierz", "Jabłoński", "20-03-1979", "92312367891", EnumPlec.M,
                "01-12-2021", "programista");
            CzlonekZespolu cz3 = new("Ewelina", "Mazurek", "28-11-2000", "34567187691", EnumPlec.K,
                "12-06-2023", "grafik");
            CzlonekZespolu cz4 = new("Kamila", "Brodzik", "09-05-1990", "44427856791", EnumPlec.K,
                "11-06-2023", "grafik");
            KierownikZespolu k = new("Beata", "Nowak", EnumPlec.K,
                9, 567099123);
            //Console.WriteLine(cz1);
            //Console.WriteLine(cz2);
            //Console.WriteLine(k);
            Zespol z = new("ZespolIT", k);
            z.DodajCzlonkaZespolu(cz1);
            z.DodajCzlonkaZespolu(cz2);
            z.DodajCzlonkaZespolu(cz3);
            z.DodajCzlonkaZespolu(cz4);
            Console.WriteLine(z);
            //z.Sortuj();
            //Console.WriteLine("Posortowane po nazwisku i imieniu:");
            //Console.WriteLine(z);
            Console.WriteLine("Posortowane po numerze PESEL");
            Console.WriteLine(z);
            z.ZapiszXML("zespol.xml");

        }
    }
}
