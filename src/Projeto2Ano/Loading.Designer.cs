namespace Projeto2Ano
{
    partial class Loading
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            Timer = new System.Windows.Forms.Timer(components);
            pBar = new ProgressBar();
            SuspendLayout();
            // 
            // Timer
            // 
            Timer.Enabled = true;
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            // 
            // pBar
            // 
            pBar.Location = new Point(8, 8);
            pBar.Margin = new Padding(10);
            pBar.Name = "pBar";
            pBar.Size = new Size(300, 25);
            pBar.Step = 20;
            pBar.Style = ProgressBarStyle.Continuous;
            pBar.TabIndex = 4;
            // 
            // Loading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(316, 41);
            ControlBox = false;
            Controls.Add(pBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Loading";
            StartPosition = FormStartPosition.CenterParent;
            Text = "A Carregar...";
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer Timer;
        private ProgressBar pBar;
    }
}