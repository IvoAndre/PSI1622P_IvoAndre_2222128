using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form permite ao utilizador inserir o seu nome de utilizador e palavra-passe para iniciar sessão no programa
    /// </summary>
    public partial class ContaEntrar : Form
    {

        public ContaEntrar()
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
        /// Verifica se todos os campos estão preenchidos, caso contrário mostra um aviso e desabilita o <see cref="btnEntrar"/>
        /// </summary>
        private void VerifyTxtbxs()
        {
            if ( tbxUsername.Text.Length == 0 || tbxPass.Text.Length == 0 )
            {
                btnEntrar.Enabled = false;
                Program.DisplaylblError(lblErro, "Tem de preencher todos os campos obrigatórios. (*)");
            }
            else
            {
                lblErro.Visible = false;
                btnEntrar.Enabled = true;
            }
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
        /// Verifica se o nome de utilizador e a palavra-passe coincidem com os guardados na base de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string hash = "";
            if (!Program.IsUsernameUnique(tbxUsername.Text))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Program.db;
                    cmd.CommandText = "SELECT password FROM users WHERE username COLLATE Latin1_General_BIN = @username";
                    cmd.Parameters.AddWithValue("@username", tbxUsername.Text);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read()) {
                                hash = dr["password"].ToString();
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
                    if (Crypt.Verify(tbxPass.Text, hash))
                    {

                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = Program.db;
                            cmd.CommandText = "SELECT * FROM users WHERE username COLLATE Latin1_General_BIN = @username";
                            cmd.Parameters.AddWithValue("@username", tbxUsername.Text);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        Program.user.ID = (int)dr["id"];
                                        Program.user.Username = dr["username"].ToString();
                                        Program.user.Name = dr["Name"].ToString();
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
                            Hide();
                            Loading loading = new Loading();
                            loading.Closed += (s, args) => Close();
                            loading.ShowDialog();
                        }
                        

                        
                    }
                    else
                    {
                        Program.DisplaylblError(lblErro, "O nome de utilizador ou a palavra-passe estão incorretos.");
                    }


                }
            }
            else
            {
                Program.DisplaylblError(lblErro, "O nome de utilizador ou a palavra-passe estão incorretos.");
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
            }
            else
            {
                tbxPass.UseSystemPasswordChar = true;
            }
        }
    }
}