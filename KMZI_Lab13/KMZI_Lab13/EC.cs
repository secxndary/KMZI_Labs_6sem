using System;
using System.Diagnostics;

namespace KMZI_Lab13;


public class EC
{
    private static string alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
    private static int[,] points =
        { { 189, 297 }, { 189, 454 }, { 192, 32 },  { 192, 719 }, { 194, 205 }, { 194, 546 }, { 197, 145 }, { 197, 606 },
          { 198, 224 }, { 198, 527 }, { 200, 30 },  { 200, 721 }, { 203, 324 }, { 203, 427 }, { 205, 372 }, { 205, 379 },
          { 206, 106 }, { 206, 645 }, { 209, 82 },  { 209, 669 }, { 210, 31 },  { 210, 720 }, { 215, 247 }, { 215, 504 },
          { 218, 150 }, { 218, 601 }, { 221, 138 }, { 221, 613 }, { 226, 9 },   { 226, 742 }, { 227, 299 }, { 227, 542 } };


    // Получить точки ЭК над конечным полем (задание 1.1)
    public static List<(int, double)> GetPoints(int xMin, int xMax, int a, int b, int p)
    {
        var points = new List<(int, double)>();
        for (int x = xMin; x <= xMax; x++)
        {
            double y = Math.Round(Math.Sqrt((x * x * x + a * x + b) % p), 2);
            points.Add((x, y));
        }
        return points;
    }


    // Сумма точек P и Q
    public static int[] Sum(int[] P, int[] Q, int p)
    {
        int lambda = CalculateLambda(P, Q, p);
        int x = GCD.Mod(lambda * lambda - P[0] - Q[0], p);
        int y = GCD.Mod(lambda * (P[0] - x) - P[1], p);
        return new int[] { x, y };
    }


    // Сумма точек P и P
    public static int[] Sum(int[] P, int a, int p)
    {
        int lambda = CalculateLambda(P, a, p);
        int x = GCD.Mod(lambda * lambda - P[0] - P[0], p);
        int y = GCD.Mod(lambda * (P[0] - x) - P[1], p);
        return new int[] { x, y };
    }


    // Умножение точки P на число k
    public static int[] Multiply(int k, int[] P, int a, int p)
    {
        int[] kP = P;
        for (int i = 0; i < (int)Math.Log(k, 2); i++)
            kP = Sum(kP, a, p);
        k = k - (int)Math.Pow(2, (int)Math.Log(k, 2));
        while (k > 1)
        {
            for (int i = 0; i < (int)Math.Log(k, 2); i++)
                kP = Sum(kP, Sum(P, a, p), p);
            k = k - (int)Math.Pow(2, (int)Math.Log(k, 2));
        }
        if (k == 1)
            kP = Sum(kP, P, p);
        return kP;
    }


    // Зашифровать с помощью ЭК
    public static int[,] Encrypt(string text, int[] G, int a, int p, int d)
    {
        var random = new Random();
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        text = text.ToLower().Replace(" ", string.Empty);
        int[] Q = Multiply(d, G, a, p);
        int[,] encryptedText = new int[text.Length, 4];
        int k;
        
        Console.WriteLine($"d = {d}\nG = {Format(G)}\nQ = {Format(Q)}");
        for (int i = 0; i < text.Length; i++)
        {
            k = random.Next(2, d);
            int[] P = Enumerable.Range(0, points.GetLength(1)).Select(x => points[alphabet.IndexOf(text[i]), x]).ToArray();
            int[] C1 = Multiply(k, G, a, p);
            int[] kQ = Multiply(k, Q, a, p);
            int[] C2 = Sum(P, kQ, p);
            encryptedText[i, 0] = C1[0]; encryptedText[i, 1] = C1[1];
            encryptedText[i, 2] = C2[0]; encryptedText[i, 3] = C2[1];
        }

        stopWatch.Stop();
        Console.WriteLine($"EC Encrypt:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return encryptedText;
    }


    // Расшифровать с помощью ЭК
    public static string Decrypt(int[,] encryptedText, int a, int p, int d)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var decryptedText = "";
        for (int i = 0; i < encryptedText.GetUpperBound(0) + 1; i++)
        {
            int[] C1 = Multiply(d, new int[] { encryptedText[i, 0], encryptedText[i, 1] }, a, p);
            int[] C2 = { encryptedText[i, 2], encryptedText[i, 3] };
            int[] P = Sum(C2, InversePoint(C1), p);
            
            for (int k = 0; k < points.GetUpperBound(0) + 1; k++)
            {
                if (points[k, 0] == P[0] && points[k, 1] == P[1])
                {
                    decryptedText += alphabet[k];
                    break;
                }
            }
        }

        stopWatch.Stop();
        Console.WriteLine($"EC Decrypt:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return decryptedText;
    }



    // Лямбда в случае P = Q:   (3 * (х1)^2 + а) / 2 * у1
    private static int CalculateLambda(int[] P, int a, int p)
    {
        return GCD.Mod(GCD.Mod(3 * P[0] * P[0] + a, p) * GCD.ModInverse(2 * P[1], p), p);
    }

    // Лямбда в случае P != Q:  (у2 – у1) / (х2 – х1)
    private static int CalculateLambda(int[] P, int[] Q, int p)
    {
        return GCD.Mod(GCD.Mod(Q[1] - P[1], p) * GCD.Mod(GCD.ModInverse(Q[0] + GCD.Mod(-P[0], p), p), p), p);
    }

    // Вычислить -P (принять y = -y)
    public static int[] InversePoint(int[] P) => new int[2] { P[0], (-1) * P[1] };

    // Вывести точку
    public static string Format(int[] point) => $"({point[0]}, {point[1]})";
}