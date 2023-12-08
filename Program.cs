using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagiPlay
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar o formulário de splash
            //SplashForm splashForm = new SplashForm();
           // splashForm.ShowDialog();

            // Agora, mostrar o formulário principal ou o formulário do jogo
            Application.Run(new PalavraMisteriosaForm());
        }
    }
}
