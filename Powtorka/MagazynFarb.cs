using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Powtorka2
{
    public class MagazynFarb
    {
        string nazwa;
        List<Farba> farby;

        public string Nazwa { get =>  nazwa; set => nazwa = value; }
        public List<Farba> Farby { get => farby; set => farby = value; }

        public MagazynFarb()
        {
            Farby = new();
        }

        public MagazynFarb(string nazwa):this() 
        {
            Nazwa= nazwa;
        }

        public void DodajFarbe(Farba f)
        {
            Farby.Add(f);
        }
        
        public void UsunPrzedatowane(uint i)
        {
            DateTime now = DateTime.Now;
            int dni = now.Day;
            for(int j = 0;  j < Farby.Count; j++)
            {
                if (Farby[j].DataWażności.Day < dni+i) { Farby.RemoveAt(j); }
            }
        }

        public List<Farba>  ZnajdzFarby(EnumKolor k)
        {
            return Farby.FindAll(f=>f.Kolor==k);
        }




    }
}
