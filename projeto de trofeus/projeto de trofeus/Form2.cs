using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_de_trofeus
{
    public partial class Form2 : Form
    {
        public string Nick { get; set; } = "";     
        private class Inner
        {
            public List<string> ListaDeJogadores = new List<string>();
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (textBox1.Text == "" || textBox1.Text == "Digite seu nick") // Validação para garantir que o nome do jogador não esteja vazio
            {
                MessageBox.Show("Por favor, insira o nome do jogador.");
                return;
            } else {
                Inner inner = new Inner();
                inner.ListaDeJogadores.Add(textBox1.Text);
                Nick = textBox1.Text;
                Form3 Form3 = new Form3(Nick);
                Form3.Show();
                this.Hide();
            }            
        }

        public static implicit operator Form2(Form4 v)
        {
            throw new NotImplementedException();
        }
    }
}
