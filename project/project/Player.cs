using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Player
    {
        // Deklaracja (oraz ewentalnie definicja) pól klasy "Player"
        // oraz zainicjowanie enuma odpowiadającego za dostępne ruchy dla gracza w danym momencie.

        Rectangle PlayerCircle;
        int CircleX;
        int CircleY;
        int vx = 5;

        float BarrelAngle = 0F;


        Form2 GameWindow;

        float lastBallHitX = -1;

        List<Ball> PlayerBalls;
        int ballsToShoot = 1;
        int ballsHitBottom = 0;

        Random generatingNewLineOfBlocks;

        bool waitingForBalls = false;

        int score = 0;

        List<PictureBox> playerHeartsList;

        // Konstruktor klasy "Player", która przyjmuje jako argument okno typu "Form2"
        // i przypisuje początkowe wartości niektórym polom.

        public Player(Form2 GivenPlayerWindow)
        {
            GameWindow = GivenPlayerWindow;

            this.CircleX = (GameWindow.GameBoard.Width / 2);
            this.CircleY = GameWindow.GameBoard.Height - 62;

            PlayerBalls = new List<Ball>();

            generatingNewLineOfBlocks = new Random();
        }

        // Właściowści klasy "Player", które odpowiadają za:
        // Otrzymanie pozycji "X" gracza (zwraca 'int'),
        // Otrzymanie pozycji "Y" gracza (zwraca 'int'),
        // itd.

        public int XPositionGetter
        {
            get { return this.CircleX; }
        }

        public int YPositionGetter
        {
            get { return this.CircleY; }
        }

        public int amountOfBallsToShoot
        {
            get { return this.ballsToShoot; }
        }

        public List<PictureBox> getPlayerHearts
        {
            get { return this.playerHeartsList; }
        }

        public int getScore
        {
            get { return this.score; }
        }

        // Metoda typu "DrawPlayerModel", która jako argument przyjmuje obiekt typu "PaintEventArgs" i
        // Odpowiada za narysowanie całego modelu gracza oraz kulek w odpowiednim miejscu
        // (niewidoczne dla gracza przed wystrzeleniem).

        public void DrawPlayerModel(PaintEventArgs ePaint)
        {
            SolidBrush solidBrushCircle = new SolidBrush(Color.DarkGreen);
            SolidBrush solidBrushRectangle = new SolidBrush(Color.Black);

            PlayerCircle = new Rectangle(this.CircleX, this.CircleY, 60, 60);

            float BaseX = this.CircleX + PlayerCircle.Width / 2;
            float BaseY = this.CircleY + PlayerCircle.Height / 2;

            var OldTransform = ePaint.Graphics.Transform.Clone();

            ePaint.Graphics.TranslateTransform(BaseX, BaseY);
            ePaint.Graphics.RotateTransform(BarrelAngle);
            ePaint.Graphics.FillRectangle(solidBrushRectangle, -10, -65, 20, 50);
            ePaint.Graphics.Transform = OldTransform;

            foreach (var ball in PlayerBalls)
            {
                ePaint.Graphics.FillEllipse(solidBrushRectangle, ball.GetNewBall());
            }

            ePaint.Graphics.FillEllipse(solidBrushCircle, PlayerCircle);
        }

        // Metoda "DrwaDirectionDots", która jako agrument przyjmuje obiekt klasy "PaintEventArgs",
        // która odpowiada za rysowanie oraz poruszanie się kropek zgodnie z tym, jak zachowuje się lufa gracza.

        public void DrawDirectionDots(PaintEventArgs ePaint)
        {
            using (Pen DotPen = new Pen(Color.Black, 2))
            {
                float baseX = this.CircleX + PlayerCircle.Width / 2;
                float baseY = this.CircleY + PlayerCircle.Height / 2;

                float angleRad = BarrelAngle * (float)Math.PI / 180f;

                for (int i = 1; i <= 5; i++)
                {
                    float distance = 65 + i * 50;
                    float dotX = baseX + (float)Math.Sin(angleRad) * distance;
                    float dotY = baseY - (float)Math.Cos(angleRad) * distance;

                    ePaint.Graphics.DrawEllipse(DotPen, dotX - 2, dotY - 2, 5, 5);
                }
            }
        }

        // Metoda "BarrelMovingLogic", która jako argument przyjmuje obiekt typu "KeyEventArgs" i
        // odpowiada za ruch "lufy" postaci gracza.

        public void BarrelMovingLogic(KeyEventArgs eKey)
        {
            if (eKey.KeyCode == Keys.Q)
            {
                BarrelAngle -= 5F;

                if (BarrelAngle <= -90.0F)
                {
                    BarrelAngle = -90.0F;
                }
            }

            if (eKey.KeyCode == Keys.E)
            {
                BarrelAngle += 5F;

                if (BarrelAngle >= 90.0F)
                {
                    BarrelAngle = 90.0F;
                }
            }
        }

        // Metoda "UpdateMovement", która nie przyjmuje żadnych argumentów i
        // odpowiada za odświeżanie umiejscowienia modelu gracza (zależne od miejsca upadu kulki).

        public void UpdateMovement()
        {
            int leftBound = 0;
            int rightBound = GameWindow.GameBoard.Width - PlayerCircle.Width;

            if (lastBallHitX >= 0)
            {
                CircleX = (int)lastBallHitX - PlayerCircle.Width / 2;


                if (CircleX < leftBound)
                    CircleX = leftBound;
                if (CircleX > rightBound)
                    CircleX = rightBound;

                lastBallHitX = -1;
                return;
            }
        }

        // Metoda "CreateAndPositionBall", która nie przyjmuje żadnych argumentów i
        // odpowiada za umiejscowienie kulki w miejscu lufy
        // (musi znajdować się tutaj przez wzgląd na specyfikę działania lufy).

        public void CreateAndPositionBall()
        {
            float barrelLength = 65f;
            float centerX = PlayerCircle.Width / 2;
            float centerY = PlayerCircle.Height / 2;

            float angleRad = BarrelAngle * (float)Math.PI / 180f;
            float tipX = CircleX + centerX + (float)Math.Sin(angleRad) * barrelLength;
            float tipY = CircleY + centerY - (float)Math.Cos(angleRad) * barrelLength;

            float speed = 8f;
            float vx = (float)Math.Sin(angleRad) * speed;
            float vy = -(float)Math.Cos(angleRad) * speed;

            if (PlayerBalls.Count < ballsToShoot)
            {
                PlayerBalls.Add(new Ball(tipX - 10, tipY - 10, vx, vy));
                waitingForBalls = true;
            }
        }

        // Metoda "ShootingPlayerLogic", która jako argumenty przyjmuje dwa obiekty:
        // Pierwszy - lista elemntów typu interfejs "Block"
        // Druga - zmienna typu "Form1.difficultyModes" (enum).
        // Odpowiada za całą logikę poruszania się kulki i zdarzenia związane z nią
        // (np. co się stanie gdy dotknie bocznych krawędzi, uderzy w bloczek itd.).

        public void ShootingPlayerLogic(List<IBlock> blocks, Form1.difficultyModes chosenDifficulty)
        {
            int left = 0;
            int top = 0;
            int right = GameWindow.GameBoard.Width;
            int bottom = GameWindow.GameBoard.Height;

            for (int i = PlayerBalls.Count - 1; i >= 0; i--)
            {
                var ball = PlayerBalls[i];
                ball.GetX += ball.GetVX;
                ball.GetY += ball.GetVY;

                if (ball.GetX <= left)
                {
                    ball.GetX = left;
                    ball.GetVX = -ball.GetVX;
                }

                if (ball.GetX + ball.GetSize >= right)
                {
                    ball.GetX = right - ball.GetSize;
                    ball.GetVX = -ball.GetVX;
                }

                if (ball.GetY + ball.GetSize <= top)
                {
                    ball.GetY = top - ball.GetSize;
                    ball.GetVY = -ball.GetVY;
                }

                if (ball.GetY + ball.GetSize >= bottom)
                {
                    lastBallHitX = ball.GetX + ball.GetSize / 2;

                    PlayerBalls.RemoveAt(i);
                    ballsHitBottom++;

                    if (ballsHitBottom >= ballsToShoot)
                    {
                        ballsToShoot++;


                        ballsHitBottom = 0;
                    }
                }
            }

            for (int b = blocks.Count - 1; b >= 0; b--)
            {
                if (blocks[b] is SquareBlock sqBlock)
                {
                    Rectangle blockRect = new Rectangle(sqBlock.GetStartingPoint,
                        new Size(sqBlock.GetSquareWidth, sqBlock.GetSquareHeight));

                    foreach (var ball in PlayerBalls)
                    {
                        if (ball.GetNewBall().IntersectsWith(blockRect))
                        {
                            score += 50;

                            ball.GetVY = -ball.GetVY;

                            sqBlock.Durability--;

                            sqBlock.ColorChanging();

                            if (sqBlock.Durability <= 0)
                            {
                                blocks.RemoveAt(b);
                                break;
                            }

                            break;
                        }
                    }
                }

                else if (blocks[b] is TriangleBlock trBlock)
                {
                    Rectangle triangleRect = new Rectangle(trBlock.GetStartingPoint.X, trBlock.GetStartingPoint.Y,
                        trBlock.GetTriangleWidth, trBlock.GetTriangleHeight);

                    foreach (var ball in PlayerBalls)
                    {
                        Rectangle ballRec = new Rectangle((int)ball.GetX, (int)ball.GetY, 20, 20);

                        if (trBlock.BallIntersectsTriangle(ballRec, triangleRect))
                        {
                            score += 50;

                            ball.GetVY = -ball.GetVY;

                            trBlock.Durability--;

                            trBlock.ColorChanging();

                            if (trBlock.Durability <= 0)
                            {
                                blocks.RemoveAt(b);
                                break;
                            }

                            break;
                        }
                    }
                }
            }

            GameWindow.ScoreTextBox.Text = score.ToString();
        }

        // Metoda "ShootingPlayerLogic", która jako argumenty przyjmuje dwa obiekty:
        // Pierwszy - lista elemntów typu interfejs "Block"
        // Druga - zmienna typu "Form1.difficultyModes" (enum).
        // Odpowiada za generowanie nowych bloków po tym, jak wszystkie wystrzelone kulki dotką dołu planszy.

        public void GenerateNewBlocksLine(List<IBlock> blocks, Form1.difficultyModes chosenDifficulty)
        {
            Random whichBlock = new Random();

            if (PlayerBalls.Count == 0 && waitingForBalls)
            {
                foreach (var block in blocks)
                {
                    if (block is SquareBlock sqBlock)
                    {
                        if (sqBlock != null)
                            sqBlock.MoveDown();
                    }
                    else if (block is TriangleBlock trBlock)
                    {
                        if (trBlock != null)
                            trBlock.MoveDown();
                    }
                }

                int newBlocksCount = 0;

                switch (chosenDifficulty)
                {
                    case Form1.difficultyModes.easy:
                        newBlocksCount = generatingNewLineOfBlocks.Next(1, 7);
                        break;
                    case Form1.difficultyModes.medium:
                        newBlocksCount = generatingNewLineOfBlocks.Next(7, 13);
                        break;
                    case Form1.difficultyModes.hard:
                        newBlocksCount = generatingNewLineOfBlocks.Next(10, 13);
                        break;
                    default:
                        newBlocksCount = generatingNewLineOfBlocks.Next(1, 13);
                        break;
                }

                List<int> availableSlots = new List<int>(12);

                for (int j = 0; j < availableSlots.Capacity; j++)
                {
                    availableSlots.Add(j);
                }

                for (int k = 0; k < newBlocksCount; k++)
                {
                    IBlock newBlock;

                    if (whichBlock.Next(0, 2) == 0)
                    {
                        newBlock = new SquareBlock(GameWindow);
                    }
                    else
                    {
                        newBlock = new TriangleBlock(GameWindow);
                    }

                    newBlock.GeneratingPosition(availableSlots);

                    blocks.Add(newBlock);
                }

                waitingForBalls = false;
            }
        }

        // Metoda "drawPlayerHearts" nie przyjmująca żadnych argumentów i odpowiada za
        // wygenerowanie nowej listy przechowującej elementy klasy "PictureBox" i wyświetlenie obrazka z pliku.

        public void drawPlayerHearts()
        {
            playerHeartsList = new List<PictureBox>(3);

            for (int i = 0; i < playerHeartsList.Capacity; i++)
            {
                playerHeartsList.Add(new PictureBox());

                playerHeartsList[i].Image = Image.FromFile("./../../../../images/life-heart-png-transparent.png");
                playerHeartsList[i].Location = new Point(GameWindow.HealthLabel.Location.X + 70 * i,
                    GameWindow.ScoreTextBox.Location.Y);
                playerHeartsList[i].Size = new Size(70, 70);
                playerHeartsList[i].SizeMode = PictureBoxSizeMode.StretchImage;
                GameWindow.Controls.Add(playerHeartsList[i]);
            }
        }

        // Metoda "heartTakichCheck", przyjmująca jako argument listę z elementami typu interfejs "Block" i
        // która zabiera jedno serduszko graczowi za każdy blok, który dotknie dolnej krawędzi planszy.

        public void heartTakingCheck(List<IBlock> blocks)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i] is SquareBlock sqBlock)
                {
                    if (sqBlock != null && sqBlock.GetStartingPoint.Y >= GameWindow.GameBoard.Height)
                    {
                        if (playerHeartsList.Count > 0)
                        {
                            GameWindow.Controls.Remove(playerHeartsList[playerHeartsList.Count - 1]);
                            playerHeartsList.RemoveAt(playerHeartsList.Count - 1);
                        }

                        blocks.RemoveAt(i);

                        break;
                    }
                }
                else if (blocks[i] is TriangleBlock trBlock)
                {
                    if (trBlock != null && trBlock.GetStartingPoint.Y >= GameWindow.GameBoard.Height)
                    {
                        if (playerHeartsList.Count > 0)
                        {
                            GameWindow.Controls.Remove(playerHeartsList[playerHeartsList.Count - 1]);
                            playerHeartsList.RemoveAt(playerHeartsList.Count - 1);
                        }

                        blocks.RemoveAt(i);

                        break;
                    }
                }
            }
        }
    }
}