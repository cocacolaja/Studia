using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//FIFO (first in, first out) np. klienci, ten ktory pierwszy stanie w kolejce zostanie pierwszy obsluzony
//do fifo kolejki
namespace Cwiczenia4
{
    internal class MagazynFIFO : IMagazynuje //implementuje interfejs
    {
        string nazwa;
        int iloscPaczek;
        Queue<Paczka> kolejkaPaczek;

        public MagazynFIFO()
        {
            nazwa = string.Empty;
            iloscPaczek = 0;
            kolejkaPaczek = new();//niezbedne! tworzenie nowego obiektu kolejki paczek
        }
        //implementacja przez szybkie akcje
        public MagazynFIFO(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }

        public Paczka Pobierz()
        {
            return kolejkaPaczek.Dequeue();
        }

        public Paczka PodajBiezacy()
        {
            return kolejkaPaczek.Peek();
        }

        public int PodajIlosc()
        {
            return kolejkaPaczek.Count();
        }

        public void Umiesc(Paczka p)
        {
            kolejkaPaczek.Enqueue(p);
        }

        public void Wyczysc()
        {
            kolejkaPaczek.Clear(); // czysci caly stos
        }

        public float KosztPaczek()
         => kolejkaPaczek.Max(p => p.KosztWysylki());
        //


        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Magazyn: \"{nazwa}\" ({KosztPaczek():c})\n");
            foreach (Paczka p in kolejkaPaczek)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString();
        }
    }
}

