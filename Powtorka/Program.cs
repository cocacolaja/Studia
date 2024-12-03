namespace Powtorka2
{
    internal class Program
    {
        static void Main()
        {
            FarbaSpecjalna f1 = new("Atlas", EnumKolor.Żółta, "12/09/2030", EnumTyp.winylowa);
            Console.WriteLine(f1);
        }
    }
}
