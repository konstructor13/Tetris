using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Stick : Figure
    {

        public Stick(int x, int y, char c)
        {
            points[0] = new Point(x, y, c);
            points[1] = new Point(x, y + 1, c);
            points[2] = new Point(x, y + 2, c);
            points[3] = new Point(x, y + 3, c);
        }

        public override void Rotate()
        {
            if (points[0].x == points[1].x)
            {
                //Rotate Horizontal
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].y = points[0].y;
                    points[i].x = points[0].x + i;
                }
            }
            else
            {
                //Rotate Vertical
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].x = points[0].x;
                    points[i].y = points[0].y + i;
                }
            }
        }

    }
}
