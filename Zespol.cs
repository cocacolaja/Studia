using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cwiczenia2Gr2
{
    interface IZapisywalna
    {
        void ZapiszXML(string nazwa);
    }
    public class Zespol : ICloneable, IZapisywalna
    {
        int liczbaAktywnychCzlonkowZespolu;
        string nazwaZespolu;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;

        public Zespol()
        {
            liczbaAktywnychCzlonkowZespolu = 0;
            nazwaZespolu = string.Empty;
            czlonkowie = new(); //!!!!!!!!!!!!!
        }
        public Zespol(string nazwaZespolu, KierownikZespolu kierownik)
            : this()
        {
            this.nazwaZespolu = nazwaZespolu;
            this.kierownik = kierownik;
        }
        public void DodajCzlonkaZespolu(CzlonekZespolu cz)
        {
            if (cz is not null)
            {
                czlonkowie.Add(cz);
                if (cz.Aktywny)
                {
                    ++liczbaAktywnychCzlonkowZespolu;
                }
            }
        }
        public CzlonekZespolu? 
            WyszukajCzlonkowZespolu(string pesel)
        {
            return czlonkowie.Find(cz => cz.Pesel == pesel);
        }

        public void Sortuj()
        {
            czlonkowie.Sort();
            //czlonkowie = czlonkowie.OrderBy(cz=>cz.Nazwisko).ThenBy(cz=>cz.Imie); alternatywna wersja do napisania compereTo w czlonek zespolu
        }

        public object Clone() //napisac alternatywna metode z wykladu(serializacja do pamieci)
        {
            Zespol z = (Zespol)MemberwiseClone();
            z.kierownik= (KierownikZespolu)kierownik.Clone();
            z.czlonkowie = new();
            czlonkowie.ForEach(cz=>z.czlonkowie.Add((CzlonekZespolu)cz.Clone()));
            return z;

        }

        public void SortujPoPesel()
        {
            czlonkowie.Sort(new PeselComparator());
        }

        public bool JestCzlonkiem(CzlonekZespolu cz)
        {
            return czlonkowie.Any(c => c.Equals(cz));
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Zespół: {nazwaZespolu}");
            sb.AppendLine($"Kierownik zespołu: {kierownik}");
            sb.AppendLine("Członkowie zespołu:");
            czlonkowie.ForEach(cz => sb.AppendLine(cz.ToString()));
            return sb.ToString();
        }

        public void ZapiszXML(string nazwa)
        {
            StreamWriter sw = new(nazwa);
            XmlSerializer xs = new(typeof(Zespol));
            xs.Serialize(sw, this);
        }
    }
}
