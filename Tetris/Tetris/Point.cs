using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point(int x, int y, char c)
        {
            this.X = x;
            this.Y = y;
            this.C = c;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            C = p.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }
        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.RIGHT:
                    X += 1;
                    break;
                case Direction.DOWN:
                    Y += 1;
                    break;
            }
        }

        
    }
}
