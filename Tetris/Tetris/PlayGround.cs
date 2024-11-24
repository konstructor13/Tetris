using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public static class PlayGround
    {
        private static int _width = 40;
        private static int _height = 30;

        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(PlayGround.Width, PlayGround.Height);
                Console.SetBufferSize(PlayGround.Width, PlayGround.Height);
            }
        }

        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                Console.SetWindowSize(PlayGround.Width, PlayGround.Height);
                Console.SetBufferSize(PlayGround.Width, PlayGround.Height);
            }
        }

        private static bool[][] _heap;

        static PlayGround()
        {
            _heap = new bool[Height][];
            
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }
        
        public static void AddFigure(Figure figure)
        {
            foreach (Point p in figure.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

    }
}
