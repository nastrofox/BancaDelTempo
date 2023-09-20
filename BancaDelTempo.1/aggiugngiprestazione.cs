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
            float ore = Convert.ToInt32(textBox3.Text);

        }
    }
}
