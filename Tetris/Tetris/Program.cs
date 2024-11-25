using System;
using System.Timers;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        static private Object _lockObject = new object();

        static Figure currentFigure;
        static FigureGenerator generator;
        public static void Main(string[] args)
        {
            Console.SetWindowSize(PlayGround.Width, PlayGround.Height);
            Console.SetBufferSize(PlayGround.Width, PlayGround.Height);

            generator = new FigureGenerator(PlayGround.Width / 2, 0, Drawer.DEFAULT_SYMBOL); 
            currentFigure = generator.GetNewFigure();
            SetTimer();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }

            Console.ReadKey();
        }

        private static bool ProcessResult(StrikeStatus result, ref Figure currentFigure)
        {
            if (result == StrikeStatus.HEAP_STRIKE || result == StrikeStatus.DOWN_BORDER_STRIKE)
            {
                PlayGround.AddFigure(currentFigure);
                PlayGround.TryDeleteLines();

                if (currentFigure.IsOnTop())
                {
                    WriteGameOver();
                    timer.Elapsed -= OnTimeEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }
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

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);

            timer.Elapsed += OnTimeEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }

        private static void WriteGameOver()
        {
            Console.SetCursorPosition(PlayGround.Width / 2 - 8, PlayGround.Height / 2);
            Console.WriteLine("G A M E   O V E R");
        }
    }
}