using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        // Deklaracja (oraz ewentualna definicja) pól klasy "Form2", która odpowiada za wyświetlanie głównej gry.

        Player CreatedPlayer;

        GameOver GameOver;

        List<IBlock> Blocks;

        Random startingAmountOfBlocks;
        Random whichKindOfBlock = new Random();

        Form1.difficultyModes chosenDifficultyVar;
        public Form2(bool useDarkTheme, Form1.difficultyModes chosenDifficulty)
        {
            InitializeComponent();

            // Warunek "if" sprawdzający, czy zastosowano ciemny motyw dla gry.

            if (useDarkTheme)
            {
                this.BackColor = Color.Black;
                HealthLabel.ForeColor = Color.White;
                ScoreLabel.ForeColor = Color.White;
                BallsLabel.ForeColor = Color.White;
            }

            // Odpalenie timera (dla upłynnienia ruchu kulek oraz ruchu gracza).

            timer1.Start();

            // Początkowe ustawienia okna.

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Size = new Size(this.ClientSize.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            // Warunek "if" sprawdzający, czy użytkownik użył jasnego motywu gry.

            if (!useDarkTheme)
            {
                this.BackColor = Color.White;
            }

            // Ustawienie planszy do gry.

            GameBoard.BackColor = Color.DarkGray;
            GameBoard.Width = this.Width - 30;
            GameBoard.Location = new Point((this.ClientSize.Width - GameBoard.Width) / 2, 150);
            GameBoard.BorderStyle = BorderStyle.FixedSingle;

            // Ustawienie przycisku do powrotu do menu oraz wysokości okna planszy zależnej od właściwości "BackToMenu.Top".

            BackToMenu.Size = new Size(200, 80);
            BackToMenu.Location = new Point(20, this.ClientSize.Height - BackToMenu.Size.Height - 80);
            BackToMenu.FlatStyle = FlatStyle.Flat;
            BackToMenu.FlatAppearance.BorderSize = 1;
            BackToMenu.FlatAppearance.BorderColor = Color.Black;
            BackToMenu.BackColor = Color.White;

            GameBoard.Height = BackToMenu.Top - GameBoard.Top - 20;

            // Ustawienie początkowe wyniku gracza.

            ScoreTextBox.Text = "0";
            ScoreTextBox.BackColor = Color.White;

            // Zainicjowanie gracza i jego akcji.

            CreatedPlayer = new Player(this);

            // Zainicjowanie listy przechowującej bloki (ilość bloków zależna od wybranego poziomu trudności).

            startingAmountOfBlocks = new Random();

            chosenDifficultyVar = chosenDifficulty;

            int blockCount;
            
            switch (chosenDifficulty)
            {
                case Form1.difficultyModes.easy:
                    blockCount = startingAmountOfBlocks.Next(1, 7);
                    break;
                case Form1.difficultyModes.medium:
                    blockCount = startingAmountOfBlocks.Next(7, 13);
                    break;
                case Form1.difficultyModes.hard:
                    blockCount = startingAmountOfBlocks.Next(10, 13);
                    break;
                default:
                    blockCount = startingAmountOfBlocks.Next(1, 13);
                    break;
            }

            Blocks = new List<IBlock>(blockCount);

            List<int> availableSlots = new List<int>(blockCount);

            for (int j = 0; j < availableSlots.Capacity; j++)
            {
                availableSlots.Add(j);
            }

            for (int i = 0; i < blockCount; i++)
            {
                IBlock block;

                if (whichKindOfBlock.Next(0,2) == 0)
                {
                    block = new SquareBlock(this);
                }
                else
                {
                    block = new TriangleBlock(this);
                }

                block.GeneratingPosition(availableSlots);
                
                Blocks.Add(block);
            }

            // Ustawienie pozycji napisu oraz "Textboxa" przechowującego liczbę kulek.

            BallsTextBox.Location = new Point(this.ClientSize.Width - BallsTextBox.Width - 8, this.ClientSize.Height - BallsTextBox.Size.Height - (120 - BallsLabel.Size.Height));
            BallsLabel.Location = new Point(BallsTextBox.Location.X, this.ClientSize.Height - BallsLabel.Size.Height - 130);

            // Załadowanie serduszek gracza.

            CreatedPlayer.drawPlayerHearts();

            // Zainicjowanie klasy sprawdzającej koniec gry.

            GameOver = new GameOver(CreatedPlayer.getPlayerHearts, false, this);

        }

        // Ustawienia zdarzenia najechania myszą na przycisk "BackToMenu", który zmienia kolor tła tego przycisku na czerwony.

        private void BackToMenu_MouseMove(object sender, MouseEventArgs e)
        {
            BackToMenu.BackColor = Color.Red;
        }

        // Ustawienia zdarzenia "zjechania" myszą z przycisku "BackToMenu", który zmienia kolor tła tego przycisku na biały.

        private void BackToMenu_MouseLeave(object sender, EventArgs e)
        {
            BackToMenu.BackColor = Color.White;
        }

        // Ustawienie zdarzenia "Paint" dla "GameBoard", który rysuje model gracza oraz wygenerowane bloki.

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            CreatedPlayer.DrawPlayerModel(e);

            foreach (var Block in Blocks)
            {
                Block.DrawingBlock(e);
            }

            CreatedPlayer.DrawDirectionDots(e);
        }

        // Ustawienie zdarzenia naciśnięcia przycisku dla całego "Form2",
        // który odpowiada za: B - generowanie i początkowe pozycjonowanie kulki)
        // oraz odpowiada za logikę poruszania lufą gracza.

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B)
            {
                CreatedPlayer.CreateAndPositionBall();
            }

            CreatedPlayer.BarrelMovingLogic(e);
        }

        // Ustawienie zdarzenia naciśnięcia przycisku "BackToMenu", który wyłącza okno gry (Form2) i wraca do okna głównego menu (Form1).

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Ustawienie zdarzenia jednego 'ticku' timera, a ten za każdym tickiem:
        // zmienia położenie gracza, wywołuje logię strzelania, odświeża planszę gry,
        // zabiera serduszko graczowi, zmienia ilość dostępnych serduszek i sprawdza, czy gra powinna zostać przerwana.

        private void timer1_Tick(object sender, EventArgs e)
        {
            CreatedPlayer.UpdateMovement();
            CreatedPlayer.ShootingPlayerLogic(Blocks, chosenDifficultyVar);
            CreatedPlayer.GenerateNewBlocksLine(Blocks, chosenDifficultyVar);

            GameBoard.Invalidate();

            CreatedPlayer.heartTakingCheck(Blocks);

            BallsTextBox.Text = CreatedPlayer.amountOfBallsToShoot.ToString();

            GameOver.isGameOver(CreatedPlayer.getScore);
        }
    }
}
