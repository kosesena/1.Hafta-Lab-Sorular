using System;

class PrimeSum
{
    static void Main()
    {
        Console.Write("N değerini girin: ");
        int n = int.Parse(Console.ReadLine());

        int sum = 0;

        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                sum += i;
            }
        }

        Console.WriteLine($"1'den {n}'e kadar olan asal sayıların toplamı: {sum}");
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}