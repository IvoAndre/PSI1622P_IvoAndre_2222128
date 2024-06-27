using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Menu Principal do Programa: O utilizador pode ir às <see cref="Definicoes"/>, <see cref="ContaDefinicoes"/>, <see cref="BancoInicial"/> e <see cref="LojaPrincipal"/>
    /// </summary>
    public partial class MenuPrincipal : Form
    {

        public MenuPrincipal()
        {
            InitializeComponent();
            lblTitle.Text = $"Bem Vindo {Program.user.Name}\nSelecione um local:\n";
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
        }
        /// <summary>
        /// Abre <see cref="Definicoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDefinicoes_Click(object sender, EventArgs e)
        {
            Hide();
            Definicoes definicoes = new Definicoes();
            definicoes.Closed += (s, args) =>
            {
                Program.DetectTheme(this);
                Show();
            };
            definicoes.ShowDialog();
        }

        /// <summary>
        /// Abre <see cref="ContaDefinicoes"/> se for utilizador<br/>
        /// Abre <see cref="ContaDefinicoesAdmin"/> se <see cref="Program.adminMode"/> = true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuConta_Click(object sender, EventArgs e)
        {
            if (Program.adminMode)
            {
                if (Program.VerifyUsers())
                {
                    Hide();
                    ContaDefinicoesAdmin contaDefinicoesAdmin = new ContaDefinicoesAdmin();
                    contaDefinicoesAdmin.Closed += (s, args) => Show();
                    contaDefinicoesAdmin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Não existem contas para gerir!","Informação",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                Hide();
                ContaDefinicoes contaDefinicoes = new ContaDefinicoes();
                contaDefinicoes.ShowDialog();
                if (contaDefinicoes.DialogResult == DialogResult.OK)
                {
                    lblTitle.Text = $"Bem Vindo {Program.user.Name}\nSelecione um local:\n";
                    Show();
                }
                else if (contaDefinicoes.DialogResult == DialogResult.Abort)
                {
                    Close();
                }
            }
        }

        /// <summary>
        /// Abre <see cref="BancoInicial"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBank_Click(object sender, EventArgs e)
        {
            Hide();
            BancoInicial bancoInicial = new BancoInicial();
            bancoInicial.Closed += (s, args) => Show();
            bancoInicial.ShowDialog();
        }

        /// <summary>
        /// Abre <see cref="LojaPrincipal"/> se for utilizador<br/>
        /// Abre <see cref="LojaAdmin"/> se <see cref="Program.adminMode"/> = true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShop_Click(object sender, EventArgs e)
        {
            Hide();
            if (Program.adminMode)
            {
                LojaAdmin lojaAdmin = new LojaAdmin();
                lojaAdmin.FormClosed += (s, args) => Show();
                lojaAdmin.ShowDialog();
            }
            else
            {
                try
                {
                    LojaPrincipal lojaPrincipal = new LojaPrincipal();
                    lojaPrincipal.Closed += (s, args) => Show();
                    lojaPrincipal.ShowDialog();
                }
                catch (Exception ex)
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}