using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto2Ano.Conta
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

        private void DisplaylblError(string Erro)
        {
            lblErro.ForeColor = Color.Red;
            lblErro.Visible = true;
            lblErro.Text = Erro;
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
                            DisplaylblError("A palavra-passe está incorreta.");
                        }
                    }
                }
                else
                {
                    DisplaylblError("Insira a sua palavra-passe.");
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
