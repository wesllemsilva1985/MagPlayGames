using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MagiPlay
{
    public partial class PalavraMisteriosaForm : Form
    {
        private List<string> palavrasBase = new List<string>
        {
            "amor", "felicidade", "alegria", "esperança", "liberdade",
            "sabedoria", "paz", "natureza", "harmonia", "criatividade",
            "viajar", "aventura", "descoberta", "sorriso", "solidariedade",
            "gentileza", "amizade", "respeito", "justiça", "generosidade",
            "equilíbrio", "conhecimento", "curiosidade", "energia", "saúde",
            "inspiração", "tranquilidade", "humildade", "gratidão", "resiliência",
            "cultura", "diversidade", "fé", "paciência", "otimismo",
            "cumplicidade", "compaixão", "integridade", "tolerância", "sustentabilidade",
            "sucesso", "realização", "motivação", "cooperação", "compreensão",
            "alegria", "criança", "juventude", "maturidade", "velhice"
        };

        private string palavraSorteada;
        private List<string> palavrasTentadas = new List<string>(); // Lista de palavras tentadas
        private int totalLetrasPrimeiraRodada; // Total de letras informado na primeira rodada
        private char letraRevelada; // Letra revelada
        private bool aguardarLetras; // Flag para aguardar a informação do total de letras
        private bool aguardarProximaRodada; // Flag para aguardar a próxima rodada

        public PalavraMisteriosaForm()
        {
            InitializeComponent();
            aguardarLetras = true;
            aguardarProximaRodada = false;
            InicializarJogo();
        }

        private void InicializarJogo()
        {
            // Código para inicializar o jogo
            SortearEAtualizarPalavra();
        }

        private void buttonRevelarPalavra_Click(object sender, EventArgs e)
        {
            if (aguardarLetras)
            {
                string palavraInformada = textBoxPalavraInformada.Text;
                TentarAdivinharPalavra(palavraInformada);
            }
            else if (aguardarProximaRodada)
            {
                buttonRevelarPalavra.Enabled = true;
                buttonRevelarLetra.Enabled = true;
                MessageBox.Show($"Clique no botão 'Revelar Letra' para continuar.", "Aguardando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tmrTeste_Tick(object sender, EventArgs e)
        {
            SortearEAtualizarPalavra();
        }

        private void SortearEAtualizarPalavra()
        {
            tmrTeste.Enabled = false;
            palavrasBase = palavrasBase.OrderBy(x => Guid.NewGuid()).ToList();
            palavraSorteada = palavrasBase[0];
            lblPalavraSorteada.Text = palavraSorteada;
            Invalidate();
            AguardarLetras();
        }

        private void AguardarLetras()
        {
            aguardarLetras = true;
            aguardarProximaRodada = false;
            textBoxPalavraInformada.Enabled = true;
            buttonRevelarPalavra.Enabled = true;
            buttonRevelarLetra.Enabled = false;
            MessageBox.Show("Informe o número de letras na palavra e clique em 'Revelar Palavra'.", "Aguardando", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AguardarProximaRodada()
        {
            aguardarLetras = false;
            aguardarProximaRodada = true;
            textBoxPalavraInformada.Enabled = false;
            buttonRevelarPalavra.Enabled = false;
            buttonRevelarLetra.Enabled = true;
            MessageBox.Show($"Clique no botão 'Revelar Letra' para continuar.", "Aguardando", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TentarAdivinharPalavra(string palavraInformada)
        {
            if (int.TryParse(palavraInformada, out totalLetrasPrimeiraRodada))
            {
                List<string> palavrasPossiveis = palavrasBase
                    .Where(palavra => palavra.Length == totalLetrasPrimeiraRodada && !palavrasTentadas.Contains(palavra))
                    .ToList();

                if (palavrasPossiveis.Count > 0)
                {
                    Random random = new Random();
                    string palavraChutada = palavrasPossiveis[random.Next(palavrasPossiveis.Count)];

                    palavrasTentadas.Add(palavraChutada);

                    DialogResult resultado = MessageBox.Show($"A palavra é {palavraChutada}?", "Adivinhar Palavra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        ResponderSim();
                    }
                    else
                    {
                        letraRevelada = SolicitarLetraRevelada();
                        AguardarProximaRodada();
                    }
                }
                else
                {
                    MessageBox.Show("Não há mais palavras possíveis com a quantidade de letras informada.", "Fim de Jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, informe um número válido de letras.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResponderSim()
        {
            MessageBox.Show("Obaaa!!! Acertei a palavra.", "Vitória", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReiniciarJogo();
        }

        private char SolicitarLetraRevelada()
        {
            Random random = new Random();
            int indiceLetraRevelada = random.Next(totalLetrasPrimeiraRodada);
            return palavraSorteada[indiceLetraRevelada];
        }

        private void buttonRevelarLetra_Click(object sender, EventArgs e)
        {
            if (aguardarProximaRodada)
            {
                ProximaRodada();
            }
        }

        private void ProximaRodada()
        {
            if (char.TryParse(textBoxPalavraInformada.Text, out letraRevelada))
            {
                palavraSorteada = SubstituirInterrogacaoPorLetra(palavraSorteada, letraRevelada);
                lblPalavraSorteada.Text = palavraSorteada;

                if (!palavraSorteada.Contains("?"))
                {
                    MessageBox.Show("Obaaa!!! Acertei a palavra.", "Vitória", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReiniciarJogo();
                }
                else
                {
                    AguardarProximaRodada();
                }
            }
            else
            {
                MessageBox.Show("Por favor, informe uma letra válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SubstituirInterrogacaoPorLetra(string palavra, char letra)
        {
            char[] palavraArray = palavra.ToCharArray();
            int indiceInterrogacao = Array.IndexOf(palavraArray, '?');
            palavraArray[indiceInterrogacao] = letra;
            return new string(palavraArray);
        }

        private void ReiniciarJogo()
        {
            palavrasTentadas.Clear();
            tmrTeste.Enabled = true;
            SortearEAtualizarPalavra();
        }
    }
}
