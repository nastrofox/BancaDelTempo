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
    public partial class Aggiungiutente : Form
    {
        public Aggiungiutente()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;
            string d = textBox4.Text;
            // Verifica se il testo contiene caratteri diversi da lettere
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Inserire solo lettere.");
                textBox1.Text = "";
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Inserire solo lettere.");
                textBox2.Text = "";
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Inserire solo numeri.");
                textBox3.Text = "";
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Inserire solo lettere.");
                textBox4.Text = "";
            }
            Utente nuovo = new Utente(a, b, c, checkBox1.Checked, d, 0);

        }
    }
}
