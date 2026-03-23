using System.Linq.Expressions;

namespace project
{
    public partial class Form1 : Form
    {
        // Deklaracja (oraz dla niektórych pocz¹tkowa definicja ich wartoœci) pól klasy "Form1", która odpowiada za wyœwietlanie okna g³ównego menu
        // (niektóre publiczne ze wzglêdu na zapotrzebowanie w innych miejscach programu).

        Form2 ActualGame;
        Form3 OptionsForm;
        
        public bool darkThemeState = false;

        public enum difficultyModes { easy, medium, hard }
        public difficultyModes whichDifficulty;

        public Form1()
        {
            InitializeComponent();

            // Pocz¹tkowe ustawienia okna

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(this.ClientSize.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.BackColor = Color.White;

            // Ustawienia obrazków w menu g³ównym gry

            PictureBox skullImage = new PictureBox();

            skullImage.Image = Image.FromFile("./../../../../images/Skull-and-Crossbones-white-png.png");
            skullImage.Location = new Point(this.ClientSize.Width - 260, this.ClientSize.Height - 520);
            skullImage.Size = new Size(240, 240);
            skullImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(skullImage);

            PictureBox BulletImage = new PictureBox();

            BulletImage.Image = Image.FromFile("./../../../../images/bullet-png-transparent.png");
            BulletImage.Location = new Point(this.ClientSize.Width - 260, 150);
            BulletImage.Size = new Size(280, 280);
            BulletImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(BulletImage);

            PictureBox wallOfBricksImage = new PictureBox();

            wallOfBricksImage.Image = Image.FromFile("./../../../../images/brick-wall-png.png");
            wallOfBricksImage.Location = new Point(0, 300);
            wallOfBricksImage.Size = new Size(260, 260);
            wallOfBricksImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(wallOfBricksImage);

            PictureBox xMarkImage = new PictureBox();

            xMarkImage.Image = Image.FromFile("./../../../../images/x-mark-png-transparent.png");
            xMarkImage.Location = new Point(0, this.ClientSize.Height - 350);
            xMarkImage.Size = new Size(240, 240);
            xMarkImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(xMarkImage);

            // Komendy odpowiadaj¹ce za tytu³ gry

            GameTitle.Location = new Point((this.ClientSize.Width - GameTitle.Width) / 2, 40);
            GameTitle.ForeColor = Color.Black;

            // Komendy odpowiadaj¹ce za dostosowanie guzików i ich wygl¹du

            StartGame.Size = new Size(300, 150);
            Options.Size = Exit.Size = StartGame.Size;

            StartGame.Location = new Point((this.ClientSize.Width - StartGame.Width) / 2, this.ClientSize.Height / 6);
            Options.Location = new Point((this.ClientSize.Width - StartGame.Width) / 2, (this.ClientSize.Height / 6) + (2 * StartGame.Height));
            Exit.Location = new Point((this.ClientSize.Width - StartGame.Width) / 2, (this.ClientSize.Height / 6) + (4 * StartGame.Height));
        }

        // Ustawienie zdarzenia naciœniêcia przycisku "Exit", po którym pojawia siê stosowny komunikat o opuszczeniu gry i zamkniêciu ca³ej aplikacji.

        private void Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked the 'Exit' button. Thank you and see you next time!",
                            "Exit",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            this.Close();
        }

        // Ustawienie zdarzenia najechania mysz¹ na przycisk "StartGame" (zmienia kolor na zielony).

        private void StartGame_MouseMove(object sender, MouseEventArgs e)
        {
            StartGame.BackColor = Color.LimeGreen;
        }

        // Ustawienie zdarzenia "zjechania" mysz¹ z przycisku "StartGame" (zmienia kolor na bia³y).

        private void StartGame_MouseLeave(object sender, EventArgs e)
        {
            StartGame.BackColor = Color.White;
        }

        // Ustawienie zdarzenia najechania mysz¹ na przycisk "Options" (zmienia kolor na ¿ó³ty).

        private void Options_MouseMove(object sender, MouseEventArgs e)
        {
            Options.BackColor = Color.Yellow;
        }

        // Ustawienie zdarzenia "zjechania" mysz¹ z przycisku "Options" (zmienia kolor na bia³y).

        private void Options_MouseLeave(object sender, EventArgs e)
        {
            Options.BackColor = Color.White;
        }

        // Ustawienie zdarzenia najechania mysz¹ na przycisk "Exit" (zmienia kolor na czerwony).

        private void Exit_MouseMove(object sender, MouseEventArgs e)
        {
            Exit.BackColor = Color.Red;
        }

        // Ustawienie zdarzenia "zjechania" mysz¹ z przycisku "Exit" (zmienia kolor na bia³y).

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.BackColor = Color.White;
        }

        // Ustawienie zdarzenia wciœniêcia przycisku "StartGame" (odpala okno typu "Form2" i ustawia wartoœæ zmiennej "useDarkTheme").

        private void StartGame_Click(object sender, EventArgs e)
        {
            bool useDarkTheme = darkThemeState;
            ActualGame = new Form2(useDarkTheme, whichDifficulty);
            this.Hide();
            ActualGame.ShowDialog();
            this.Show();
        }

        // Ustawienie zdarzenia wciœniêcia przycisku "Options" (odpala okno typu "Form3").

        private void Options_Click(object sender, EventArgs e)
        {
            OptionsForm = new Form3(this);
            this.Hide();
            OptionsForm.ShowDialog();
            this.Show();
        }
    }
}
