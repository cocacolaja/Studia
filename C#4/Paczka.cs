using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia4
{
    internal class Paczka
    {
        //co oznaczaja pola statyczne
        //pola statyczne uzywwagy gdy chcemy zeby wszystkie obiekty z klasy mialy dostep do tej samej wartosci
        //lub chcemy tak jak w aktualnyNumer zeby odnosily sie do jednego pola(gdzie bedzie prawa)
        static int aktualnyNumer;
        static float oplataZaKg;
        
        private string nadawca;
        private int rozmiar;
        private string numerPaczki;

        //klasa moze posiadac tylko jeden konstruktor statyczny
        static Paczka()
        {
            aktualnyNumer = 100;
            oplataZaKg = 0.5f;
        }
        //konstruktor nieparamtryczny 
        public Paczka()
        {
            nadawca = string.Empty;
            Rozmiar = 1;
            numerPaczki = $"P/{aktualnyNumer++:d6}/{DateTime.Now.Year}"; //zwieksza sie numer paczki przy kazdej kolejnej; d6 zapisuje sie na 6 pozycjach ten numer
        }

        //konstruktor parametryczny
        public Paczka(string nadawca, int rozmiar)
            :this() //bo chcemy zeby numer paczki byl nadany tak jak mamy w konstruktorze domyslnym
        {
            this.nadawca = nadawca;
            this.Rozmiar = rozmiar;
        }

        public int Rozmiar { get => rozmiar;
            set
            {
                if(value < 0)
                {
                    throw new Exception { };
                }
                rozmiar = value;
            } 
        }


        //metoda wirtualna- mozemy w klasach dziedzicznych nadpisac metode zeby obliczyc ja w inny sposob
        public virtual float KosztWysylki()
        {
            return oplataZaKg * Rozmiar;
        }

        //nadpisujemy metode ToString(), żeby wyswietlala nam obiekty klasy w taki sposob jak chcemy
        //standardowo by wypisala po prosty wszystkie pola po kolei
        public override string ToString() 
        {
            return $"{numerPaczki}: {nadawca}, rozmiar: {Rozmiar} (koszt: {KosztWysylki():c})";
        }
    }
}
