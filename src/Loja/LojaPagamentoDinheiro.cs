using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este Form permite ao utilizador inserir a quantia a pagar em "Dinheiro"
    /// </summary>
    public partial class LojaPagamentoDinheiro : Form
    {
        public LojaPagamentoDinheiro()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
        }


        /// <summary>
        /// Caso o utilizador não insira uma quantia é pago o preço total, caso contrário é usado o valor inserido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption_Click(object sender, EventArgs e)
        {
            if (tbxQuantia.Text.Length == 0)
            {
                Program.loja.paidQuantityMoney = Program.loja.totalPrice;
                MessageBox.Show("Quantia paga com sucesso!\n", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else if (tbxQuantia.Text.Length != 0 && double.Parse(tbxQuantia.Text) != 0)
            {
                Program.loja.paidQuantityMoney += double.Parse(tbxQuantia.Text);
                MessageBox.Show("Quantia paga com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        /// <summary>
        /// Apenas permite inserir números com duas casas decimais na <see cref="tbxQuantia"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxQuantia_TextChanged(object sender, EventArgs e)
        {
            string text = tbxQuantia.Text;
            if (tbxQuantia.Text.Length != 0)
            {
                btnOption.Enabled = true;
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
        /// <inheritdoc cref="tbxQuantia_TextChanged"/>
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




