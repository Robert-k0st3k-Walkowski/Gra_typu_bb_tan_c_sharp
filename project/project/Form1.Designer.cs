namespace project
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            GameTitle = new Label();
            StartGame = new Button();
            Options = new Button();
            Exit = new Button();
            SuspendLayout();
            // 
            // GameTitle
            // 
            GameTitle.AutoSize = true;
            GameTitle.Font = new Font("Showcard Gothic", 36F, FontStyle.Italic, GraphicsUnit.Point, 0);
            GameTitle.Location = new Point(130, 9);
            GameTitle.Name = "GameTitle";
            GameTitle.Size = new Size(536, 74);
            GameTitle.TabIndex = 0;
            GameTitle.Text = "BRI(EA)CK OR DIE";
            // 
            // StartGame
            // 
            StartGame.Font = new Font("Showcard Gothic", 20F, FontStyle.Italic);
            StartGame.Location = new Point(358, 109);
            StartGame.Name = "StartGame";
            StartGame.Size = new Size(94, 29);
            StartGame.TabIndex = 0;
            StartGame.TabStop = false;
            StartGame.Text = "START";
            StartGame.UseVisualStyleBackColor = true;
            StartGame.Click += StartGame_Click;
            StartGame.MouseLeave += StartGame_MouseLeave;
            StartGame.MouseMove += StartGame_MouseMove;
            // 
            // Options
            // 
            Options.Font = new Font("Showcard Gothic", 20F, FontStyle.Italic);
            Options.Location = new Point(358, 171);
            Options.Name = "Options";
            Options.Size = new Size(94, 29);
            Options.TabIndex = 0;
            Options.TabStop = false;
            Options.Text = "OPTIONS";
            Options.UseVisualStyleBackColor = true;
            Options.Click += Options_Click;
            Options.MouseLeave += Options_MouseLeave;
            Options.MouseMove += Options_MouseMove;
            // 
            // Exit
            // 
            Exit.Font = new Font("Showcard Gothic", 20F, FontStyle.Italic);
            Exit.Location = new Point(358, 225);
            Exit.Name = "Exit";
            Exit.Size = new Size(94, 29);
            Exit.TabIndex = 0;
            Exit.TabStop = false;
            Exit.Text = "EXIT";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            Exit.MouseLeave += Exit_MouseLeave;
            Exit.MouseMove += Exit_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Exit);
            Controls.Add(Options);
            Controls.Add(StartGame);
            Controls.Add(GameTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "BRI(EA)CK OR DIE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label GameTitle;
        public Button StartGame;
        public Button Options;
        public Button Exit;
    }
}
