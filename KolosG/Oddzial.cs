using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace KolosG
{
    [DataContract]
    public class Oddzial
    {

        [DataMember]
        public string nazwaOddzial { get; set; }
        [DataMember]
        public string miasto { get; set; }
        [DataMember]
        public int iloscMieszkan { get; set; }
        [DataMember]
        public LinkedList<Mieszkanie> mieszkania { get; set; }
        //array nie pracuje
        [DataMember]
        public List<Wynajecie> listaWynajmowan { get; set; }

        public Oddzial(string nazwaOddzial, string miasto)
        {
            this.nazwaOddzial = nazwaOddzial;
            this.miasto = miasto;
            mieszkania = new();
            listaWynajmowan = new();
        }

        public void DodajMieszkanie(Mieszkanie m)
        {
            mieszkania.AddFirst(m);
            iloscMieszkan++;

        }
        //tu bierzemy wynajecie a nie mieszkanie
        public void DodajWynajecie(Wynajecie w)
        {
            listaWynajmowan.Add(w);
            w.wynajeteMieszkanie.wolny = false;
        }
        public void PodajWolneMieszkania()
        {
            foreach (var m in mieszkania)
            {
                if (m.wolny) Console.WriteLine(m.ToString());
            }
        }

        public void Wynajmij(Wynajecie w)
        {

            w.wynajeteMieszkanie.wolny = false;
            listaWynajmowan.Add(w);

            //usunac z listy mieszkan
        }

        //dupa wtf
        public void Zwolnij(Mieszkanie wynajeteMieszkanie)
        {
            var wynajem = listaWynajmowan.FirstOrDefault(w => w.wynajeteMieszkanie == wynajeteMieszkanie);
            if (wynajem != null)
            {
                wynajem.wynajeteMieszkanie.wolny = true;
                listaWynajmowan.Remove(wynajem);
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"oddzial {nazwaOddzial} ma mieszkania:\n");
            foreach (var m in listaWynajmowan)
            { sb.AppendLine(m.ToString()); }
            return sb.ToString();
        }

        //campareto klasa i objekt ktory bedziemy powownywac
        public void Sortuj()
        {
            listaWynajmowan.Sort();
        }

        //metoda po nazwie sortowanie
        public void SortujNazwa()
        {
            listaWynajmowan.Sort(new NazwaComparer());
        }

        //zapis DataContract

        public void ZapisDCXml(string nazwaPliku)
        {
            DataContractSerializer dsc = new(typeof(Oddzial));
            using XmlTextWriter writer = new(nazwaPliku, Encoding.UTF8);
            dsc.WriteObject(writer, this);
            Console.WriteLine("zapisano xml");
        }

        public static Oddzial? OdczytDCXml(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku)) { return null; }
            DataContractSerializer dsc = new(typeof(Oddzial));
            using XmlTextReader reader = new(nazwaPliku);
            return (Oddzial?)dsc.ReadObject(reader);
        }
    }

}