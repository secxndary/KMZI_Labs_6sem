namespace KMZI_Lab8;

public class CypherHelper
{

    // Проверить, взаимно ли простые числа
    public static bool AreRelativelyPrime(long a, long b)
    {
        while (b != 0)
        {
            var remainder = a % b;
            a = b;
            b = remainder;
        }
        return a == 1;
    }


}