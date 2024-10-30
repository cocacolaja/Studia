using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia5
{
    internal class OperatorSieci
    {
        string nazwa;
        Dictionary<string, Abonent> abonenci;

        public OperatorSieci(string nazwa)
        {
            this.nazwa = nazwa;
            abonenci = new(); //!!           
        }

        public void DodajAbonenta(Abonent a)
        {
            if (!abonenci.ContainsKey(a.NumerTelefonu)) //sprawdzamy czy istnieje; musimy to zrobic jak mamy slownik
            {
                abonenci.Add(a.NumerTelefonu, a);
            }
        }

        public Abonent? WyszukajAbonenta(string numerTelefonu)
        {
            // abonenci.FirstOrDefault(a => a.Key == numerTelefonu).Value;
            abonenci.TryGetValue(numerTelefonu, out Abonent? a);
            return a;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Operator: {nazwa}"
                + $"[sumaryczny zysk: {abonenci.Sum(a => a.Value.SumaOplat()):c}]");
            foreach(Abonent a in abonenci.Values)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }

    }
}
