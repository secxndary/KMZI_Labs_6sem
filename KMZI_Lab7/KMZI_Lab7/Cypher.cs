using System.Security.Cryptography;
using System.Diagnostics;
namespace KMZI_Lab7;


class Cypher
{
    // Зашифрование с помощью алгоритма DES
    public static byte[] EncryptDES(byte[] plainText, byte[] key, out int changedBits)
    {
        var initialPlainText = CypherHelper.GetOpenText();

        using (var des = DES.Create())
        {
            var validKey = CypherHelper.GetValidKey(key);
            des.Key = validKey;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            using (var encryptor = des.CreateEncryptor())
            {
                var cipherBytes = encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
                changedBits = GetAvalancheEffect(initialPlainText, cipherBytes);
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
    public static byte[] EncryptEEE2(byte[] plainText, byte[] key1, byte[] key2, out int changedBits)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        int changedBitsFirstDES, changedBitsSecondDES, changedBitsThirdDES;
        var firstEncrypt  = EncryptDES(plainText, key1, out changedBitsFirstDES);
        var secondEncrypt = EncryptDES(firstEncrypt, key2, out changedBitsSecondDES);
        var thirdEncrypt  = EncryptDES(secondEncrypt, key1, out changedBitsThirdDES);

        stopWatch.Stop();
        changedBits = changedBitsThirdDES;
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



    // Получить количество изменённых битов в тексте (лавинный эффект)
    public static int GetAvalancheEffect(byte[] initialOpenText, byte[] encryptedText)
    {
        var changedBits = 0;

        for (int i = 0; i < initialOpenText.Length; i++)
        {
            var originalByte = initialOpenText[i];
            var encryptedByte = encryptedText[i];

            int xor = originalByte ^ encryptedByte;
            while (xor != 0)
            {
                if ((xor & 1) == 1)
                    changedBits++;
                xor >>= 1;
            }
        }

        return changedBits;
    }
}