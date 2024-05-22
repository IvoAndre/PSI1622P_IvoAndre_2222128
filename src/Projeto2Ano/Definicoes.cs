using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto2Ano
{
    public partial class Definicoes : Form
    {
        public Definicoes()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (BackColor != Color.White)
            {
                cbxTheme.SelectedIndex = 1;
                cbxTheme.Text = "Escuro";
            }

            
        }


        private void cbxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTheme.SelectedIndex == -1 || cbxTheme.SelectedIndex == 0)
            {
                Program.backcolor = Color.White;
                Program.forecolor = Color.Black;
            }
            else if (cbxTheme.SelectedIndex == 1)
            {
                Program.backcolor = Color.FromArgb(255, 33, 34, 33);
                Program.forecolor = Color.White;
            }
            Program.DetectTheme(this);
            Refresh();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
