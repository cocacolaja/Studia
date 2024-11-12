using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia2Gr2
{
    public class KierownikZespolu : Osoba, ICloneable
    {

        int doswiadczenieKierownicze;
        long telefonKontaktowy;

        public KierownikZespolu() : base()
        {
            doswiadczenieKierownicze = 1;
        }
        public KierownikZespolu(string imie,
            string nazwisko, EnumPlec plec,
            int doswiadczenieKierownicze,
            long telefonKontaktowy
            ) : base(imie, nazwisko, plec)
        {
            this.doswiadczenieKierownicze = doswiadczenieKierownicze;
            this.telefonKontaktowy = telefonKontaktowy;
        }
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec,
            int doswiadczenieKierownicze, long telefonKontaktowy)
            : this(imie, nazwisko, plec, doswiadczenieKierownicze, telefonKontaktowy)
        {
            Pesel = pesel;
            if (DateTime.TryParseExact(dataUrodzenia,
                new[] { "dd-MM-yyyy",
                "yyyy-MM-dd", "dd-MMM-yy"},
                null, DateTimeStyles.None,
                out DateTime d))
            {
                DataUrodzenia = d;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
