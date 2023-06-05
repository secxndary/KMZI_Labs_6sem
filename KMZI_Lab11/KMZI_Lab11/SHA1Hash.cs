using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
namespace KMZI_Lab11;


public class SHA1Hash
{
    public static string GetSHA1Hash(string input)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        using SHA1 sha1 = SHA1.Create();
        byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

        var sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
            sb.Append(hashBytes[i].ToString("x2"));

        stopWatch.Stop();
        Console.WriteLine($"SHA-1 Hash:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return sb.ToString();
    }
}
