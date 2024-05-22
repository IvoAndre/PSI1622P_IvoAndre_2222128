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
            BackColor = Program.backcolor;
            ForeColor = Program.forecolor;
        }


        private void cbxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTheme.SelectedIndex == -1 || cbxTheme.SelectedIndex == 0)
            {
                Program.backcolor = SystemColors.Control;
                Program.forecolor = Color.Black;
            }
            else if (cbxTheme.SelectedIndex != 0)
            {
                Program.backcolor = SystemColors.ControlDark;
                Program.forecolor = Color.White;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
