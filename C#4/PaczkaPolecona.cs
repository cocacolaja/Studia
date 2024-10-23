using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia4
{
    internal class PaczkaPolecona : Paczka //dziedziczy po klasie paczka
    {
        static float oplataDodatkowa;

        //konstruktor statyczny
        static PaczkaPolecona()
        {
            oplataDodatkowa = 10.0f;
        }

        public PaczkaPolecona() :base() { } //dziedziczy konstruktor nieparametryczny po klasie Paczka
        
        public PaczkaPolecona(string nadawca, int rozmiar) 
            : base(nadawca, rozmiar) { } //dziedziczy konstruktor parametryczny

        public override float KosztWysylki() // nadpisanie metody wirtualnej
        {
            return base.KosztWysylki() + oplataDodatkowa; //base.KosztWYsylki obliczy nam podstawowa cene wiec musimy tylko doliczyc oplate za paczke polecona
        }

        public override string ToString()
        {
            return $"{base.ToString()} (w tym op.dod.{oplataDodatkowa})"; //base to co odziedziczone plus co chcemy dla tej podklasy
        }

    }
}
