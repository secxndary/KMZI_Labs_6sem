using System.Numerics;
namespace KMZI_Lab9;

public class Cypher
{
    public static List<BigInteger> GenerateSuperIncreasingSequence(BigInteger initialTerm, int z)
    {
        List<BigInteger> sequence = new List<BigInteger>();
        BigInteger term = initialTerm;

        for (int i = 0; i < z; i++)
        {
            sequence.Add(term);
            term += initialTerm;
            initialTerm <<= 1;
        }

        return sequence;
    }



    public static BigInteger GenerateRandomNumber(int n)
    {
        Random random = new Random();
        byte[] bytes = new byte[n / 8];
        random.NextBytes(bytes);

        // Добавляем биты нуля, чтобы число было точно размером n бит
        int numExtraBits = n % 8;
        if (numExtraBits > 0)
        {
            byte extraBitsMask = (byte)(0xFF >> (8 - numExtraBits));
            bytes[0] &= extraBitsMask;
        }

        BigInteger randomNumber = new BigInteger(bytes);
        return randomNumber;
    }
}
