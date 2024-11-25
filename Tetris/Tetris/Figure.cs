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

        public void Move(Direction dir)
        {
            foreach(Point p in Points)
            {
                p.Move(dir);
            }
        }

        public StrikeStatus TryMove(Direction dir)
        {
            Clear();

            Move(dir);

            var result = VerifyPosition();
            if (result != StrikeStatus.SUCCESS)
                Move(Reverse(dir));

            Draw();

            return result;
        }

        private Direction Reverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT: 
                    return Direction.LEFT;
                case Direction.UP:
                    return Direction.DOWN;
                case Direction.DOWN:
                    return Direction.UP;
            }
            return dir;
        }

        private StrikeStatus VerifyPosition() 
        {
            foreach (Point p in Points)
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

        /*private Point[] Clone()
        {
            Point[] newPoints = new Point[Points.Length];
            for (int i = 0; i < Points.Length; i++)
            {
                newPoints[i] = new Point(Points[i]);
            }
            return newPoints;
        }*/

        public abstract void Rotate();
        public StrikeStatus TryRotate()
        {
            Clear();
            Rotate();

            var result = VerifyPosition();
            if (result != StrikeStatus.SUCCESS)
                Rotate();

            Draw();

            return result;
        }

        public bool IsOnTop()
        {
            return Points[0].Y == 0;
        }
    }
}
