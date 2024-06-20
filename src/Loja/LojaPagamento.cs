using System.Data;

namespace Projeto2Ano
{
    public partial class LojaPagamento : Form
    {
        public LojaPagamento()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

            if(Program.VerifyBankAccount())
            {
                btnPayBank.Enabled = true;
            }
            else
            {
                btnPayBank.Enabled = false;
            }
            VerifyPayment();

        }

        private void VerifyPayment()
        {
            if (Program.loja.paidQuantityMoney + Program.loja.paidQuantityBank == 0)
            {
                lblTotal.Text = $"Total a Pagar:\n{Program.UpdateTotal().ToString("0.00")}€";
            }
            else
            {
                lblTotal.Text = $"Restante a Pagar: {Program.UpdateTotal().ToString("0.00")}€ \nTotal Pago: {Program.loja.paidQuantityMoney + Program.loja.paidQuantityBank}€";
            }
            if (Program.UpdateTotal() == 0)
            {
                MessageBox.Show("Obrigado por utilizar a loja!\nVolte Sempre!", "Conclusão da Compra", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else if (Program.UpdateTotal() < 0)
            {
                MessageBox.Show($"Obrigado por utilizar a loja!\nVolte Sempre!\n\nTroco Recebido: {(Program.UpdateTotal() * -1).ToString("0.00")}", "Conclusão da Compra", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnPayBank_Click(object sender, EventArgs e)
        {
            BancoOpIO bancoOpIO = new BancoOpIO(false, true);
            bancoOpIO.Closed += (s, args) =>
            {
                VerifyPayment();
            };
            bancoOpIO.ShowDialog();
        }

        private void btnPayMoney_Click(object sender, EventArgs e)
        {
            LojaPagamentoDinheiro lojaPagamentoDinheiro = new LojaPagamentoDinheiro();
            lojaPagamentoDinheiro.Closed += (s, args) =>
            {
                VerifyPayment();
                Show();
            };
            lojaPagamentoDinheiro.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.loja.paidQuantityBank + Program.loja.paidQuantityMoney > 0)
            {
                DialogResult dialogresult = MessageBox.Show("Tem a certeza que deseja cancelar o pagamento?\nA quantia que pagou lhe será retornada.", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogresult == DialogResult.Yes)
                {
                    if(Program.loja.paidQuantityBank > 0)
                    {
                        Program.AdicionarFundos(Program.user.ID, "Cancelamento do pagamento na Loja LLC", Program.loja.paidQuantityBank);
                    }
                    MessageBox.Show($"Quantia retornada: {Program.loja.paidQuantityBank + Program.loja.paidQuantityMoney}","Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
    }
}
