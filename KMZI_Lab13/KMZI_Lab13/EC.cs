using System;

namespace KMZI_Lab13;


public class EC
{
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
    public static int[] CalculateSum(int[] P, int[] Q, int p)
    {
        int lambda = CalculateLambda(P, Q, p);
        int x = GCD.Mod(lambda * lambda - P[0] - Q[0], p);
        int y = GCD.Mod(lambda * (P[0] - x) - P[1], p);
        return new int[] { x, y };
    }


    // Сумма точек P и P
    public static int[] CalculateSum(int[] P, int a, int p)
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
            kP = CalculateSum(kP, a, p);
        k = k - (int)Math.Pow(2, (int)Math.Log(k, 2));
        while (k > 1)
        {
            for (int i = 0; i < (int)Math.Log(k, 2); i++)
                kP = CalculateSum(kP, CalculateSum(P, a, p), p);
            k = k - (int)Math.Pow(2, (int)Math.Log(k, 2));
        }
        if (k == 1)
            kP = CalculateSum(kP, P, p);
        return kP;
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
}