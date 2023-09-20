using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancaDelTempo._1
{
    public partial class aggiugngiprestazione : Form
    {
        public aggiugngiprestazione()
        {
            InitializeComponent();
        }

        private void aggiugngiprestazione_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipo = textBox1.Text;
            string data = textBox5.Text;
            int ore = Convert.ToInt32(textBox3.Text);
            string nome1 = textBox2.Text;
            string cognome1 = textBox6.Text;
            string nome2 = textBox4.Text;
            string cognome2 = textBox7.Text;

            // Assicurati che la lista Utenti sia dichiarata e inizializzata
            List<Utente> Utenti = new List<Utente>();

            // Chiamata alla funzione SpostaOre
            SpostaOre(nome1, cognome1, nome2, cognome2, ore);
        }

        public static void SpostaOre(string nome1, string cognome1, string nome2, string cognome2, float ore)
        {
            // Assicurati che la lista Utenti sia dichiarata e inizializzata
            List<Utente> Utenti = new List<Utente>();

            // Trova l'utente con nome1 e cognome1
            Utente utente1 = Utenti.Find(u => u.Nome == nome1 && u.Cognome == cognome1);

            if (utente1 != null)
            {
                // Sottrai le ore a utente1
                utente1.OreTotali -= ore;

                // Trova l'utente con nome2 e cognome2
                Utente utente2 = Utenti.Find(u => u.Nome == nome2 && u.Cognome == cognome2);

                if (utente2 != null)
                {
                    // Aggiungi le stesse ore a utente2
                    utente2.OreTotali += ore;
                }
                else
                {
                    Console.WriteLine($"Nessun utente trovato con nome: {nome2} e cognome: {cognome2}");
                }
            }
            else
            {
                Console.WriteLine($"Nessun utente trovato con nome: {nome1} e cognome: {cognome1}");
            }
        }
    }
}
