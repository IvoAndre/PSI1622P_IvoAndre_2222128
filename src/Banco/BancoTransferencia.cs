using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form permite ao utilizador transferir fundos para outras contas bancárias
    /// </summary>
    public partial class BancoTransferencia : Form
    {
        private string userIBAN;
        public BancoTransferencia()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            Program.GetSaldo(Program.user.ID);
            lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
            
            using (SqlCommand cmd = new SqlCommand("SELECT IBAN FROM bank_accounts WHERE userid = @userid", Program.db))
            {
                cmd.Parameters.AddWithValue("@userid", Program.user.ID);
                userIBAN = (string)cmd.ExecuteScalar();
            }

            string query = @"
            SELECT u.name AS 'Nome do Titular', b.IBAN AS 'IBAN'
            FROM users u
            JOIN bank_accounts b ON u.id = b.userid";

            Program.da = new SqlDataAdapter(query, Program.db);
            DataTable dt = new DataTable();
            Program.da.Fill(dt);
            //Remover a linha com o IBAN do utilizador atual
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dt.Rows[i];
                if (row["IBAN"].ToString() == userIBAN)
                {
                    dt.Rows.Remove(row);
                    break;
                }
            }
            //Formatar todos os IBANs para melhor visibilidade do utilizador
            foreach (DataRow row in dt.Rows)
            {
                row["IBAN"] = Program.FormatIBAN(row["IBAN"].ToString());
            }
            
            dgTransferencias.DataSource = dt;
        }
        /// <summary>
        /// Efetua a transferência se o IBAN indicado for válido e o utilizador tiver saldo suficiente na conta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption_Click(object sender, EventArgs e)
        {
            string destIBAN = tbxIBAN.Text;
            tbxIBAN.Text = Program.FormatIBAN(destIBAN);
            int destID = 0;
            bool hasRows=false;
            using (SqlCommand cmd = new SqlCommand("SELECT userid FROM bank_accounts WHERE IBAN = @IBAN", Program.db))
            {
                cmd.Parameters.AddWithValue("@IBAN", destIBAN.Replace(" ", ""));
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        hasRows = true;
                        if (dr.Read())
                        {
                            destID = (int)dr["userid"];
                        }
                    }
                    else
                    {
                        destID = Program.user.ID;
                        MessageBox.Show("Transferência não efetuada!\nO IBAN destinatário é inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                    
            }


            if (Program.user.ID != destID && hasRows)
            {
                if (Program.RemoverFundos(Program.user.ID, $"Transferência de fundos para {Program.FormatIBAN(destIBAN)}", double.Parse(tbxQuantia.Text), false) == DialogResult.OK)
                {
                    if (Program.AdicionarFundos(destID, $"Transferência de fundos de {Program.FormatIBAN(userIBAN)}", double.Parse(tbxQuantia.Text)) == DialogResult.OK)
                    {
                        MessageBox.Show("Transferência efetuada com sucesso!\nA transação deverá aparecer na sua conta brevemente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program.AdicionarFundos(Program.user.ID, $"Transferência de fundos para {Program.FormatIBAN(destIBAN)} não sucedida.", double.Parse(tbxQuantia.Text));
                        MessageBox.Show("Transferência não efetuada!\nA quantia a transferir não foi retirada da sua conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Close();
                }
                else
                {
                    if(double.Parse(tbxQuantia.Text)<=0)
                    MessageBox.Show("Transferência não efetuada!\nA quantia a transferir deve ser superior a zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    MessageBox.Show("Transferência não efetuada!\nA quantia a transferir não pode exceder o saldo da sua conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";
            }
            else
            {
                if (hasRows)
                    MessageBox.Show("Transferência não efetuada!\nO IBAN destinatário não pode ser o mesmo da sua conta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Verifica se existe conteúdo na textbox e ativa o <see cref="btnOption"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxQuantia_TextChanged(object sender, EventArgs e)
        {
            string text = tbxQuantia.Text;
            if (tbxQuantia.Text.Length != 0 && tbxIBAN.Text.Length == tbxIBAN.MaxLength)
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
        /// Limita os caracteres recebidos pela <see cref="tbxQuantia"/>
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
        /// Verifica se existe conteúdo na textbox e formata o conteúdo para melhor legibilidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxIBAN_TextChanged(object sender, EventArgs e)
        {
            if (tbxQuantia.Text.Length != 0 && tbxIBAN.Text.Length == tbxIBAN.MaxLength)
            {
                btnOption.Enabled = true;
            }

            string originalText = tbxIBAN.Text.Replace(" ", "");
            tbxIBAN.Text = Program.FormatIBAN(originalText);
            tbxIBAN.SelectionStart = tbxIBAN.Text.Length;
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



