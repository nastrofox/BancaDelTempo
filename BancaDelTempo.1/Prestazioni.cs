using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo._1
{
    [Serializable]
    class Prestazione
    {
        public string Tipo { get; set; }
        public string ErogataDa { get; set; }
        public string RicevutaDa { get; set; }
        public int Ore { get; set; }
        public DateTime Data { get; set; }

        public Prestazione()
        {

        }

        public Prestazione(string tipo, string erogataDa, string ricevutaDa, int ore, DateTime data)
        {
            Tipo = tipo;
            ErogataDa = erogataDa;
            RicevutaDa = ricevutaDa;
            Ore = ore;
            Data = data;
        }

        public override string ToString()
        {
            return $"Tipo: {Tipo}, Erogata da: {ErogataDa}, Ricevuta da: {RicevutaDa}, Ore: {Ore}, Data: {Data:yyyy-MM-dd}";
        }
    }

}
