using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

namespace Cwiczenia7
{
    interface IZapisywalna
    {
        void ZapiszXml(string nazwaPliku);
    }
    public class Zespol : ICloneable, IZapisywalna
    {
        int liczbaAktywnychCzlonkowZespolu;
        string nazwaZespolu;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;

        public string NazwaZespolu { get => nazwaZespolu; set => nazwaZespolu = value; }
        public KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        public List<CzlonekZespolu> Czlonkowie { get => czlonkowie; set => czlonkowie = value; }

        public Zespol()
        {
            liczbaAktywnychCzlonkowZespolu = 0;
            NazwaZespolu = string.Empty;
            Czlonkowie = new(); //!!!!!!!!!!!!!
        }
        public Zespol(string nazwaZespolu, KierownikZespolu kierownik)
            : this()
        {
            this.NazwaZespolu = nazwaZespolu;
            this.Kierownik = kierownik;
        }
        public void DodajCzlonkaZespolu(CzlonekZespolu cz)
        {
            if (cz is not null)
            {
                Czlonkowie.Add(cz);
                if (cz.Aktywny)
                {
                    ++liczbaAktywnychCzlonkowZespolu;
                }
            }
        }
        public CzlonekZespolu? 
            WyszukajCzlonkowZespolu(string pesel)
        {
            return Czlonkowie.Find(cz => cz.Pesel == pesel);
        }

        public void Sortuj()
        {
            Czlonkowie.Sort();
            //czlonkowie = czlonkowie.OrderBy(cz=>cz.Nazwisko).ThenBy(cz=>cz.Imie); alternatywna wersja do napisania compereTo w czlonek zespolu
        }

        public Zespol? Clone() //napisac alternatywna metode z wykladu(serializacja do pamieci)
        {
            //Zespol z = (Zespol)MemberwiseClone();
            //z.Kierownik = (KierownikZespolu)Kierownik.Clone();
            //z.Czlonkowie = new();
            //Czlonkowie.ForEach(cz =>z.Czlonkowie.Add((CzlonekZespolu)cz.Clone()));
            //return z;


            //za pomoca DataContract

                MemoryStream ms = new();
                DataContractSerializer dcs = new(typeof(Zespol));
                dcs.WriteObject(ms, this);
                ms.Position = 0; // powrót na początek strumienia
                return (Zespol?)dcs.ReadObject(ms);


        }

        public void SortujPoPesel()
        {
            Czlonkowie.Sort(new PeselComparator());
        }

        public bool JestCzlonkiem(CzlonekZespolu cz)
        {
            return Czlonkowie.Any(c => c.Equals(cz));
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Zespół: {NazwaZespolu}");
            sb.AppendLine($"Kierownik zespołu: {Kierownik}");
            sb.AppendLine("Członkowie zespołu:");
            Czlonkowie.ForEach(cz => sb.AppendLine(cz.ToString()));
            return sb.ToString();
        }

        public void ZapiszXml(string nazwaPliku)
        {
            using StreamWriter sw = new(nazwaPliku);
            XmlSerializer xs = new(typeof(Zespol));
            xs.Serialize(sw, this);
        }

        public static Zespol? OdczytXml(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku)) { return null; }
                using StreamReader sr = new(nazwaPliku);
                XmlSerializer xs = new(typeof(Zespol));
                return (Zespol?)xs.Deserialize(sr);
        }

       public void ZapiszDCXML(string nazwa)//zmieniono z bool na void
        {
            DataContractSerializer dsc = new(typeof(Zespol));
            using XmlTextWriter writer = new("zespol.xml", Encoding.UTF8); // tu można dać nazwa(to od string nazwa), zamiast zespol
            dsc.WriteObject(writer, this);
        }

        public static Zespol? OdczytajDCXML (string nazwa)
        {
            if (!File.Exists(nazwa)) { return null; }
            DataContractSerializer dsc = new(typeof(Zespol));
            using XmlTextReader reader = new("zespol.xml"); // tu można dać nazwa(to od string nazwa), zamiast zespol
            return (Zespol?)dsc.ReadObject(reader);
        }

        
    }
}
