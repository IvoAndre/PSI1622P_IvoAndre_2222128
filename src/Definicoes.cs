namespace Projeto2Ano
{
    public partial class Definicoes : Form
    {
        public Definicoes()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            //Criar ConfigFolder
            if (!Directory.Exists(Program.configFolder))
            {
                Directory.CreateDirectory(Program.configFolder);
            }

            //Verificar se themeFile existe e se sim mostrar a opção selecionada
            if (File.Exists(Program.themeFilePath))
            {
                string theme = File.ReadAllText(Program.themeFilePath);
                switch (theme)
                {
                    case "Claro":
                        cbxTheme.SelectedIndex = 0;
                        cbxTheme.Text = theme;
                        break;
                    case "Escuro":
                        cbxTheme.SelectedIndex = 1;
                        cbxTheme.Text = theme;
                        break;
                    default:
                        cbxTheme.SelectedIndex = -1;
                        break;
                }
            }
            else
            {
                cbxTheme.SelectedIndex = -1;
            }

        }


        private void cbxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbxTheme.SelectedIndex)
            {
                case 0:
                    Program.backcolor = Color.White;
                    Program.altBackcolor = Color.LightGray;
                    Program.forecolor = Color.Black;
                    
                    File.WriteAllText(Program.themeFilePath, cbxTheme.Text);
                    break;
                case 1:
                    Program.backcolor = Color.FromArgb(255, 33, 34, 33);
                    Program.altBackcolor = Color.FromArgb(255, 38, 39, 38);
                    Program.forecolor = Color.White;
                    File.WriteAllText(Program.themeFilePath, cbxTheme.Text);
                    break;
                default:
                    Program.backcolor = Color.White;
                    Program.altBackcolor = Color.LightGray;
                    Program.forecolor = Color.Black;
                    break;
            }
            Program.DetectTheme(this);
            Refresh();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Directory.Delete(Program.configFolder, true);
            Program.backcolor = Color.White;
            Program.forecolor = Color.Black;
            Program.altBackcolor = Color.LightGray;
            Close();
        }
    }
}
