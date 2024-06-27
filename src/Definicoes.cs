namespace Projeto2Ano
{
    /// <summary>
    /// Este form mostra as definições gerais do programa, por agora apenas contém a seleção do tema
    /// </summary>
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

            //Verificar se themeFile existe e se sim mostrar o tema guardado
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

        /// <summary>
        /// Altera o tema do programa segundo a opção selecionada<br/>
        /// <list type="number"> 
        ///     <item>Claro</item>
        ///     <item>Escuro</item>
        /// </list>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        

        /// <summary>
        /// Restaura as predefinições, apaga o ficheiro de tema guardado e fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (File.Exists(Program.configFolder + Program.themeFilePath))
                {
                File.Delete(Program.configFolder + Program.themeFilePath);
                }
            Program.backcolor = Color.White;
            Program.forecolor = Color.Black;
            Program.altBackcolor = Color.LightGray;
            Close();
        }

        /// <summary>
        /// Fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
