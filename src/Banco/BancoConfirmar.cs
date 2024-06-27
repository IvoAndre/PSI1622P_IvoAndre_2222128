using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este Form serve como inicio de sessão na conta bancária do utilizador e como confirmação de operações bancárias.
    /// </summary>
    public partial class BancoConfirmar : Form
    {
        /// <summary>
        /// True se o form for usado para inicio de sessão<br/>False se for usado para confirmação de uma operação
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
                lblTitle.Text = "Confirmar Operação";
                btnOption.Text = "Confirmar";
                btnReturn.Text = "Cancelar";
            }
        }
        /// <summary>
        /// Verifica se as textboxes do form seguem determinadas condições, caso isso não se verifique é mostrado um erro na <see cref="lblErro"/> e <see cref="btnOption"/> é desabilitado
        /// </summary>
        private void VerifyTxtbxs()
        {
            if (tbxPIN.Text.Length != 4)
            {
                btnOption.Enabled = false;
                Program.DisplaylblError(lblErro, "Tem de preencher todos os \ncampos obrigatórios. (*)");
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
        /// Chama a função <see cref="VerifyTxtbxs"/> sempre que o seu texto é alterado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPIN_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        /// <summary>
        /// Limita os caracteres recebidos para apenas números
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
        /// Executa a operação do form verificando se o PIN corresponde ao PIN (em hash) armazenado para a conta
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
                    Program.DisplaylblError(lblErro, "O PIN está incorreto.");
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