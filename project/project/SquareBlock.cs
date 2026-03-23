using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    // Klasa "SquareBlock" implementująca interfejs "Block".

    public class SquareBlock : IBlock
    {
        // Deklaracja (oraz ewentualna definicja) pól tej klasy.

        Form2 GameWindow;
        
        Point SquareStartingPoint;
        Color SquareColor;
        int SquareHeight;
        int SquareWidth;
        
        List<Color> AvailableColors = new List<Color>();

        int margin = 10;

        // Konstruktor klasy "SquareBlock", która przyjmuje jako argument obiekt klasy "Form2" i przypisuje wartości odpowiednim zmiennym.

        public SquareBlock(Form2 GivenWindow)
        {
            Random r = new Random();

            GameWindow = GivenWindow;

            SquareHeight = 50;
            SquareWidth = 50;

            AvailableColors.Add(Color.Green);
            AvailableColors.Add(Color.Yellow);
            AvailableColors.Add(Color.Orange);
            AvailableColors.Add(Color.Red);

            SquareColor = AvailableColors.ElementAt(r.Next(0,4));

            Durability = AvailableColors.IndexOf(SquareColor) + 1;
        }

        // Seria właściwości klasy "SquareBlock", które odpowiadają za np.:
        // Uzyskanie pozycji początkowej bloku (zwraca 'point'),
        // Uzyskanie wytrzymałości danego bloku (zwraca 'int'),
        // itd.

        public Point GetStartingPoint
        {
            get { return this.SquareStartingPoint; }
        }
        public int GetSquareHeight
        {
            get { return this.SquareHeight; }
        }
        public int GetSquareWidth
        {
            get { return this.SquareWidth; }
        }
        public int Durability
        { 
            get;
            
            set;
        }

        // Metoda "GeneratingPosition", która przyjmuje jako argument listę zawierającą 'inty' i
        // odpowiada za generowanie pozycji poszczególnych bloków (w "losowych" miejscach).

        public void GeneratingPosition(List<int> availableSlots)
        {
            Random rand = new Random();
            
            int slotIndex;

            int slotListIndex = rand.Next(availableSlots.Count);
            slotIndex = availableSlots[slotListIndex];
            availableSlots.RemoveAt(slotListIndex);

            int x = margin + slotIndex * (SquareWidth + margin);
            int y = 10;

            this.SquareStartingPoint = new Point(x, y);
        }

        // Metoda "MoveDown", która odpowiada za przenoszenie starej linii bloków w dół
        // o odpowiedni margines, po wygenerowaniu nowej linii bloków nad nią.

        public void MoveDown()
        {
            SquareStartingPoint = new Point(SquareStartingPoint.X, SquareStartingPoint.Y + SquareHeight + margin);
        }

        // Metoda "DrawingBlock", która przyjmuje jako argument obiekt klasy "PaintEventArgs" i
        // odpowiada za rysowanie tych bloków na planszy oraz narysowanie na nich ich wytrzymałości.

        public void DrawingBlock(PaintEventArgs ePaint)
        {
            SolidBrush SquareBrush = new SolidBrush(SquareColor);

            Size SquareSize = new Size(SquareWidth, SquareHeight);
            Rectangle Square = new Rectangle(SquareStartingPoint, SquareSize);

            ePaint.Graphics.FillRectangle(SquareBrush, Square);

            string durabilityText = Durability.ToString();
            
            var font = new Font("Arial", 16, FontStyle.Bold);
            var textSize = ePaint.Graphics.MeasureString(durabilityText, font);
            var textX = SquareStartingPoint.X + (SquareWidth - textSize.Width) / 2;
            var textY = SquareStartingPoint.Y + (SquareHeight - textSize.Height) / 2;
            
            ePaint.Graphics.DrawString(durabilityText, font, Brushes.Black, textX, textY);
        }

        // Metoda "ColorChanging", która odpowiada za zmiane koloru danego bloku
        // (który został uderzony przez kulkę).

        public void ColorChanging()
        {
            int currentIndex = AvailableColors.IndexOf(SquareColor);

            if (currentIndex > 0)
            {
                SquareColor = AvailableColors[currentIndex - 1];
            }
        }
    }
}
