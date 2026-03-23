using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    // Interfejs "Block", którego metody implementowane są przez takie klasy jak "SquareBlocks" oraz "TriangleBlocks".

    public interface IBlock
    {

        // Deklaracja metody "GeneratingPosition", która jako argument przyjmuje listę elementów typu "int".

        public void GeneratingPosition(List<int> availableSlots);

        // Deklaracja metody "DrawingBlock", która jako argumnet przyjmuje obiekt klasy "PaintEventArgs".

        public void DrawingBlock(PaintEventArgs ePaint);

        // Deklaracja metody "ColorChanging", która nie przyjmuje żadnych argumentów i nie zwraca nic (typ "void").

        public void ColorChanging();

        // Deklaracja metody "MoveDown", która nie przyjmuje żadnych argumentów i też niczego nie zwraca.
        public void MoveDown();
    }
}
