namespace KMZI_Lab3;

public class Modular
{
    // Алгоритм Евклида для НОД
    public static ulong GetGCD(ulong a, ulong b)
    {
        if (a == 0)             return b;
        if (b == 0)             return a;
        if (a == 1 || b == 1)   return 1;

        while (a != 0 &&  b != 0)
        {
            if (a > b)  
                a -= b;
            else        
                b -= a;
        }

        return (a > b) ? a : b;
    }


    // Получить простые числа от 2 до n
    public static List<ulong> GetPrimes(ulong n)
    {
        var numbers = new List<ulong>();
        for (var i = 2u; i <= n; i++)
            numbers.Add(i);

        for (var i = 0; i < numbers.Count; i++)
            for (var j = 2u; numbers[i] * j <= n; j++)
                numbers.Remove(numbers[i] * j);

        return numbers;
    }


    // Получить простые числа от m до n
    public static List<ulong> GetPrimes(ulong m, ulong n)
    {
        if (m > n)
            (m, n) = (n, m);

        var isPrime = new bool[n - m + 1];
        for (var i = 0u; i < isPrime.Length; i++)
            isPrime[i] = true;

        for (var i = 2u; i * i <= n; i++)
            for (var j = (m + i - 1) / i * i; j <= n; j += i)
                if (j != i && j >= m)
                    isPrime[j - m] = false;

        var primes = new List<ulong>();
        for (ulong i = m; i <= n; i++)
        {
            if (i < 2) continue;
            if (isPrime[i - m])
                primes.Add(i);
        }

        return primes;
    }


    // Получить количество простых чисел
    public static int GetPrimesCount(ulong n) => GetPrimes(n).Count;
    
    public static int GetPrimesCount(ulong m, ulong n) => GetPrimes(m, n).Count;


    // Получить примерное количество простых чисел [n / ln(n)]
    // Для общего развития: это формула из Теоремы о распределении простых чисел
    public static double GetApproximatePrimesCount(ulong n) => Math.Round(n / Math.Log(n), 1);
}
