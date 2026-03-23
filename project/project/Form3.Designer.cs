namespace project
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            ThemeOptionLabel = new Label();
            MusicOptionLabel = new Label();
            DarkThemeRadioButton = new RadioButton();
            LightThemeRadioButton = new RadioButton();
            MusicOnRadioButton = new RadioButton();
            MusicOffRadioButton = new RadioButton();
            MusicGroupBox = new GroupBox();
            ThemeGroupBox = new GroupBox();
            BackToMenuOption = new Button();
            difficultyOptionLabel = new Label();
            difficultyGroupBox = new GroupBox();
            hardRadioButton = new RadioButton();
            easyRadioButton = new RadioButton();
            mediumRadioButton = new RadioButton();
            MusicGroupBox.SuspendLayout();
            ThemeGroupBox.SuspendLayout();
            difficultyGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ThemeOptionLabel
            // 
            ThemeOptionLabel.AutoSize = true;
            ThemeOptionLabel.Font = new Font("Showcard Gothic", 30F, FontStyle.Italic);
            ThemeOptionLabel.Location = new Point(100, 50);
            ThemeOptionLabel.Name = "ThemeOptionLabel";
            ThemeOptionLabel.Size = new Size(542, 62);
            ThemeOptionLabel.TabIndex = 0;
            ThemeOptionLabel.Text = "BACKGROUND THEME";
            // 
            // MusicOptionLabel
            // 
            MusicOptionLabel.AutoSize = true;
            MusicOptionLabel.Font = new Font("Showcard Gothic", 30F, FontStyle.Italic);
            MusicOptionLabel.Location = new Point(89, 204);
            MusicOptionLabel.Name = "MusicOptionLabel";
            MusicOptionLabel.Size = new Size(177, 62);
            MusicOptionLabel.TabIndex = 1;
            MusicOptionLabel.Text = "MUSIC";
            // 
            // DarkThemeRadioButton
            // 
            DarkThemeRadioButton.AutoSize = true;
            DarkThemeRadioButton.Font = new Font("Showcard Gothic", 9F);
            DarkThemeRadioButton.Location = new Point(6, 26);
            DarkThemeRadioButton.Name = "DarkThemeRadioButton";
            DarkThemeRadioButton.Size = new Size(70, 22);
            DarkThemeRadioButton.TabIndex = 2;
            DarkThemeRadioButton.TabStop = true;
            DarkThemeRadioButton.Text = "DARK";
            DarkThemeRadioButton.UseVisualStyleBackColor = true;
            DarkThemeRadioButton.CheckedChanged += DarkThemeRadioButton_CheckedChanged;
            // 
            // LightThemeRadioButton
            // 
            LightThemeRadioButton.AutoSize = true;
            LightThemeRadioButton.Font = new Font("Showcard Gothic", 9F);
            LightThemeRadioButton.Location = new Point(6, 54);
            LightThemeRadioButton.Name = "LightThemeRadioButton";
            LightThemeRadioButton.Size = new Size(73, 22);
            LightThemeRadioButton.TabIndex = 3;
            LightThemeRadioButton.TabStop = true;
            LightThemeRadioButton.Text = "LIGHT";
            LightThemeRadioButton.UseVisualStyleBackColor = true;
            LightThemeRadioButton.CheckedChanged += LightThemeRadioButton_CheckedChanged;
            // 
            // MusicOnRadioButton
            // 
            MusicOnRadioButton.AutoSize = true;
            MusicOnRadioButton.Font = new Font("Showcard Gothic", 9F);
            MusicOnRadioButton.Location = new Point(6, 26);
            MusicOnRadioButton.Name = "MusicOnRadioButton";
            MusicOnRadioButton.Size = new Size(50, 22);
            MusicOnRadioButton.TabIndex = 4;
            MusicOnRadioButton.TabStop = true;
            MusicOnRadioButton.Text = "ON";
            MusicOnRadioButton.UseVisualStyleBackColor = true;
            MusicOnRadioButton.CheckedChanged += MusicOnRadioButton_CheckedChanged;
            // 
            // MusicOffRadioButton
            // 
            MusicOffRadioButton.AutoSize = true;
            MusicOffRadioButton.Font = new Font("Showcard Gothic", 9F);
            MusicOffRadioButton.Location = new Point(6, 54);
            MusicOffRadioButton.Name = "MusicOffRadioButton";
            MusicOffRadioButton.Size = new Size(56, 22);
            MusicOffRadioButton.TabIndex = 5;
            MusicOffRadioButton.TabStop = true;
            MusicOffRadioButton.Text = "OFF";
            MusicOffRadioButton.UseVisualStyleBackColor = true;
            MusicOffRadioButton.CheckedChanged += MusicOffRadioButton_CheckedChanged;
            // 
            // MusicGroupBox
            // 
            MusicGroupBox.Controls.Add(MusicOnRadioButton);
            MusicGroupBox.Controls.Add(MusicOffRadioButton);
            MusicGroupBox.Location = new Point(100, 269);
            MusicGroupBox.Name = "MusicGroupBox";
            MusicGroupBox.Size = new Size(250, 86);
            MusicGroupBox.TabIndex = 6;
            MusicGroupBox.TabStop = false;
            MusicGroupBox.Text = "Choose music option:";
            // 
            // ThemeGroupBox
            // 
            ThemeGroupBox.Controls.Add(DarkThemeRadioButton);
            ThemeGroupBox.Controls.Add(LightThemeRadioButton);
            ThemeGroupBox.Location = new Point(106, 115);
            ThemeGroupBox.Name = "ThemeGroupBox";
            ThemeGroupBox.Size = new Size(250, 87);
            ThemeGroupBox.TabIndex = 6;
            ThemeGroupBox.TabStop = false;
            ThemeGroupBox.Text = "Choose a theme:";
            // 
            // BackToMenuOption
            // 
            BackToMenuOption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BackToMenuOption.Font = new Font("Showcard Gothic", 9F, FontStyle.Italic);
            BackToMenuOption.Location = new Point(25, 390);
            BackToMenuOption.Name = "BackToMenuOption";
            BackToMenuOption.Size = new Size(194, 29);
            BackToMenuOption.TabIndex = 0;
            BackToMenuOption.TabStop = false;
            BackToMenuOption.Text = "BACK TO MAIN MENU";
            BackToMenuOption.UseVisualStyleBackColor = true;
            BackToMenuOption.Click += BackToMenuOption_Click;
            BackToMenuOption.MouseLeave += BackToMenuOption_MouseLeave;
            BackToMenuOption.MouseMove += BackToMenuOption_MouseMove;
            // 
            // difficultyOptionLabel
            // 
            difficultyOptionLabel.AutoSize = true;
            difficultyOptionLabel.Font = new Font("Showcard Gothic", 30F, FontStyle.Italic);
            difficultyOptionLabel.Location = new Point(419, 129);
            difficultyOptionLabel.Name = "difficultyOptionLabel";
            difficultyOptionLabel.Size = new Size(313, 62);
            difficultyOptionLabel.TabIndex = 7;
            difficultyOptionLabel.Text = "DIFFICULTY";
            // 
            // difficultyGroupBox
            // 
            difficultyGroupBox.Controls.Add(hardRadioButton);
            difficultyGroupBox.Controls.Add(easyRadioButton);
            difficultyGroupBox.Controls.Add(mediumRadioButton);
            difficultyGroupBox.Location = new Point(440, 194);
            difficultyGroupBox.Name = "difficultyGroupBox";
            difficultyGroupBox.Size = new Size(250, 123);
            difficultyGroupBox.TabIndex = 7;
            difficultyGroupBox.TabStop = false;
            difficultyGroupBox.Text = "Choose a difficulty:";
            // 
            // hardRadioButton
            // 
            hardRadioButton.AutoSize = true;
            hardRadioButton.Font = new Font("Showcard Gothic", 9F);
            hardRadioButton.Location = new Point(6, 82);
            hardRadioButton.Name = "hardRadioButton";
            hardRadioButton.Size = new Size(71, 22);
            hardRadioButton.TabIndex = 4;
            hardRadioButton.TabStop = true;
            hardRadioButton.Text = "HARD";
            hardRadioButton.UseVisualStyleBackColor = true;
            hardRadioButton.CheckedChanged += hardRadioButton_CheckedChanged;
            // 
            // easyRadioButton
            // 
            easyRadioButton.AutoSize = true;
            easyRadioButton.Font = new Font("Showcard Gothic", 9F);
            easyRadioButton.Location = new Point(6, 26);
            easyRadioButton.Name = "easyRadioButton";
            easyRadioButton.Size = new Size(64, 22);
            easyRadioButton.TabIndex = 2;
            easyRadioButton.TabStop = true;
            easyRadioButton.Text = "EASY";
            easyRadioButton.UseVisualStyleBackColor = true;
            easyRadioButton.CheckedChanged += easyRadioButton_CheckedChanged;
            // 
            // mediumRadioButton
            // 
            mediumRadioButton.AutoSize = true;
            mediumRadioButton.Font = new Font("Showcard Gothic", 9F);
            mediumRadioButton.Location = new Point(6, 54);
            mediumRadioButton.Name = "mediumRadioButton";
            mediumRadioButton.Size = new Size(91, 22);
            mediumRadioButton.TabIndex = 3;
            mediumRadioButton.TabStop = true;
            mediumRadioButton.Text = "MEDIUM";
            mediumRadioButton.UseVisualStyleBackColor = true;
            mediumRadioButton.CheckedChanged += mediumRadioButton_CheckedChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(difficultyGroupBox);
            Controls.Add(difficultyOptionLabel);
            Controls.Add(BackToMenuOption);
            Controls.Add(ThemeGroupBox);
            Controls.Add(MusicGroupBox);
            Controls.Add(MusicOptionLabel);
            Controls.Add(ThemeOptionLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form3";
            Text = "BRI(EA)CK OR DIE";
            MusicGroupBox.ResumeLayout(false);
            MusicGroupBox.PerformLayout();
            ThemeGroupBox.ResumeLayout(false);
            ThemeGroupBox.PerformLayout();
            difficultyGroupBox.ResumeLayout(false);
            difficultyGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label ThemeOptionLabel;
        public Label MusicOptionLabel;
        public RadioButton DarkThemeRadioButton;
        public RadioButton LightThemeRadioButton;
        public RadioButton MusicOnRadioButton;
        public RadioButton MusicOffRadioButton;
        public GroupBox MusicGroupBox;
        public GroupBox ThemeGroupBox;
        private Button BackToMenuOption;
        public Label difficultyOptionLabel;
        public GroupBox difficultyGroupBox;
        private RadioButton hardRadioButton;
        public RadioButton easyRadioButton;
        public RadioButton mediumRadioButton;
    }
}