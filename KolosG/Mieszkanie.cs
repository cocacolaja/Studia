using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KolosG
{
    public enum EnumRodzaj { Luksus, Standart, Podstawa }
    [DataContract]
    public class Mieszkanie
    {
        //get set to metody dostepowe
        [DataMember]
        public string adres { get; set; }
        [DataMember]
        public EnumRodzaj rodzaj { get; set; }
        [DataMember]
        public int liczbaPokoi { get; set; }
        [DataMember]
        public bool wolny { get; set; }
        [DataMember]
        public static double cenaPodstawowa { get; set; }
        [DataMember]
        public static int nrMieszkania { get; set; }
        //i ten private set to tylko do odczytu
        [DataMember]
        public string identyfikator { get; private set; }

        static Mieszkanie()
        {
            cenaPodstawowa = 65;
            nrMieszkania = 0;
        }

        public Mieszkanie(string adres, EnumRodzaj rodzaj, int liczbaPokoi, bool wolny) : this()
        {
            this.adres = adres;
            this.rodzaj = rodzaj;
            this.liczbaPokoi = liczbaPokoi;
            this.identyfikator = $"{nrMieszkania}: {rodzaj}";
            this.wolny = wolny;
        }

        //domyslny
        public Mieszkanie()
        {
            nrMieszkania++;
            wolny = true;
            adres = null;
        }

        public override string ToString()
        {
            if (wolny)
                return $"iD {identyfikator} ({adres}/cena wynajmu={cenaPodstawowa}) o liczbie pokoi {liczbaPokoi} jest wolne";
            else return $"iD {identyfikator} ({adres}/cena wynajmu={cenaPodstawowa}) o liczbie pokoi {liczbaPokoi} nie jest wolne";
        }
    }
}