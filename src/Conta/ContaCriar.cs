using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Permite ao utilizador criar uma conta para iniciar sessão em <see cref="ContaEntrar"/>
    /// </summary>
    public partial class ContaCriar : Form
    {
        
        public ContaCriar()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            lblErro.ForeColor = Color.Red;

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

          
        }
        /// <summary>
        /// Verifica se as textboxes cumprem todos os requisitos
        /// </summary>
        private void VerifyTxtbxs()
        {
            if (tbxName.Text.Length == 0 || tbxUsername.Text.Length == 0 || tbxPass.Text.Length == 0 || tbxRepPass.Text.Length == 0)
            {
                btnCriar.Enabled = false;
                Program.DisplaylblError(lblErro, "Tem de preencher todos os campos obrigatórios. (*)");
            }
            else if (!Program.IsUsernameUnique(tbxUsername.Text))
            {
                btnCriar.Enabled = false;
                Program.DisplaylblError(lblErro, "Este Nome de Utilizador já está a ser utilizado!");
            }
            else if (tbxPass.Text != tbxRepPass.Text)
            {
                btnCriar.Enabled = false;
                Program.DisplaylblError(lblErro, "As palavras-passe devem ser iguais.");
            }
            else
            {
                lblErro.Visible = false;
                btnCriar.Enabled = true;
            }
        }

        /// <summary>
        /// Altera o foco para a textbox referente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltbxName_Click(object sender, EventArgs e)
        {
            tbxName.Focus();
        }
        /// <summary>
        /// Altera o foco para a textbox referente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltbxUsername_Click(object sender, EventArgs e)
        {
            tbxUsername.Focus();
        }
        /// <summary>
        /// Altera o foco para a textbox referente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltbxPass_Click(object sender, EventArgs e)
        {
            tbxPass.Focus();
        }
        /// <summary>
        /// Altera o foco para a textbox referente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbltbxRepPass_Click(object sender, EventArgs e)
        {
            tbxRepPass.Focus();
        }

        /// <summary>
        /// Chama <see cref="VerifyTxtbxs"/> para verificação dos requisitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }
        /// <summary>
        /// Chama <see cref="VerifyTxtbxs"/> para verificação dos requisitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }
        /// <summary>
        /// Chama <see cref="VerifyTxtbxs"/> para verificação dos requisitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPass_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }
        /// <summary>
        /// Chama <see cref="VerifyTxtbxs"/> para verificação dos requisitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxRepPass_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }
        /// <summary>
        /// Insere os dados na base de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = Program.db;

                cmdInsert.CommandText = "INSERT INTO users (name,username,password) VALUES (@name,@username,@password)";

                cmdInsert.Parameters.Add("@name", SqlDbType.VarChar).Value = tbxName.Text;
                cmdInsert.Parameters.Add("@username", SqlDbType.VarChar).Value = tbxUsername.Text;
                cmdInsert.Parameters.Add("@password", SqlDbType.VarChar).Value = Crypt.Hash(tbxPass.Text);


                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Conta criada com sucesso!\nInicie a sessão para entrar no programa.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            { 
                Close();
            }

        }
        /// <summary>
        /// Alterna a visibilidade da palavra-passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShowPass.Checked)
            {
                tbxPass.UseSystemPasswordChar = false;
                tbxRepPass.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPass.UseSystemPasswordChar = true;
                tbxRepPass.UseSystemPasswordChar = true;
            }
        }
    }
}