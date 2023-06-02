using System.Diagnostics;
using System.Numerics;
namespace KMZI_Lab10;

public class ElGamalCypher
{
    private BigInteger p;
    private BigInteger g;
    private BigInteger x;
    private BigInteger y;

    public ElGamalCypher(BigInteger p, BigInteger g, BigInteger x)
    {
        this.p = p;
        this.g = g;
        this.x = x;
        y = BigInteger.ModPow(g, x, p);
    }

    public byte[] Encrypt(byte[] plaintext)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        Random random = new Random();
        BigInteger k;
        do
        {
            byte[] bytes = new byte[p.ToByteArray().Length];
            random.NextBytes(bytes);
            k = new BigInteger(bytes);
        } while (k <= 1 || k >= p - 1);

        BigInteger a = BigInteger.ModPow(g, k, p);
        BigInteger b = BigInteger.ModPow(y, k, p);

        byte[] ciphertext = new byte[2 * plaintext.Length];
        for (int i = 0; i < plaintext.Length; i++)
        {
            ciphertext[2 * i] = (byte)(plaintext[i] ^ (byte)a);
            ciphertext[2 * i + 1] = (byte)(plaintext[i] ^ (byte)b);
        }

        stopWatch.Stop();
        Console.WriteLine($"El-Gamal Encrypt:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return ciphertext;
    }

    public byte[] Decrypt(byte[] ciphertext)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        byte[] plaintext = new byte[ciphertext.Length / 2];
        for (int i = 0; i < plaintext.Length; i++)
        {
            BigInteger a = new BigInteger(ciphertext[2 * i]);
            BigInteger b = new BigInteger(ciphertext[2 * i + 1]);

            plaintext[i] = (byte)(a ^ b ^ x);
        }

        stopWatch.Stop();
        Console.WriteLine($"El-Gamal Decrypt:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return plaintext;
    }
}