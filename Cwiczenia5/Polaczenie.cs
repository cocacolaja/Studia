//dodanie w klasie abonent do pola numer telefonu set w taki sposob, zeby sprawdzało czy numer telefonu ma postać 000-000-000
namespace Cwiczenia5
{
    class Program
    {
        static void Main()
        {
            Zad6();
        }

        static void Zad6()
        {
            Abonent a1 = new("Jan", "Kowalski", "777 - 034 - 232");
            
            Abonent a2 = new("Edyta", " Nowak ", "666 - 634 - 009");
            Abonent a3 = new("Marian", "Waligóra", "{ 744 - 934 - 229");

            a1.Zadzwon(5.0, EnumTaryfa.taryfa1);
            a1.Zadzwon(3.2, EnumTaryfa.taryfa2);
            a1.Zadzwon(1.2, EnumTaryfa.taryfa2);

            a2.Zadzwon(2.5, EnumTaryfa.taryfa3);
            a2.Zadzwon(12.2, EnumTaryfa.taryfa2);
            a2.Zadzwon(0.2, EnumTaryfa.taryfa1);

            a3.Zadzwon(3.7, EnumTaryfa.taryfa2);
            a3.Zadzwon(4.2, EnumTaryfa.taryfa3);
            a3.Zadzwon(4.8, EnumTaryfa.taryfa3);

            OperatorSieci o1 = new("IDEA");

            o1.DodajAbonenta(a1);
            o1.DodajAbonenta(a2);
            o1.DodajAbonenta(a3);

            Console.WriteLine(o1);

        }
    }
}