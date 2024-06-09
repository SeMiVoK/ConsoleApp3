namespace ConsoleApp3
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int[,] landscape = GenerateLandscape(10, 10);

            PrintLandscape(landscape);

            FindDecorLocations(landscape);
        }

        static int[,] GenerateLandscape(int width, int height)
        {
            int[,] landscape = new int[width, height];
            Random random = new Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    landscape[i, j] = random.Next(100);
                }
            }

            return landscape;
        }

        static void PrintLandscape(int[,] landscape)
        {
            for (int i = 0; i < landscape.GetLength(0); i++)
            {
                for (int j = 0; j < landscape.GetLength(1); j++)
                {
                    Console.Write($"{landscape[i, j],3}");
                }
                Console.WriteLine();
            }
        }

        static void FindDecorLocations(int[,] landscape)
        {
            for (int i = 1; i < landscape.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < landscape.GetLength(1) - 1; j++)
                {
                    if (IsLocalMinimum(landscape, i, j))
                    {
                        Console.WriteLine($"Местоположение для декоративного элемента: ({i}, {j})");
                    }
                }
            }
        }

        static bool IsLocalMinimum(int[,] landscape, int i, int j)
        {
            int center = landscape[i, j];
            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    if (landscape[i + di, j + dj] < center)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}
