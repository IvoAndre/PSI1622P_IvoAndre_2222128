using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este Form serve como inicio de sess�o na conta banc�ria do utilizador e como confirma��o de opera��es banc�rias.
    /// </summary>
    public partial class BancoConfirmar : Form
    {
        /// <summary>
        /// True se o form for usado para inicio de sess�o<br/>False se for usado para confirma��o de uma opera��o
        /// </summary>
        bool IsEnterOp = false;
        /// <summary>
        /// Inicia o form e define o texto dos controlos conforme o estado de <see cref="IsEnterOp"/>
        /// </summary>
        /// <param name="isEnterOp">Define o valor de <see cref="IsEnterOp"/></param>
        public BancoConfirmar(bool isEnterOp)
        {
            InitializeComponent();
            Program.DetectTheme(this);

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

            IsEnterOp = isEnterOp;
            if (IsEnterOp)
            {
                lblTitle.Text = "Entrar na Conta";
                btnOption.Text = "Entrar";
                btnReturn.Text = "Voltar";
            }
            else
            {
                lblTitle.Text = "Confirmar Opera��o";
                btnOption.Text = "Confirmar";
                btnReturn.Text = "Cancelar";
            }
        }
        /// <summary>
        /// Verifica se as textboxes do form seguem determinadas condi��es, caso isso n�o se verifique � mostrado um erro na <see cref="lblErro"/> e <see cref="btnOption"/> � desabilitado
        /// </summary>
        private void VerifyTxtbxs()
        {
            if (tbxPIN.Text.Length != 4)
            {
                btnOption.Enabled = false;
                Program.DisplaylblError(lblErro, "Tem de preencher todos os \ncampos obrigat�rios. (*)");
            }
            else
            {
                lblErro.Visible = false;
                btnOption.Enabled = true;
            }
        }

        /// <summary>
        /// Transfere o foco para a textbox relacionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltbxPIN_Click(object sender, EventArgs e)
        {
            tbxPIN.Focus();
        }
        /// <summary>
        /// Chama a fun��o <see cref="VerifyTxtbxs"/> sempre que o seu texto � alterado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPIN_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        /// <summary>
        /// Limita os caracteres recebidos para apenas n�meros
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
        /// Executa a opera��o do form verificando se o PIN corresponde ao PIN (em hash) armazenado para a conta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption_Click(object sender, EventArgs e)
        {
            string hash = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.db;
                cmd.CommandText = "SELECT pin FROM [bank_accounts] WHERE userid = @userid";
                cmd.Parameters.AddWithValue("@userid", Program.user.ID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            hash = dr["pin"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Crypt.Verify(tbxPIN.Text, hash))
                {
                    if (IsEnterOp)
                    {
                        DialogResult = DialogResult.Continue;
                        Hide();
                        BancoPrincipal bancoPrincipal = new BancoPrincipal();
                        bancoPrincipal.Closed += (s, args) => Close();
                        bancoPrincipal.ShowDialog();
                    }
                    else
                    {
                        DialogResult = DialogResult.Continue;
                        Close();
                    }
                }
                else
                {
                    Program.DisplaylblError(lblErro, "O PIN est� incorreto.");
                }
                    
            }
        }

        /// <summary>
        /// Mostra o PIN quando checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShowPIN_CheckedChanged(object sender, EventArgs e)
        {
            tbxPIN.UseSystemPasswordChar = !chkShowPIN.Checked;
        }

        /// <summary>
        /// Fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}