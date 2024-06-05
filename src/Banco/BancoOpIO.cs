using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.VisualBasic.ApplicationServices;
using Projeto2Ano;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto2Ano
{
    public partial class BancoOpIO : Form
    {
        private bool AddMode;
        public BancoOpIO(bool _AddMode)
        {
            InitializeComponent();
            Program.DetectTheme(this);
            AddMode = _AddMode;
            Program.GetSaldo(Program.user.ID);
            lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}";
            if (AddMode)
            {
                lblTitle.Text = "Depósito de Fundos";
                lbltbxQuantia.Text = "Quantia a Depositar*";
            }
            else
            {
                lblTitle.Text = "Levantamento de Fundos";
                lbltbxQuantia.Text = "Quantia a Levantar*";
            }





            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
        }



        private void btnOption_Click(object sender, EventArgs e)
        {

            if (AddMode)
            {
                
                if (Program.AdicionarFundos(Program.user.ID, "Depósito de Fundos", double.Parse(tbxQuantia.Text)) == DialogResult.OK)
                {
                    MessageBox.Show("");
                }
            }
            else
            {
                Program.RemoverFundos(Program.user.ID, "Levantamento de Fundos", double.Parse(tbxQuantia.Text),false);
            }
            lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}";
        }

        private void tbxQuantia_TextChanged(object sender, EventArgs e)
        {
            string text = tbxQuantia.Text;
            if (tbxQuantia.Text.Length != 0) 
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
    }
}




