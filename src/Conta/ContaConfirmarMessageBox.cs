﻿using Microsoft.Data.SqlClient;

namespace Projeto2Ano
{
    public partial class ContaConfirmarMessageBox : Form
    {
        public ContaConfirmarMessageBox()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            
            if(Program.adminMode)
            {
                tbxPass.Visible = false;
                chkShowPass.Visible = false;
                lblTitle.Text = "Esta operação requer a sua confirmação:";
            }
            KeyDown += ContaConfirmarMessageBox_KeyDown;
        }

        private void ContaConfirmarMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnConfirm.Enabled)
                {
                    btnConfirm.Select();
                }
                e.Handled = true;
            }
        }

        

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Program.adminMode)
            {
                DialogResult = DialogResult.Continue;
                Close();
            }
            else
            {
                if (tbxPass.Text.Length != 0)
                {
                    string hash = "";
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = Program.db;
                        cmd.CommandText = "SELECT password FROM users WHERE username = @username";
                        cmd.Parameters.AddWithValue("@username", Program.user.Username);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
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
                            DialogResult = DialogResult.Continue;
                            Close();
                        }
                        else
                        {
                            Program.DisplaylblError(lblErro, "A palavra-passe está incorreta.");
                        }
                    }
                }
                else
                {
                    Program.DisplaylblError(lblErro, "Insira a sua palavra-passe.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
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
