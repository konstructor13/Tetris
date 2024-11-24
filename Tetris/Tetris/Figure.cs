using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Figure
    {
        public Point[] Points = new Point[4];

        public void Draw()
        {
            foreach (Point p in Points)
            {
                p.Draw();
            }
        }

        public void Clear()
        {
            foreach (Point p in Points)
            {
                p.Clear();
            }
        }

        public void Move(Point[] pList, Direction dir)
        {
            foreach(Point p in pList)
            {
                p.Move(dir);
            }
        }

        public StrikeStatus TryMove(Direction dir)
        {
            Clear();

            Point[] clone = Clone();
            Move(clone, dir);

            var result = VerifyPosition(clone);
            if (result == StrikeStatus.SUCCESS)
                Points = clone;

            Draw();

            return result;
        }

        private StrikeStatus VerifyPosition(Point[] pList) 
        {
            foreach (Point p in pList)
            {
                if (p.Y >= PlayGround.Height)
                    return StrikeStatus.DOWN_BORDER_STRIKE;
                if (p.X >= PlayGround.Width || p.X < 0 || p.Y < 0)
                    return StrikeStatus.BORDER_STRIKE;
                if (PlayGround.CheckStrike(p))
                    return StrikeStatus.HEAP_STRIKE;
            }
            return StrikeStatus.SUCCESS;
        }

        private Point[] Clone()
        {
            Point[] newPoints = new Point[Points.Length];
            for (int i = 0; i < Points.Length; i++)
            {
                newPoints[i] = new Point(Points[i]);
            }
            return newPoints;
        }

        public abstract void Rotate(Point[] pList);
        public StrikeStatus TryRotate()
        {
            Clear();
            Point[] clone = Clone();
            Rotate(clone);

            var result = VerifyPosition(clone);
            if (result == StrikeStatus.SUCCESS)
                Points = clone;

            Draw();

            return result;
        }
    }
}
