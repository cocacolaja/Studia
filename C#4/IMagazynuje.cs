using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia4
{
    internal interface IMagazynuje //kazda klasa ktora
    {//kazda klasa ktora implementuje ten interfesj musi zawierac te metody, choc moga byc inaczej napisane
        void Umiesc(Paczka p);
        Paczka Pobierz();
        void Wyczysc();
        int PodajIlosc();
        Paczka PodajBiezacy();

    }
}
