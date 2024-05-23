using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    public partial class ContaCriar : Form
    {
        private SqlDataReader dr;
        public ContaCriar()
        {
            InitializeComponent();
            Program.DetectTheme(this);

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
        }

        private bool IsUsernameUnique()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.db;
            cmd.CommandText = "SELECT username FROM users WHERE username = @username";
            cmd.Parameters.AddWithValue("@username", tbxUsername.Text);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void lblErrorDisplay(string Erro)
        {
            lblErro.Visible = true;
            lblErro.Text = Erro;
        }
        private void VerifyTxtbxs()
        {
            if (tbxName.Text.Length == 0 && tbxUsername.Text.Length == 0 && tbxPass.Text.Length == 0 && tbxRepPass.Text.Length == 0)
            {
                btnCriar.Enabled = false;
                lblErrorDisplay("Tem de preencher todos os campos obrigatórios. (*)");
            }
            else if (!IsUsernameUnique())
            {
                btnCriar.Enabled = false;
                lblErrorDisplay("Este Nome de Utilizador já está a ser utilizado!");
            }
            else if (tbxPass.Text != tbxRepPass.Text)
            {
                btnCriar.Enabled = false;
                lblErrorDisplay("As palavras-passe devem ser iguais.");
            }
            else
            {
                lblErro.Visible = false;
                btnCriar.Enabled = true;
            }
        }

        //lblFocustbx
        private void lbltbxName_Click(object sender, EventArgs e)
        {
            tbxName.Focus();
        }

        private void lbltbxUsername_Click(object sender, EventArgs e)
        {
            tbxUsername.Focus();
        }

        private void lbltbxPass_Click(object sender, EventArgs e)
        {
            tbxPass.Focus();
        }

        private void lbltbxRepPass_Click(object sender, EventArgs e)
        {
            tbxRepPass.Focus();
        }

        //verifytxbxs when textchanges
        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxPass_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxRepPass_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

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