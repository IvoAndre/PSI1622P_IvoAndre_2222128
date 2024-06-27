namespace Projeto2Ano
{
    /// <summary>
    /// Este Form mostra uma barra de loading durante 5 segundos e abre <see cref="MenuPrincipal"/>
    /// </summary>
    public partial class Loading : Form
    {

        public Loading()
        {
            InitializeComponent();
            ClientSize = new Size(320, 45);
            Program.DetectTheme(this);
        }
        private int pBarIncrease = 0;
        /// <summary>
        /// Recebe as teclas Shift+S para pular o loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Loading_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                pBarIncrease = 5;
                pBar.Value = pBar.Maximum;
            }
        }


        /// <summary>
        /// A cada tick do <see cref="Timer"/> (1 segundo) esta função é executada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pBar.Maximum - pBar.Value > 20 )
            {
                // Avança a ProgressBar
                pBar.PerformStep();
            }
            else if (pBarIncrease < 5)
            {
                pBar.Maximum += 20;
                pBar.Value += 20;
                // Aumenta o tamanho da ProgressBar e do Form
                this.Width += 20;
                this.Left -= 10;
                pBar.Width += 20;
                pBarIncrease++;
            }
            else
            {
                pBar.Width = 300;
                this.Width = 322;
                // Para o Timer quando a ProgressBar atinge o máximo
                Timer.Stop();
            }

            if (!Timer.Enabled)
            {
                Hide();
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.Closed += (s, args) => Close();
                menuPrincipal.ShowDialog();
            }
        }
    }
}