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
            Points[0] = new Point(x, y, c);
            Points[1] = new Point(x, y + 1, c);
            Points[2] = new Point(x, y + 2, c);
            Points[3] = new Point(x, y + 3, c);
            Draw();
        }

        public override void Rotate(Point[] pList)
        {
            if (pList[0].X == pList[1].X)
            {
                //Rotate Horizontal
                for (int i = 0; i < pList.Length; i++)
                {
                    pList[i].Y = pList[0].Y;
                    pList[i].X = pList[0].X + i;
                }
            }
            else
            {
                //Rotate Vertical
                for (int i = 0; i < pList.Length; i++)
                {
                    pList[i].X = pList[0].X;
                    pList[i].Y = pList[0].Y + i;
                }
            }
        }

    }
}
