using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_de_trofeus
{
    public partial class Form3 : Form
    {
        private string _nick;

        public Form3(string nick)
        {
            InitializeComponent();
            _nick = nick;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string qtdTrofeusSTR = textBox1.Text.Trim();
            int qtdTrofeus;

            if (textBox1.Text == "" || textBox1.Text == "Digite aqui")
            {
                MessageBox.Show("Digite o valor dos trofeus");

                return;
            }
            else if (!int.TryParse(qtdTrofeusSTR, out qtdTrofeus))
            {
                MessageBox.Show("Valor inválido para troféus. Digite apenas números!",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (qtdTrofeus <= 8000)
                {
                    Form5 form = new Form5();
                    form.Show();
                    this.Close();
                }
                else 
                { 
                    Form4 form = new Form4();
                    form.Show();
                    this.Close();

                }
            }
        }
      
    }
}
