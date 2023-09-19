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


namespace BancaDelTempo._1
{
    public partial class Aggiungiutente : Form
    {
        private List<Utente> nuovalista = new List<Utente>();
        public Aggiungiutente(List<Utente> lista)
        {
            InitializeComponent();
            if(lista != null)
            {
                nuovalista = lista;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;
            string d = textBox4.Text;
            // Verifica se il testo contiene caratteri diversi da lettere
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Inserire il cognome.");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Inserire il nome.");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Inserire il numero di telefono.");
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Inserire il lavoro.");
            }
            else
            {
                Utente nuovo = new Utente(a, b, c, checkBox1.Checked, d, 0);
                nuovalista.Add(nuovo);
                SalvaUtenteSuFileJson(nuovalista);
                this.Hide();
                Form1 ag = new Form1();
                ag.ShowDialog();
                this.Close();
            }

            

        }
        private void SalvaUtenteSuFileJson(List<Utente> utente)
        {
            string jsonUtente = JsonConvert.SerializeObject(utente);

            string percorsoFile = "./utente.json";

            System.IO.File.WriteAllText(percorsoFile, jsonUtente);

            MessageBox.Show("Utente salvato con successo!");
        }


        private void Aggiungiutente_Load(object sender, EventArgs e)
        {

        }
    }
}
