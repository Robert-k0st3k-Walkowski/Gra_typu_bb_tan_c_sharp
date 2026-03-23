using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    // Klasa "TriangleBlock" implementująca interfejs "Block" (działa bardzo podobnie do klasy 'SquareBlock').

    public class TriangleBlock : IBlock
    {
        // Deklaracja (oraz ewentualnie definicja) pól tej klasy.

        Form2 GameWindow;

        Point TriangleStartingPoint;
        Point[] trianglePoints = new Point[3];
        Color TriangleColor;
        int TriangleHeight;
        int TriangleWidth;

        List<Color> AvailableColors = new List<Color>();

        int margin = 10;

        // Konstruktor klasy, który jako argument przyjmuje obiekt klasy "Form2" (właściwe okno gry).

        public TriangleBlock(Form2 GivenWindow)
        {
            Random r = new Random();

            GameWindow = GivenWindow;

            TriangleHeight = 50;
            TriangleWidth = 50;

            AvailableColors.Add(Color.Green);
            AvailableColors.Add(Color.Yellow);
            AvailableColors.Add(Color.Orange);
            AvailableColors.Add(Color.Red);

            TriangleColor = AvailableColors.ElementAt(r.Next(0, 4));

            Durability = AvailableColors.IndexOf(TriangleColor) + 1;
        }

        // Właściwości klasy "TriangleBlock", które odpowiadają za:
        // Pozyskanie punktu startowego (typ 'Point')
        // Pozyskanie wytrzymałości bloku (typ 'int')
        // itd.

        public Point GetStartingPoint
        {
            get { return this.TriangleStartingPoint; }
        }
        public int GetTriangleHeight
        {
            get { return this.TriangleHeight; }
        }
        public int GetTriangleWidth
        {
            get { return this.TriangleWidth; }
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

            int x = margin + slotIndex * (TriangleWidth + margin);
            int y = 10;

            this.TriangleStartingPoint = new Point(x, y);
        }

        // Metoda "MoveDown", która odpowiada za przenoszenie starej linii bloków w dół
        // o odpowiedni margines, po wygenerowaniu nowej linii bloków nad nią.

        public void MoveDown()
        {
            TriangleStartingPoint = new Point(TriangleStartingPoint.X, TriangleStartingPoint.Y + TriangleHeight + margin);
        }

        // Metoda "DrawingBlock", która przyjmuje jako argument obiekt klasy "PaintEventArgs" i
        // odpowiada za rysowanie tych bloków na planszy oraz narysowanie na nich ich wytrzymałości.

        public void DrawingBlock(PaintEventArgs ePaint)
        {
            SolidBrush triangleBrush = new SolidBrush(TriangleColor);

            trianglePoints[0] = new Point(TriangleStartingPoint.X, TriangleStartingPoint.Y);
            trianglePoints[1] = new Point(TriangleStartingPoint.X + TriangleWidth, TriangleStartingPoint.Y);
            trianglePoints[2] = new Point(TriangleStartingPoint.X + TriangleWidth, TriangleStartingPoint.Y + TriangleHeight);

            ePaint.Graphics.FillPolygon(triangleBrush, trianglePoints);

            string durabilityText = Durability.ToString();
            var font = new Font("Arial", 16, FontStyle.Bold);
            var textSize = ePaint.Graphics.MeasureString(durabilityText, font);
            var textX = TriangleStartingPoint.X + (TriangleWidth - textSize.Width) / 2 + 8;
            var textY = TriangleStartingPoint.Y + (TriangleHeight - textSize.Height) / 2 - 8;
            
            ePaint.Graphics.DrawString(durabilityText, font, Brushes.Black, textX, textY);
        }

        // Metoda "ColorChanging", która odpowiada za zmiane koloru danego bloku
        // (który został uderzony przez kulkę).

        public void ColorChanging()
        {
            int currentIndex = AvailableColors.IndexOf(TriangleColor);
            
            if (currentIndex > 0)
            {
                TriangleColor = AvailableColors[currentIndex - 1];
            }
        }

        // Dodatkowa metoda "BallIntersectsTriangle" specjalnie dla tej klasy,
        // która bierze i sprawdza czy dana kulka uderza w dany trójkąt i zwraca wartość typu 'bool'.

        public bool BallIntersectsTriangle(Rectangle ballRect, Rectangle triangleRec)
        {
            return ballRect.IntersectsWith(triangleRec);
        }
    }
}
