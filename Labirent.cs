using System;
using System.Collections.Generic;

class Labyrinth
{
    static int[,] labyrinth;
    static int n;

    // Hareket yönleri: yukarı, sağ, aşağı, sol
    static int[] dx = { -1, 0, 1, 0 };
    static int[] dy = { 0, 1, 0, -1 };

    static void Main()
    {
        Console.Write("Labirent boyutunu girin (NxN): ");
        n = int.Parse(Console.ReadLine());

        labyrinth = new int[n, n];

        Console.WriteLine("Labirenti girin (1: Geçilebilir, 0: Geçilemez):");
        for (int i = 0; i < n; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                labyrinth[i, j] = row[j] - '0';
            }
        }

        int shortestPath = FindShortestPath();

        if (shortestPath == -1)
            Console.WriteLine("Yol Yok");
        else
            Console.WriteLine($"En Kısa Yol: {shortestPath} adım");
    }

    static int FindShortestPath()
    {
        if (labyrinth[0, 0] == 0 || labyrinth[n - 1, n - 1] == 0)
            return -1; // Başlangıç veya bitiş noktası engelli

        bool[,] visited = new bool[n, n];
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(new Tuple<int, int, int>(0, 0, 0));
        visited[0, 0] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;
            int steps = current.Item3;

            if (x == n - 1 && y == n - 1)
                return steps;

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (IsInBounds(newX, newY) && !visited[newX, newY] && labyrinth[newX, newY] == 1)
                {
                    queue.Enqueue(new Tuple<int, int, int>(newX, newY, steps + 1));
                    visited[newX, newY] = true;
                }
            }
        }

        return -1; // Hazineye ulaşılamadıysa
    }

    static bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < n && y >= 0 && y < n;
    }
}