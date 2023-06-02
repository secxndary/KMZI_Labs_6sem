using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
namespace KMZI_Lab10;

public class RSACypher
{
    public static byte[] Encrypt(byte[] plaintext, RSAParameters publicKey)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        using var rsa = new RSACryptoServiceProvider();
        rsa.ImportParameters(publicKey);

        stopWatch.Stop();
        Console.WriteLine($"RSA Encrypt:\t\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return rsa.Encrypt(plaintext, true);
    }


    public static byte[] Decrypt(byte[] ciphertext, RSAParameters privateKey)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        using var rsa = new RSACryptoServiceProvider();
        rsa.ImportParameters(privateKey);
        
        stopWatch.Stop();
        Console.WriteLine($"RSA Decrypt:\t\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return rsa.Decrypt(ciphertext, true);
    }



    public static void FirstTask()
    {
        BigInteger a = new BigInteger(20);
        var x = 100000;
        BigInteger n;
        string N = "1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        BigInteger.TryParse(N, out n);

        Stopwatch stopwatch = new Stopwatch();

        for (var i = 0; i < 10; i++)
        {
            stopwatch.Reset();
            stopwatch.Start();
            FyncY(a, x, n);
            stopwatch.Stop();
            Console.WriteLine($"x = {x}\t({stopwatch.ElapsedMilliseconds} ms)");

            x += 100000;
        }
    }



    public static BigInteger FyncY(BigInteger a, int x, BigInteger n)
    {
        return BigInteger.Pow(a, x) % n;
    }
}
