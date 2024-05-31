using System.Configuration;
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
                    MessageBox.Show("N�o existem contas para gerir!","Informa��o",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                Hide();
                ContaDefinicoes contaDefinicoes = new ContaDefinicoes();
                contaDefinicoes.ShowDialog();
                if (contaDefinicoes.DialogResult == DialogResult.OK)
                {
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
            ContaCriar contaCriar = new ContaCriar();
            contaCriar.Closed += (s, args) => Show();
            contaCriar.ShowDialog();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            Hide();
            ContaEntrar contaEntrar = new ContaEntrar();
            contaEntrar.Closed += (s, args) => Show();
            contaEntrar.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}