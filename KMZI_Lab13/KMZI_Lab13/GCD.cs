namespace KMZI_Lab13;


public class GCD
{
    // Вычислить х по модулю m
    public static int Mod(int x, int m) => (x % m + m) % m;


    // Получить обратное к числу a по модулю m
    public static int ModInverse(int a, int m)
    {
        a = a % m;
        for (int x = 1; x < m; x++)
            if ((a * x) % m == 1)
                return x;
        return 1;
    }
}
