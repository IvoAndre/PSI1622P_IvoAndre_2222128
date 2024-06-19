using System.Data;

namespace Projeto2Ano
{
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

        

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Hide();
            BancoOpIO bancoOpIO = new BancoOpIO(true,false);
            bancoOpIO.Closed += (s, args) => 
            { 
                lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€"; 
                Show(); 
            };
            bancoOpIO.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Hide();
            BancoOpIO bancoOpIO = new BancoOpIO(false,false);
            bancoOpIO.Closed += (s, args) =>
            {
                lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
                Show();
            };
            bancoOpIO.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Hide();
            BancoTransferencia bancoTransferencia = new BancoTransferencia();
            bancoTransferencia.Closed += (s, args) =>
            {
                lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
                Show();
            };
            bancoTransferencia.ShowDialog();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            Hide();
            BancoTransacoes bancoTransacoes = new BancoTransacoes();
            bancoTransacoes.Closed += (s, args) => Show();
            bancoTransacoes.ShowDialog();
        }

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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
