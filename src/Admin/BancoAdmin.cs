using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form é exclusivo ao administrador e permite ver e alterar os dados das contas bancárias
    /// </summary>
    public partial class BancoAdmin : Form
    {
        private DataTable dtTransacoes;

        public BancoAdmin()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

            LoadUsernames();
        }
        /// <summary>
        /// Carrega os nomes de utilizador com conta bancária em <see cref="cbxContaSel"/>
        /// </summary>
        private void LoadUsernames()
        {
            Program.dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = Program.db;
                    cmd.CommandText = "SELECT u.username, u.id FROM [users] u INNER JOIN [bank_accounts] b ON u.id = b.userid";
                    Program.da = new SqlDataAdapter(cmd);
                    Program.da.Fill(Program.dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DataRow newRow = Program.dt.NewRow();
            newRow["username"] = "Nenhuma Conta Selecionada";
            Program.dt.Rows.InsertAt(newRow, 0);

            cbxContaSel.DisplayMember = "username";
            cbxContaSel.ValueMember = "id"; // Change to ID to use for filtering
            cbxContaSel.DataSource = Program.dt;
            cbxContaSel.SelectedIndex = 0;
        }
        /// <summary>
        /// Carrega as transações em <see cref="dgTransacoes"/>
        /// </summary>
        /// <param name="userId"></param>
        private void LoadTransactions(int userId)
        {
            dtTransacoes = new DataTable();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = Program.db;
                    cmd.CommandText = @"
                    SELECT 
                        id AS 'ID Transação',
                        userid AS 'ID Utilizador',
                        time AS 'Data e Hora', 
                        description AS 'Descritivo', 
                        variation AS 'Variação', 
                        finalbalance AS 'Saldo Final'
                    FROM bank_transactions
                    WHERE userid = @userid
                    ORDER BY time ASC";
                    cmd.Parameters.AddWithValue("@userid", userId);
                    Program.da = new SqlDataAdapter(cmd);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(Program.da);
                    Program.da.Fill(dtTransacoes);
                    dgTransacoes.DataSource = dtTransacoes;


                    dgTransacoes.Columns["ID Transação"].Visible = false;
                    dgTransacoes.Columns["ID Utilizador"].Visible = false;
                    dgTransacoes.Columns["Data e Hora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgTransacoes.Columns["Descritivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgTransacoes.Columns["Variação"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgTransacoes.Columns["Saldo Final"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Mostra as informações da conta selecionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxContaSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxContaSel.SelectedIndex > 0)
            {
                int userId = Convert.ToInt32(cbxContaSel.SelectedValue);
                LoadTransactions(userId);
                pDefinicoes.Visible = true;
            }
            else
            {
                dgTransacoes.DataSource = null;
                pDefinicoes.Visible = false;
            }
        }
        /// <summary>
        /// Guarda as alterações da <see cref="dgTransacoes"/> na base de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
            confirmar.Closed += (s, args) => Show();
            confirmar.ShowDialog();
            if (confirmar.DialogResult == DialogResult.Continue)
            {
                try
                {
                    Program.da.Update(dtTransacoes);
                    MessageBox.Show("Transações atualizadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int userId = Convert.ToInt32(cbxContaSel.SelectedValue);
                    LoadTransactions(userId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Apaga a transação selecionada em <see cref="dgTransacoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgTransacoes.SelectedRows)
            {
                dgTransacoes.Rows.Remove(row);
            }
        }
        /// <summary>
        /// Insere uma nova transação em <see cref="dgTransacoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertTransaction_Click(object sender, EventArgs e)
        {
            if (cbxContaSel.SelectedIndex > 0)
            {
                DataRow newRow = dtTransacoes.NewRow();
                newRow["ID Utilizador"] = Convert.ToInt32(cbxContaSel.SelectedValue);
                dtTransacoes.Rows.Add(newRow);
            }
        }
        /// <summary>
        /// Altera o PIN da conta selecionada em <see cref="cbxContaSel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterarPIN_Click(object sender, EventArgs e)
        {
            if (cbxContaSel.SelectedIndex > 0)
            {
                ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
                confirmar.Closed += (s, args) => Show();
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Continue)
                {
                    int userId = Convert.ToInt32(cbxContaSel.SelectedValue);
                    string newPIN = Crypt.Hash(tbxPIN.Text);

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                            cmd.Connection = Program.db;
                            cmd.CommandText = "UPDATE [bank_accounts] SET pin = @pin WHERE userid = @userid";
                            cmd.Parameters.AddWithValue("@pin", newPIN);
                            cmd.Parameters.AddWithValue("@userid", userId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("PIN alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Seleciona a linha toda ao clicar numa célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTransacoes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgTransacoes.Rows[e.RowIndex].Selected = true;
            }
        }
        /// <summary>
        /// Apaga a transação selecionada em <see cref="dgTransacoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbxContaSel.SelectedIndex > 0)
            {
                ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
                confirmar.Closed += (s, args) => Show();
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Continue)
                {
                    int userId = Convert.ToInt32(cbxContaSel.SelectedValue);

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                            cmd.Connection = Program.db;
                            cmd.CommandText = "DELETE FROM [bank_accounts] WHERE userid = @userid";
                            cmd.Parameters.AddWithValue("@userid", userId);
                            cmd.ExecuteNonQuery();
                            LoadUsernames();
                            dgTransacoes.DataSource = null;
                            MessageBox.Show("Conta deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    tbxPIN.Text = "";
                    tbxRepPIN.Text = "";
                    chkShowPIN.Checked = false;
                }
            }
        }
        /// <summary>
        /// Alterna a visibilidade dos PINS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShowPIN_CheckedChanged(object sender, EventArgs e)
        {
            tbxPIN.UseSystemPasswordChar = !chkShowPIN.Checked;
            tbxRepPIN.UseSystemPasswordChar = !chkShowPIN.Checked;
        }
        /// <summary>
        /// Verifica se as textboxes cumprem os requisitos
        /// </summary>
        private void VerifyTxtbxs()
        {
            if (tbxPIN.Text.Length != 4 || tbxRepPIN.Text.Length != 4)
            {
                btnAlterarPIN.Enabled = false;
                Program.DisplaylblError(lblErro, "Tem de preencher todos os campos obrigatórios. (*)");
            }
            else if (tbxPIN.Text != tbxRepPIN.Text)
            {
                btnAlterarPIN.Enabled = false;
                Program.DisplaylblError(lblErro, "Os PINs devem ser iguais.");
            }
            else
            {
                lblErro.Visible = false;
                btnAlterarPIN.Enabled = true;
            }
        }
        /// <summary>
        /// Altera o foco para a textbox referente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltbxPIN_Click(object sender, EventArgs e)
        {
            tbxPIN.Focus();
        }
        /// <summary>
        /// Altera o foco para a textbox referente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltbxRepPIN_Click(object sender, EventArgs e)
        {
            tbxRepPIN.Focus();
        }
        /// <summary>
        /// Chama <see cref="VerifyTxtbxs"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPIN_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }
        /// <summary>
        /// Chama <see cref="VerifyTxtbxs"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxRepPIN_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }
        /// <summary>
        /// Limita os caracteres recebidos pela <see cref="tbxPIN"/> e pela <see cref="tbxRepPIN"/> apenas a números
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
