using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;

namespace MagiPlay
{
    public partial class SplashForm : Form
    {
        private Timer splashTimer;
        private PictureBox splashPictureBox;

        public SplashForm()
        {
            InitializeComponent();
            ConfigureSplashForm();
        }

        private void ConfigureSplashForm()
        {
            // Configurar propriedades do formulário
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(255, 255, 255); // Substitua pela cor desejada
            TransparencyKey = BackColor;
            TopMost = true;

            // Configurar o PictureBox
            splashPictureBox = new PictureBox();
            splashPictureBox.Image = Properties.Resources.SplashImage; // Substitua "SplashImage" pelo nome correto da sua imagem nos recursos
            splashPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            splashPictureBox.Dock = DockStyle.Fill; // Preencher todo o formulário

            // Adicionar PictureBox ao formulário
            Controls.Add(splashPictureBox);

            // Referenciar o ProgressBar criado no design
            pbSplash = this.Controls.Find("pbSplash", true).FirstOrDefault() as ProgressBar;

            // Configurar o ProgressBar para um estilo mais moderno
            pbSplash.Style = ProgressBarStyle.Continuous;

            // Configurar o temporizador
            splashTimer = new Timer();
            splashTimer.Interval = 50; // Tempo em milissegundos (ajuste conforme necessário)
            splashTimer.Tick += Timer_Tick;

            // Iniciar o temporizador
            splashTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Atualizar o valor do ProgressBar de forma suave
            pbSplash.Value = (pbSplash.Value + 1) % (pbSplash.Maximum + 1);

            // Se o carregamento estiver concluído, feche o formulário de splash
            if (pbSplash.Value == pbSplash.Maximum)
            {
                splashTimer.Stop();
                this.Close();
            }
        }
        // Sobrescrever o método OnPaint para desenhar o ProgressBar com um gradiente
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle progressBarRect = new Rectangle(pbSplash.Left, pbSplash.Top, pbSplash.Width, pbSplash.Height);

            // Desenhar o ProgressBar com um gradiente
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, progressBarRect);
            progressBarRect.Width = (int)(progressBarRect.Width * ((double)pbSplash.Value / pbSplash.Maximum));
            ProgressBarRenderer.DrawHorizontalChunks(e.Graphics, progressBarRect);
        }
    }
}
