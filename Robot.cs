using System;
using System.Collections.Generic;

class RobotRescue
{
    static int[,] grid;
    static bool[,] visited;
    static int gridSize;

    // Komşu hareket yönleri (yukarı, sağ, aşağı, sol)
    static int[] dx = { -1, 0, 1, 0 };
    static int[] dy = { 0, 1, 0, -1 };

    static void Main()
    {
        Console.Write("Izgara boyutunu girin (NxN): ");
        gridSize = int.Parse(Console.ReadLine());

        grid = new int[gridSize, gridSize];
        visited = new bool[gridSize, gridSize];

        Console.WriteLine("Izgarayı girin (1: Kurtarılabilir düğüm, 0: Zarar görmüş düğüm):");
        for (int i = 0; i < gridSize; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = row[j] - '0';
                visited[i, j] = false;
            }
        }

        List<Tuple<int, int>> robotPositions = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(0, 0), // Robot 1 başlangıç konumu
            new Tuple<int, int>(2, 2), // Robot 2 başlangıç konumu
            new Tuple<int, int>(3, 3)  // Robot 3 başlangıç konumu
        };

        for (int i = 0; i < robotPositions.Count; i++)
        {
            int startX = robotPositions[i].Item1;
            int startY = robotPositions[i].Item2;
            int rescuedNodes = RescueNodes(startX, startY);
            Console.WriteLine($"Robot {i + 1} başlangıç pozisyonu ({startX}, {startY}) - Kurtarılan düğüm sayısı: {rescuedNodes}");
        }
    }

    static int RescueNodes(int x, int y)
    {
        if (x < 0 || x >= gridSize || y < 0 || y >= gridSize || visited[x, y] || grid[x, y] == 0)
            return 0;

        visited[x, y] = true;
        int rescued = 1;

        for (int direction = 0; direction < 4; direction++)
        {
            int newX = x + dx[direction];
            int newY = y + dy[direction];
            rescued += RescueNodes(newX, newY);
        }

        return rescued;
    }
}