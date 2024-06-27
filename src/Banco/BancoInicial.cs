using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form dá ao utilizador a opção de criar conta caso não tenha e de entrar na conta se tiver e ao administrador a opção de gerir as contas
    /// </summary>
    public partial class BancoInicial : Form
    {
        private bool HasAccount = false;
        public BancoInicial()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
            BtnTexts();
        }
        /// <summary>
        /// Define o texto de <see cref="btnContinue"/> dependendo se for administrador ou utilizador e se tem conta ou não
        /// </summary>
        private void BtnTexts()
        {
            if (Program.adminMode)
            {
                btnContinue.Text = "Gerir Contas";
            }
            else
            {
                HasAccount = Program.VerifyBankAccount();
                if (HasAccount)
                {
                    btnContinue.Text = "Entrar na Conta";
                }
                else
                {
                    btnContinue.Text = "Criar Conta";
                }
            }
            Refresh();
        }
        /// <summary>
        /// Abre o form correspondente dependendo se for administrador ou utilizador e se tem conta ou não
        /// <list type="bullet">
        /// <item>Se for administrador: <see cref="BancoAdmin"/></item>
        /// <item>Se não tiver conta: <see cref="BancoPIN"/> em modo de Criação de Conta</item>
        /// <item>Se tiver conta: <see cref="BancoConfirmar"/> em modo de inicio de sessão</item>
        /// </list>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (Program.adminMode)
            {
                Hide();
                BancoAdmin bancoAdmin = new BancoAdmin();
                bancoAdmin.Closed += (s, args) => Show();
                bancoAdmin.ShowDialog();
            }
            else
            {
                if (HasAccount)
                {
                    Hide();
                    BancoConfirmar bancoEntrar = new BancoConfirmar(true);
                    bancoEntrar.Closed += (s, args) => {
                        BtnTexts();
                        Show(); 
                    };
                    bancoEntrar.ShowDialog();
                }
                else
                {
                    Hide();
                    BancoPIN bancoCriar = new BancoPIN(true);
                    bancoCriar.Closed += (s, args) => {
                        BtnTexts();
                        
                        Show(); 
                    };
                    bancoCriar.ShowDialog();
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
