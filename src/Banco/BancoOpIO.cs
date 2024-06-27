using System.Data;


namespace Projeto2Ano
{
    /// <summary>
    /// Este form tem três modos:
    /// <list type="number">
    /// <item>Depósito</item>
    /// <item>Levantamento</item>
    /// <item>Pagamento</item>
    /// </list>
    /// </summary>
    public partial class BancoOpIO : Form
    {
        private bool AddMode;
        private bool IsPayment;
        public BancoOpIO(bool addMode, bool isPayment)
        {
            InitializeComponent();
            Program.DetectTheme(this);
            AddMode = addMode;
            IsPayment = isPayment;
            Program.GetSaldo(Program.user.ID);
            lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
            if (AddMode)
            {
                lblTitle.Text = "Depósito de Fundos";
                lbltbxQuantia.Text = "Quantia a Depositar*:";
            }
            else if (!IsPayment) 
            {
                lblTitle.Text = "Levantamento de Fundos";
                lbltbxQuantia.Text = "Quantia a Levantar*:";
            }
            else
            {
                btnOption.Enabled = true;
                lblTitle.Text = "Pagamento";
                lbltbxQuantia.Text = "Quantia a Pagar*:\n(Clique em Confirmar sem inserir um valor para pagar a quantia total.)";
            }

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
            IsPayment = isPayment;
        }


        /// <summary>
        /// Executa a operação dependendo do modo do form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption_Click(object sender, EventArgs e)
        {
            if (AddMode)
            {
                if (double.Parse(tbxQuantia.Text) <= 10000)
                {
                    if (Program.AdicionarFundos(Program.user.ID, "Depósito de Fundos", double.Parse(tbxQuantia.Text)) == DialogResult.OK)
                    {
                        MessageBox.Show("Depósito efetuado com sucesso!\nOs fundos aparecerão brevemente na sua conta.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Depósito não efetuado!\nA quantia a depositar não pode exceder os 10000€ (dez mil euros)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (!IsPayment && double.Parse(tbxQuantia.Text) != 0)
            {
                if (Program.RemoverFundos(Program.user.ID, "Levantamento de Fundos", double.Parse(tbxQuantia.Text), false) == DialogResult.OK)
                {
                    MessageBox.Show("Levantamento efetuado com sucesso!\nA transação deverá aparecer na sua conta brevemente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Levantamento não efetuado!\nA quantia a levantar não pode exceder o saldo da sua conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(IsPayment && tbxQuantia.Text.Length == 0)
            {
                BancoConfirmar confirmar = new BancoConfirmar(false);
                confirmar.Closed += (s, args) => Show();
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Continue)
                {
                    if (Program.RemoverFundos(Program.user.ID, "Pagamento a Loja LLC.", Program.UpdateTotal(), false) == DialogResult.OK)
                    {
                        Program.loja.paidQuantityBank = Program.loja.totalPrice;
                        MessageBox.Show("Pagamento efetuado com sucesso!\nA transação deverá aparecer na sua conta brevemente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Pagamento não efetuado!\nA quantia a pagar não pode exceder o saldo da sua conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (IsPayment && tbxQuantia.Text.Length != 0 && double.Parse(tbxQuantia.Text) != 0)
            {
                BancoConfirmar confirmar = new BancoConfirmar(false);
                confirmar.Closed += (s, args) => Show();
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Continue)
                {
                    if (Program.RemoverFundos(Program.user.ID, "Pagamento a Loja LLC.", double.Parse(tbxQuantia.Text), false) == DialogResult.OK)
                    {
                        Program.loja.paidQuantityBank += double.Parse(tbxQuantia.Text);
                        MessageBox.Show("Pagamento efetuado com sucesso!\nA transação deverá aparecer na sua conta brevemente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Pagamento não efetuado!\nA quantia a levantar não pode exceder o saldo da sua conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira uma quantia a Levantar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
        }
        /// <summary>
        /// Verifica se <see cref="tbxQuantia"/> cumpre os requisitos e limita o texto a duas casas decimais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxQuantia_TextChanged(object sender, EventArgs e)
        {
            string text = tbxQuantia.Text;
            if (tbxQuantia.Text.Length != 0 && double.Parse(tbxQuantia.Text) != 0)
            {
                btnOption.Enabled = true;
            }
            else if (IsPayment)
            {
                btnOption.Enabled = true;
            }
            else
            {
                btnOption.Enabled = false;
            }

            if (text.Contains(","))
            {

                string[] parts = text.Split(',');


                if (parts.Length > 1 && parts[1].Length > 2)
                {
                    tbxQuantia.Text = parts[0] + "," + parts[1].Substring(0, 2);
                    tbxQuantia.SelectionStart = tbxQuantia.Text.Length;
                }


                if (parts.Length > 2)
                {
                    tbxQuantia.Text = parts[0] + "," + parts[1];
                    tbxQuantia.SelectionStart = tbxQuantia.Text.Length;
                }
            }
        }
        /// <summary>
        /// Limita os caracteres recebidos por <see cref="tbxQuantia"/> apenas a números e vírgulas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxQuantia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsControl(e.KeyChar))
            {
                return;
            }


            if (char.IsDigit(e.KeyChar))
            {
                return;
            }


            if (e.KeyChar == ',' && !tbxQuantia.Text.Contains(","))
            {
                return;
            }


            e.Handled = true;
        }
        /// <summary>
        /// Fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}




