using System;

namespace Tetris
{
    class Program
    {
        static FigureGenerator generator;
        public static void Main(string[] args)
        {
            Console.SetWindowSize(PlayGround.Width, PlayGround.Height);
            Console.SetBufferSize(PlayGround.Width, PlayGround.Height);

            generator = new FigureGenerator(20, 0, '#'); 
            Figure currentFigure = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    var result = HandleKey(currentFigure, key);
                    ProcessResult(result, ref currentFigure);
                }
            }

            Console.ReadKey();
        }

        private static bool ProcessResult(StrikeStatus result, ref Figure currentFigure)
        {
            if (result == StrikeStatus.HEAP_STRIKE || result == StrikeStatus.DOWN_BORDER_STRIKE)
            {
                PlayGround.AddFigure(currentFigure);
                currentFigure = generator.GetNewFigure();

                return true;
            }
            else
                return false;
        }

        private static StrikeStatus HandleKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return currentFigure.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return currentFigure.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return currentFigure.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                    return currentFigure.TryRotate();
            }
            return StrikeStatus.SUCCESS;
        }
    }
}