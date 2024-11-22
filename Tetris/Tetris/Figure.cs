using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Figure
    {
        protected Point[] points = new Point[4];

        public void Draw()
        {
            foreach (Point p in points)
            {
                p.Draw();
            }
        }

        public void Clear()
        {
            foreach (Point p in points)
            {
                p.Clear();
            }
        }

        /*public void Move(Direction dir)
        {
            Clear();
            foreach (Point p in points)
            {
                p.Move(dir);
            }
            Draw();
        }*/

        public void Move(Point[] pList, Direction dir)
        {
            foreach(Point p in pList)
            {
                p.Move(dir);
            }
        }

        public void TryMove(Direction dir)
        {
            Clear();

            Point[] clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone))
                points = clone;

            Draw();
        }

        private bool VerifyPosition(Point[] pList)
        {
            foreach (Point p in pList)
            {
                if (p.x < 0 || p.y < 0 || p.x >= PlayGround.WIDTH || p.y >= PlayGround.HEIGHT)
                    return false;
            }
            return true;
        }

        private Point[] Clone()
        {
            Point[] newPoints = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        public abstract void Rotate(Point[] pList);
        public void TryRotate()
        {
            Clear();
            Point[] clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
                points = clone;
            Draw();
        }
    }
}
