using System.Configuration;

namespace Projeto2Ano
{
    public partial class Loading : Form
    {


        public Loading()
        {
            InitializeComponent();
            Program.DetectTheme(this);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pBar.Value < pBar.Maximum)
            {
                // Atualiza a ProgressBar
                pBar.Value += 10;

                // Aumenta o tamanho da ProgressBar e do Form
                this.Width += 10;
                this.Height += 10;
                pBar.Width += (int)(pBar.Width * 0.25);
            }
            else
            {
                // Para o Timer quando a ProgressBar atinge o máximo
                Timer.Stop();
            }
        }
    }
}