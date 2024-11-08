using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Matris boyutunu girin (NxN): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        int value = 1;
        int left = 0, right = n - 1, top = 0, bottom = n - 1;

        while (value <= n * n)
        {
            // En üst sırayı sola doğru doldur
            for (int i = left; i <= right; i++)
                matrix[top, i] = value++;
            top++;

            // Sağdaki sütunu yukarıdan aşağıya doğru doldur
            for (int i = top; i <= bottom; i++)
                matrix[i, right] = value++;
            right--;

            // En alt sırayı sağdan sola doğru doldur
            for (int i = right; i >= left; i--)
                matrix[bottom, i] = value++;
            bottom--;

            // Soldaki sütunu aşağıdan yukarıya doğru doldur
            for (int i = bottom; i >= top; i--)
                matrix[i, left] = value++;
            left++;
        }

        // Matrisi ekrana yazdır
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(3) + " ");
            }
            Console.WriteLine();
        }
    }
}
