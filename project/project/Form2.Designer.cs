namespace project
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            BackToMenu = new Button();
            GameBoard = new PictureBox();
            HealthLabel = new Label();
            ScoreLabel = new Label();
            ScoreTextBox = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            BallsLabel = new Label();
            BallsTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)GameBoard).BeginInit();
            SuspendLayout();
            // 
            // BackToMenu
            // 
            BackToMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BackToMenu.Font = new Font("Showcard Gothic", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            BackToMenu.Location = new Point(11, 387);
            BackToMenu.Name = "BackToMenu";
            BackToMenu.Size = new Size(160, 29);
            BackToMenu.TabIndex = 0;
            BackToMenu.TabStop = false;
            BackToMenu.Text = "Back to main menu";
            BackToMenu.UseVisualStyleBackColor = true;
            BackToMenu.Click += BackToMenu_Click;
            BackToMenu.MouseLeave += BackToMenu_MouseLeave;
            BackToMenu.MouseMove += BackToMenu_MouseMove;
            // 
            // GameBoard
            // 
            GameBoard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            GameBoard.Location = new Point(1, 107);
            GameBoard.Name = "GameBoard";
            GameBoard.Size = new Size(800, 204);
            GameBoard.TabIndex = 1;
            GameBoard.TabStop = false;
            GameBoard.Paint += GameBoard_Paint;
            // 
            // HealthLabel
            // 
            HealthLabel.AutoSize = true;
            HealthLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            HealthLabel.Location = new Point(507, 20);
            HealthLabel.Name = "HealthLabel";
            HealthLabel.Size = new Size(66, 35);
            HealthLabel.TabIndex = 2;
            HealthLabel.Text = "HP:";
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ScoreLabel.Location = new Point(31, 20);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new Size(111, 35);
            ScoreLabel.TabIndex = 3;
            ScoreLabel.Text = "SCORE:";
            // 
            // ScoreTextBox
            // 
            ScoreTextBox.Enabled = false;
            ScoreTextBox.Font = new Font("Showcard Gothic", 16F, FontStyle.Italic);
            ScoreTextBox.Location = new Point(31, 60);
            ScoreTextBox.Name = "ScoreTextBox";
            ScoreTextBox.ReadOnly = true;
            ScoreTextBox.Size = new Size(141, 41);
            ScoreTextBox.TabIndex = 5;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer1.Tick += timer1_Tick;
            // 
            // BallsLabel
            // 
            BallsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BallsLabel.AutoSize = true;
            BallsLabel.Font = new Font("Showcard Gothic", 16.2F, FontStyle.Italic);
            BallsLabel.Location = new Point(507, 337);
            BallsLabel.Name = "BallsLabel";
            BallsLabel.Size = new Size(105, 35);
            BallsLabel.TabIndex = 6;
            BallsLabel.Text = "BALLS:";
            // 
            // BallsTextBox
            // 
            BallsTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BallsTextBox.BackColor = Color.White;
            BallsTextBox.Enabled = false;
            BallsTextBox.Font = new Font("Showcard Gothic", 16F, FontStyle.Italic);
            BallsTextBox.Location = new Point(507, 375);
            BallsTextBox.Name = "BallsTextBox";
            BallsTextBox.Size = new Size(125, 41);
            BallsTextBox.TabIndex = 7;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 451);
            Controls.Add(BallsTextBox);
            Controls.Add(BallsLabel);
            Controls.Add(ScoreTextBox);
            Controls.Add(ScoreLabel);
            Controls.Add(HealthLabel);
            Controls.Add(GameBoard);
            Controls.Add(BackToMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form2";
            Text = "BRI(EA)CK OR DIE";
            KeyDown += Form2_KeyDown;
            ((System.ComponentModel.ISupportInitialize)GameBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackToMenu;
        public PictureBox GameBoard;
        public Label HealthLabel;
        public Label ScoreLabel;
        public TextBox ScoreTextBox;
        private System.Windows.Forms.Timer timer1;
        public Label BallsLabel;
        public TextBox BallsTextBox;
    }
}