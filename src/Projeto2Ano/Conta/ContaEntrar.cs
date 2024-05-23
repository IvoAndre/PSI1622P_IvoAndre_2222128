using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace Projeto2Ano
{
    public partial class ContaEntrar : Form
    {
        private SqlDataReader dr;
        public ContaEntrar()
        {
            InitializeComponent();
            Program.DetectTheme(this);

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
        }

        private bool usernameExists()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Program.db;
            cmd.CommandText = "SELECT username FROM users WHERE username = @username";
            cmd.Parameters.AddWithValue("@username", tbxUsername.Text);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                        return true;
                }
            }

            return false;
        }

        private void lblErrorDisplay(string Erro)
        {
            lblErro.Visible = true;
            lblErro.Text = Erro;
        }
        private void VerifyTxtbxs()
        {
            if ( tbxUsername.Text.Length == 0 && tbxPass.Text.Length == 0 )
            {
                btnEntrar.Enabled = false;
                lblErrorDisplay("Tem de preencher todos os campos obrigatórios. (*)");
            }
            else
            {
                lblErro.Visible = false;
                btnEntrar.Enabled = true;
            }
        }

        //lblFocustbx

        private void lbltbxUsername_Click(object sender, EventArgs e)
        {
            tbxUsername.Focus();
        }

        private void lbltbxPass_Click(object sender, EventArgs e)
        {
            tbxPass.Focus();
        }

        //verifytxbxs when textchanges
        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxPass_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string hash = "";
            if (usernameExists())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Program.db;
                    cmd.CommandText = "SELECT password FROM users WHERE username = @username";
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
                        User user = new User();

                        try
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = Program.db;
                            cmd.CommandText = "SELECT * FROM users WHERE username = @username";
                            cmd.Parameters.AddWithValue("@username", tbxUsername.Text);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        user.Username = dr["username"].ToString();
                                        user.Name = dr["Name"].ToString();
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
                        lblErrorDisplay("A palavra-passe está incorreta.");
                    }


                }
            }
        }

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