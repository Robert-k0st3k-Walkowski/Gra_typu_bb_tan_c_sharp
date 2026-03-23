using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{

    // Klasa odpowiadająca za pojedynczą kulkę oraz samo jej generowanie.
    public class Ball
    {
        // Deklaracja pól klasy "Ball" (oraz ich ewentualna definicja).

        float x;
        float y;
        float vx;
        float vy;
        float size = 20;

        // Konstruktor klasy "Ball" ustawiający odpowiednie wartości poszczególnych pól tej klasy.

        public Ball(float X, float Y, float VX, float VY)
        {
            this.x = X;
            this.y = Y;
            this.vx = VX;
            this.vy = VY;
        }

        // Seria różnych właściwości dla klasy "Ball" potrzebnych do uzyskania dostępu np. do pozycji X i Y kulki, jej prędkości X oraz Y itd.
        // w inncych częściach programu.

        public float GetX
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public float GetY
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public float GetVX
        {
            get { return this.vx; }
            set { this.vx = value; }
        }

        public float GetVY
        {
            get { return this.vy; }
            set { this.vy = value; }
        }

        public float GetSize
        {
            get { return this.size; }
        }

        // Jedyna metoda tej klasy, która odpowiada za stworzenie oraz zwrócenie obiektu typu "Rectangle", która tworzy kształt kulki
        // na podstawie przekazanych parametrów do jednego z kontruktorów klasy "Rectangle".
        public Rectangle GetNewBall()
        {
            return new Rectangle((int)this.x, (int)this.y, (int)this.size, (int)this.size);
        }
    }
}
