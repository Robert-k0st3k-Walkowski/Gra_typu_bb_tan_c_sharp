using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace project
{
    public partial class Form3 : Form

    {
        // Deklaracja (oraz też ewentaulna definicja) pól klasy "Form3", która odpowiada za wyświetlanie okna opcji gry.

        Form1 givenMainMenu;

        SoundPlayer bbTanThemeMusicPlayer = new SoundPlayer("./../../../../music/bbtan-theme-song.wav");

        public Form3(Form1 MainMenu)
        {
            InitializeComponent();

            // Przekazanie okien do konstruktora okna opcji

            givenMainMenu = MainMenu;

            // Ustawienia startowe okna

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Size = new Size(this.ClientSize.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.BackColor = Color.White;

            // Domyślne ustawienia przycisków opcji

            LightThemeRadioButton.Checked = true;
            MusicOffRadioButton.Checked = true;
            easyRadioButton.Checked = true;

            // Domyślne ustawienia pozycji elementów tego okna (groupboxów, etykiet itd.)

            ThemeOptionLabel.Location = new Point(ThemeOptionLabel.Width / 4, 200);

            ThemeGroupBox.Location = new Point(ThemeOptionLabel.Location.X, 270);
            ThemeGroupBox.Size = new Size(ThemeOptionLabel.Width, 80);

            MusicOptionLabel.Location = new Point(ThemeOptionLabel.Width / 2, (this.ClientSize.Height / 2) - 170);

            MusicGroupBox.Location = new Point(MusicOptionLabel.Location.X, (this.ClientSize.Height / 2) - 100);
            MusicGroupBox.Size = new Size(MusicOptionLabel.Width, 80);

            difficultyOptionLabel.Location =
                new Point(ThemeOptionLabel.Width / 3 + 35, (this.ClientSize.Height / 2) + 10);

            difficultyGroupBox.Location =
                new Point(difficultyOptionLabel.Location.X, (this.ClientSize.Height / 2) + 70);
            difficultyGroupBox.Size = new Size(difficultyOptionLabel.Width, 110);

            // Ustawienia przycisku powrotu do menu gry

            BackToMenuOption.Size = new Size(200, 80);
            BackToMenuOption.Location = new Point(20, this.ClientSize.Height - BackToMenuOption.Size.Height - 80);
            BackToMenuOption.FlatStyle = FlatStyle.Flat;
            BackToMenuOption.FlatAppearance.BorderSize = 1;
            BackToMenuOption.FlatAppearance.BorderColor = Color.Black;
            BackToMenuOption.BackColor = Color.White;
        }

        // Ustawienia zdarzenia zmiany stanu przycisku "DarkThemeRadioButton", który zmienia kolor tła wszystkich okien na czarne,
        // a kolor wszystkich napisów w oknach na biały.

        private void DarkThemeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DarkThemeRadioButton.Checked == true)
            {
                givenMainMenu.darkThemeState = true;

                this.BackColor = Color.Black;
                this.ThemeOptionLabel.ForeColor = Color.White;
                this.ThemeGroupBox.BackColor = Color.White;
                this.MusicGroupBox.BackColor = Color.White;
                this.MusicOptionLabel.ForeColor = Color.White;
                this.difficultyOptionLabel.ForeColor = Color.White;
                this.difficultyGroupBox.BackColor = Color.White;

                givenMainMenu.BackColor = Color.Black;
                givenMainMenu.GameTitle.ForeColor = Color.White;
            }
        }

        // Ustawienia zdarzenia zmiany stanu przycisku "LightThemeRadioButton", który zmienia kolor tła wszystkich okien na białe,
        // a kolor wszystkich napisów w oknach na czarny.

        private void LightThemeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LightThemeRadioButton.Checked == true)
            {
                givenMainMenu.darkThemeState = false;

                this.BackColor = Color.White;
                this.ThemeOptionLabel.ForeColor = Color.Black;
                this.ThemeGroupBox.BackColor = Color.White;
                this.MusicOptionLabel.ForeColor = Color.Black;
                this.MusicGroupBox.BackColor = Color.White;

                givenMainMenu.BackColor = Color.White;
                givenMainMenu.GameTitle.ForeColor = Color.Black;
            }
        }

        // Ustawienia zdarzenia zmiany stanu przycisku "MusicOnRadioButton", który włącza główną muzykę gry (zapętloną).

        private void MusicOnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MusicOnRadioButton.Checked)
            {
                bbTanThemeMusicPlayer.PlayLooping();
            }
        }

        // Ustawienia zdarzenia zmiany stanu przycisku "MusicOffRadioButton", który wyłącza główną muzykę gry.

        private void MusicOffRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MusicOffRadioButton.Checked)
            {
                bbTanThemeMusicPlayer.Stop();
            }
        }

        // Ustawienia zdarzenia najechania myszą na przycisk "BackToMenuOption", który zmienia kolor tła tego przycisku na czerwony.

        private void BackToMenuOption_MouseMove(object sender, MouseEventArgs e)
        {
            BackToMenuOption.BackColor = Color.Red;
        }

        // Ustawienia zdarzenia "zjechania" myszą z przycisku "BackToMenuOption", który zmienia kolor tła tego przycisku na biały.

        private void BackToMenuOption_MouseLeave(object sender, EventArgs e)
        {
            BackToMenuOption.BackColor = Color.White;
        }

        // Ustawienia zmiany stanu przycisku "easyRadioButton",
        // który ustawia wartość zmiennej "givenMainMenu.whichDifficulty" na "Form1.difficultyModes.easy".

        private void easyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (easyRadioButton.Checked == true)
            {
                givenMainMenu.whichDifficulty = Form1.difficultyModes.easy;
            }
        }

        // Ustawienia zmiany stanu przycisku "mediumRadioButton",
        // który ustawia wartość zmiennej "givenMainMenu.whichDifficulty" na "Form1.difficultyModes.medium".

        private void mediumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (mediumRadioButton.Checked == true)
            {
                givenMainMenu.whichDifficulty = Form1.difficultyModes.medium;
            }
        }

        // Ustawienia zmiany stanu przycisku "hardRadioButton",
        // który ustawia wartość zmiennej "givenMainMenu.whichDifficulty" na "Form1.difficultyModes.hard".

        private void hardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (hardRadioButton.Checked == true)
            {
                givenMainMenu.whichDifficulty = Form1.difficultyModes.hard;
            }
        }

        // Ustawienia zdarzenia naciśnięcia przycisku "BackToMenuOption", który zamyka to okno i wraca do okna typu "Form1".
        private void BackToMenuOption_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}