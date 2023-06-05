using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
namespace KMZI_Lab11;


public class MD5Hash
{
    public static string GetMD5Hash(string input)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        using MD5 md5 = MD5.Create();
        byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

        var sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
            sb.Append(hashBytes[i].ToString("x2"));

        stopWatch.Stop();
        Console.WriteLine($"MD5 Hash:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return sb.ToString();
    }
}
