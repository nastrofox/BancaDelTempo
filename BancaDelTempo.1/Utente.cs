using System;
using System.Collections.Generic;

namespace BancaDelTempo._1
{
    [Serializable]
    class Utente
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Telefono { get; set; }
        public bool Segreteria { get; set; }
        public string Lavoro { get; set; } 
        public int OreTotali { get; set; }

        public Utente()
        {
        }

        public Utente(string cognome, string nome, string telefono, bool segreteria, string lavoro, int oreTotali)
        {
            Cognome = cognome;
            Nome = nome;
            Telefono = telefono;
            Segreteria = segreteria;
            Lavoro = lavoro;
            OreTotali = 0;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Cognome: {Cognome}, Telefono: {Telefono}, Segreteria: {Segreteria}, Lavoro: {Lavoro}, Ore Totali: {OreTotali}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Utente other = (Utente)obj;
            return this.Nome == other.Nome && this.Cognome == other.Cognome;
        }
    }
}
