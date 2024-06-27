using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form é o menu principal do banco, nele o utilizador ver o seu saldo atual e selecionar a operação que deseja efetuar 
    /// </summary>
    public partial class BancoPrincipal : Form
    {
        public BancoPrincipal()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            lblTitle.Text = $"Bem Vindo {Program.user.Name}\nSelecione uma operação:\n";
            Program.GetSaldo(Program.user.ID);
            lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
        }

        /// <summary>
        /// Abre <see cref="BancoOpIO"/> no modo depósito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Hide();
            BancoOpIO bancoOpIO = new BancoOpIO(true,false);
            bancoOpIO.Closed += (s, args) => 
            {
                Program.GetSaldo(Program.user.ID);
                lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€"; 
                Show(); 
            };
            bancoOpIO.ShowDialog();
        }
        /// <summary>
        /// Abre <see cref="BancoOpIO"/> no modo levantamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Hide();
            BancoOpIO bancoOpIO = new BancoOpIO(false,false);
            bancoOpIO.Closed += (s, args) =>
            {
                Program.GetSaldo(Program.user.ID);
                lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
                Show();
            };
            bancoOpIO.ShowDialog();
        }
        /// <summary>
        /// Abre <see cref="BancoTransferencia"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Hide();
            BancoTransferencia bancoTransferencia = new BancoTransferencia();
            bancoTransferencia.Closed += (s, args) =>
            {
                Program.GetSaldo(Program.user.ID);
                lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
                Show();
            };
            bancoTransferencia.ShowDialog();
        }

        /// <summary>
        /// Abre <see cref="BancoTransacoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransactions_Click(object sender, EventArgs e)
        {
            Hide();
            BancoTransacoes bancoTransacoes = new BancoTransacoes();
            bancoTransacoes.Closed += (s, args) => Show();
            bancoTransacoes.ShowDialog();
        }

        /// <summary>
        /// Abre <see cref="BancoPIN"/> no modo de alteração de PIN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterarPin_Click(object sender, EventArgs e)
        {
            Hide();
            BancoPIN bancoPIN = new BancoPIN(false);
            bancoPIN.ShowDialog();
            if(bancoPIN.DialogResult == DialogResult.Abort) 
            {
                Close();
            }
            else
            {
                Show();
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
