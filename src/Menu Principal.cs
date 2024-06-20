using System.Data;

namespace Projeto2Ano
{
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

        private void btnBank_Click(object sender, EventArgs e)
        {
            Hide();
            BancoInicial bancoInicial = new BancoInicial();
            bancoInicial.Closed += (s, args) => Show();
            bancoInicial.ShowDialog();
        }

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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}