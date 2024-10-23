using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//LIFO (Last in, First out) np gdy ukladamy talerze to ten ktory odlozymy ostatni bedzie wziety jako pierwszy
//do lifo stosy
namespace Cwiczenia4
{
    internal class MagazynLIFO : IMagazynuje //implementuje interfejs
    {
        string nazwa;
        int iloscPaczek;
        Stack<Paczka> stosPaczek;

        public MagazynLIFO()
        {
            nazwa = string.Empty;
            iloscPaczek = 0;
            stosPaczek = new();//niezbedne!!!!
        }
        //implementacja przez szybkie akcje
        public MagazynLIFO(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }

        public Paczka Pobierz()
        {
            return stosPaczek.Pop();
        }

        public Paczka PodajBiezacy()
        {
            return stosPaczek.Peek(); // podaje paczke z przodu nie usuwajac
        }

        public int PodajIlosc()
        {
            return stosPaczek.Count();
        }

        public void Umiesc(Paczka p)
        {
            stosPaczek.Push(p);
        }

        public void Wyczysc()
        {
            stosPaczek.Clear(); // czysci caly stos
        }

        public float KosztPaczek()
         => stosPaczek.Sum(p => p.KosztWysylki());
        //


        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Magazyn: \"{nazwa}\" ({KosztPaczek():c})\n");
            foreach (Paczka p in stosPaczek)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }
    }
}