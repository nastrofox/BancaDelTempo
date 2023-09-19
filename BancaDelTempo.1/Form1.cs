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
        private List<Utente> user = new List<Utente>();
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Aggiungiutente ag = new Aggiungiutente(user);
            ag.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modificautente ag = new Modificautente();
            ag.ShowDialog();
            this.Close();
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
            this.Hide();
            visualizzasoci ag = new visualizzasoci();
            ag.ShowDialog();
            this.Close();
        }
        public void fillist()
        {

            ListViewItem campi = new ListViewItem();

            for (int i = 0; i < user.Count; i++)
            {

                campi = new ListViewItem(user[i].Cognome);
                campi.SubItems.Add(user[i].Nome);
                campi.SubItems.Add(user[i].Telefono);
                campi.SubItems.Add(Convert.ToString(user[i].Segreteria));
                campi.SubItems.Add(user[i].Lavoro);
                campi.SubItems.Add(Convert.ToString(user[i].OreTotali));
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
                fillist();
            }

        }
    }
}
