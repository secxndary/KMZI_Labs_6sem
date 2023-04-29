using System.Diagnostics;
using System.Security.Cryptography;
namespace KMZI_Lab7;


class Cypher
{
    // Зашифрование с помощью алгоритма DES
    public static byte[] EncryptDES(byte[] plainText, byte[] key)
    {
        using (var des = DES.Create())
        {
            var validKey = CypherHelper.GetValidKey(key);
            des.Key = validKey;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            using (var encryptor = des.CreateEncryptor())
            {
                var cipherBytes = encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
                return cipherBytes;
            }
        }
    }


    // Расшифрование с помощью алгоритма DES
    public static byte[] DecryptDES(byte[] cypherText, byte[] key)
    {
        using (var des = DES.Create())
        {
            var validKey = CypherHelper.GetValidKey(key);
            des.Key = validKey;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            using (var decryptor = des.CreateDecryptor())
            {
                var plainBytes = decryptor.TransformFinalBlock(cypherText, 0, cypherText.Length);
                return plainBytes;
            }
        }
    }


    // Зашифрование с помощью алгоритма DES-EEE2
    public static byte[] EncryptEEE2(byte[] plainText, byte[] key1, byte[] key2)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var firstEncrypt  = EncryptDES(plainText, key1);
        var secondEncrypt = EncryptDES(firstEncrypt, key2);
        var thirdEncrypt  = EncryptDES(secondEncrypt, key1);

        stopWatch.Stop();
        Console.WriteLine($"Encrypt DES-EEE2:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return thirdEncrypt;
    }


    // Расшифрование с помощью алгоритма DES-EEE2
    public static byte[] DecryptEEE2(byte[] encryptText, byte[] key1, byte[] key2)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var firstDecrypt  = DecryptDES(encryptText, key1);
        var secondDecrypt = DecryptDES(firstDecrypt, key2);
        var thirdDecrypt  = DecryptDES(secondDecrypt, key1);

        stopWatch.Stop();
        Console.WriteLine($"Decrypt DES-EEE2:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return thirdDecrypt;
    }
}