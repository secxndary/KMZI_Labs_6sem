using System.Collections;
using System.Numerics;
namespace KMZI_Lab9;


public class Cypher
{
    // Сгенерировать сверхвозрастающую последовательность
    // d - закрытый ключ
    public static List<BigInteger> GeneratePrivateKey(BigInteger initialNumber, int quantityOfNumbers)
    {
        List<BigInteger> sequence = new List<BigInteger>();
        BigInteger term = initialNumber;

        for (int i = 0; i < quantityOfNumbers; i++)
        {
            sequence.Add(term);
            term += initialNumber;
            initialNumber <<= 1;
        }

        return sequence;
    }


    // Сгенерировать нормальную последовтальность
    // e - открытый ключ
    public static List<BigInteger> GeneratePublicKey(List<BigInteger> privateKey, BigInteger a, BigInteger n)
    {
        var sum = Sum(privateKey);
        if (n <= sum)
            throw new ArgumentException("n should be more than sum of all numbers in private key.");
        if (!AreRelativelyPrime(a, n))
            throw new ArgumentException("a and n should be .");

        var publicKey = new List<BigInteger>();
        foreach (BigInteger d in privateKey)
        {
            BigInteger e = d * a % n;
            publicKey.Add(e);
        }

        return publicKey;
    }


    // Зашифрование
    public static List<BigInteger> Encrypt(List<BigInteger> publicKey, byte[] plaintext)
    {
        var encryptedList = new List<BigInteger>();

        foreach (byte b in plaintext)
        {
            string binaryString = Convert.ToString(b, 2);

            var positions = new List<int>();
            for (int i = 0; i < binaryString.Length; i++)
                if (binaryString[i] == '1')
                    positions.Add(i);

            var sum = BigInteger.Zero;
            foreach (int position in positions)
                if (position < publicKey.Count)
                    sum += publicKey[position];

            encryptedList.Add(sum);
        }

        return encryptedList;
    }




    // Сгенерировать большое число размером n бит
    public static BigInteger GenerateRandomNumber(int n)
    {
        var random = new Random();
        byte[] bytes = new byte[(n + 7) / 8];
        random.NextBytes(bytes);

        var numExtraBits = n % 8;
        if (numExtraBits > 0)
            bytes[bytes.Length - 1] &= (byte)(255 >> ((bytes.Length * 8) - n));

        var randomNumber = new BigInteger(bytes);
        return randomNumber;
    }

    // Генерация числа, взаимно простого с n
    public static BigInteger GenerateCoprime(BigInteger n)
    {
        var random = new Random();
        while (true)
        {
            BigInteger number = GenerateRandomNumber(n.GetByteCount() * 8, random);
            if (BigInteger.GreatestCommonDivisor(number, n) == 1)
                return number;
        }
    }

    // Получить строку в байтах
    public static string GetBytes(string str)
    {
        var res = "";
        for (int i = 0; i < str.Length; i++)
            res += Convert.ToString(str[i], 2);
        return res;
    }

    // Получить сумму чисел в List<BigInteger>
    public static BigInteger Sum(List<BigInteger> numbers)
    {
        BigInteger sum = 0;
        foreach (BigInteger number in numbers)
            sum += number;
        return sum;
    }

    // Вспомогательный метод для проверки, являются ли два числа простыми
    private static bool AreRelativelyPrime(BigInteger a, BigInteger b)
    {
        BigInteger gcd = BigInteger.GreatestCommonDivisor(a, b);
        return gcd == 1;
    }

    // Вспомогательный метод для генерации случайного числа BigInteger
    private static BigInteger GenerateRandomNumber(int bitLength, Random random)
    {
        var bytes = new byte[bitLength / 8];
        random.NextBytes(bytes);
        bytes[bytes.Length - 1] &= 0x7F;
        return new BigInteger(bytes);
    }
}
