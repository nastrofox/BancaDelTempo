using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace BancaDelTempo._1
{
    public partial class Form1 : Form
    {
        public static List<Utente> user = new List<Utente>();
        public bool first = true;
        public Form1()
        {
            InitializeComponent();
            user = CaricaUtentiDaFileJson();
        }
        private List<Utente> CaricaUtentiDaFileJson()
        {
            string percorsoFile = "./utente.json";

            if (System.IO.File.Exists(percorsoFile))
            {
                string jsonUtente = System.IO.File.ReadAllText(percorsoFile);
                List<Utente> listaUtenti = JsonConvert.DeserializeObject<List<Utente>>(jsonUtente);
                return listaUtenti;
            }
            else
            {
                return new List<Utente>();
            }
        }
        public void AggiornaListView()
        {
            listView1.Items.Clear();

            fillist(user);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Aggiungiutente ag = new Aggiungiutente(user);
            ag.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RimuoviUtenteDaListView();
        }
        private void RimuoviUtenteDaListView()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string nome = listView1.SelectedItems[0].SubItems[1].Text;
                string cognome = listView1.SelectedItems[0].SubItems[0].Text;

                RimuoviUtenteDaFileJson(nome, cognome);
            }
            else
            {
                MessageBox.Show("Seleziona un utente da rimuovere.");
            }
        }

        public void RimuoviUtenteDaFileJson(string nome, string cognome)
        {
            List<Utente> listaAttuale = CaricaUtentiDaFileJson();
            Utente utenteDaRimuovere = listaAttuale.Find(u => u.Nome == nome && u.Cognome == cognome);

            if (utenteDaRimuovere != null)
            {
                listaAttuale.Remove(utenteDaRimuovere);

                string jsonUtente = JsonConvert.SerializeObject(listaAttuale);
                string percorsoFile = "./utente.json";
                System.IO.File.WriteAllText(percorsoFile, jsonUtente);

                MessageBox.Show("Utente rimosso con successo!");
                AggiornaListView();
            }
            else
            {
                MessageBox.Show("Utente non trovato nel file JSON.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            aggiugngiprestazione ag = new aggiugngiprestazione();
            ag.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MostraUtentiOreNegative();
        }
        public static void MostraUtentiOreNegative()
        {
            var utentiOreNegative = user.Where(u => u.OreTotali < 0);

            if (utentiOreNegative.Any())
            {
                string message = "Utenti con ore totali inferiori a 0:\n\n";

                foreach (var utente in utentiOreNegative)
                {
                    message += $"{utente.Nome} {utente.Cognome} - Ore Totali: {utente.OreTotali}\n";
                }

                MessageBox.Show(message, "Utenti con ore negative");
            }
            else
            {
                MessageBox.Show("Nessun utente con ore totali inferiori a 0.", "Utenti con ore negative");
            }
        }
        public void fillist(List<Utente> userList)
        {
            listView1.Items.Clear();
            ListViewItem campi = new ListViewItem();

            for (int i = 0; i < userList.Count; i++)
            {
                campi = new ListViewItem(userList[i].Cognome);
                campi.SubItems.Add(userList[i].Nome);
                campi.SubItems.Add(userList[i].Telefono);
                campi.SubItems.Add(Convert.ToString(userList[i].Segreteria));
                campi.SubItems.Add(userList[i].Lavoro);
                campi.SubItems.Add(Convert.ToString(userList[i].OreTotali));
                listView1.Items.Add(campi);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string filename = @"./utente.json" ;
            string jsonData;
            StreamReader sr = new StreamReader(filename);
            jsonData=sr.ReadToEnd();
            sr.Close();
            user = JsonConvert.DeserializeObject<List<Utente>>(jsonData);

            if (first)//only the first time 
            {
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                first = false;

                listView1.Columns.Add("COGNOME", 100);
                listView1.Columns.Add("NOME", 100);
                listView1.Columns.Add("TEL.", 100);
                listView1.Columns.Add("SEGRETERIA", 90);
                listView1.Columns.Add("LAVORO", 100);
                listView1.Columns.Add("ORE TOTALI", 100);

            }
            if (user != null && user.Count > 0)
            {
                fillist(user);
            }

        }
    }
}
