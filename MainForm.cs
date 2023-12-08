using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagiPlay
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblInstru.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string resultadoDigitado = txtResult.Text;
            if (int.TryParse(resultadoDigitado, out int resultadoFinal))
            {
                // Lógica correspondente: dividir por 2, multiplicar por 4, somar 12 e subtrair 6
                int numeroPensado = (((resultadoFinal + 6) - 12) / 4) * 2;

                MessageBox.Show($"O número que você pensou inicialmente é: {numeroPensado}.", "Resultado");
            }
            else
            {
                MessageBox.Show("Por favor, digite um número válido.", "Erro");
            }
        }

        private void txtResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Ignora caracteres não numéricos
            }
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtResult.Text, out int numeroDigitado))
            {
                txtResult.Text = "";  // Limpa o texto se não for um número inteiro
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Criar uma instância do formulário PalavraMisteriosaForm
            PalavraMisteriosaForm palavraMisteriosaForm = new PalavraMisteriosaForm();

            // Mostrar o formulário
            palavraMisteriosaForm.Show();
        }
    }
}
