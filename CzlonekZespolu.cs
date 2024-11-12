using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia2Gr2
{
    public class CzlonekZespolu : Osoba, IComparable<CzlonekZespolu>, ICloneable
    {
        DateTime dataWstapienia;
        string funkcjaWZespole;
        bool aktywny;

        public bool Aktywny { get => aktywny; 
            set => aktywny = value; }

        public CzlonekZespolu() : base()
        {
            funkcjaWZespole = string.Empty;
            Aktywny = true;
        }
        public CzlonekZespolu(string imie, string nazwisko, EnumPlec plec, string dataWstapienia, string funkcjaWZespole
            ) : base(imie, nazwisko, plec)
        {
            this.funkcjaWZespole = funkcjaWZespole;
            Aktywny = true;
            if (!DateTime.TryParseExact(dataWstapienia,
                new[] { "dd-MM-yyyy", "yyyy-MM-dd" },
                null, DateTimeStyles.None,
                out this.dataWstapienia))
            {
                throw new ArgumentException("Niepoprawna data!");
            }
        }
        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec,
            string dataWstapienia, string funkcjaWZespole)
            : this(imie, nazwisko, plec, dataWstapienia, funkcjaWZespole)
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

        public int CompareTo(CzlonekZespolu? other)
        {
            if(other is null)
            {
                return 1;
            }
            int cmp = Nazwisko.CompareTo(other.Nazwisko);
            if (cmp != 0)
            {
                return cmp;
            }
            else
            {
                return Imie.CompareTo(other.Imie);
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
