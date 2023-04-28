using System.Security.Cryptography;
using System.Text;
namespace KMZI_Lab7;


class Cypher
{
    // Зашифрование с помощью DES-EEE2
    public static byte[] EncryptEEE2(byte[] plainText, string key1, string key2)
    {
        var firstEncrypt  = EncryptDES(plainText, key1);
        var secondEncrypt = EncryptDES(firstEncrypt, key2);
        var thirdEncrypt  = EncryptDES(secondEncrypt, key1);
        return thirdEncrypt;
    }


    // Расшифрование с помощью DES-EEE2
    public static byte[] DecryptEEE2(byte[] encryptText, string key1, string key2)
    {
        var firstDecrypt  = DecryptDES(encryptText, key1);
        var secondDecrypt = DecryptDES(firstDecrypt, key2);
        var thirdDecrypt  = DecryptDES(secondDecrypt, key1);
        return thirdDecrypt;
    }


    // Зашифрование с помощью алгоритма DES
    public static byte[] EncryptDES(byte[] plainText, string key)
    {
        using (var des = DES.Create())
        {
            var validKey = GetValidKey(GetBytes(key));
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
    public static byte[] DecryptDES(byte[] cipherText, string key)
    {
        using (var des = DES.Create())
        {
            var validKey = GetValidKey(GetBytes(key));
            des.Key = validKey;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            using (var decryptor = des.CreateDecryptor())
            {
                var plainBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                return plainBytes;
            }
        }
    }



    // Вспомогательная функция для создания валидного 64-битного ключа 
    public static byte[] GetValidKey(byte[] key)
    {
        byte[] newKey = new byte[8];
        if (key.Length < 8)
        {
            for (int i = 0; i < key.Length; i++)
                newKey[i] = key[i];
            for (int i = key.Length; i < 8; i++)
                newKey[i] = key[i % key.Length];
            return newKey;
        }
        else if (key.Length > 8)
        {
            for (int i = 0; i < 8; i++)
                newKey[i] = key[i];
            return newKey;
        }
        else
            return key;
    }


    // Вспомогательная функция для конвертации строки в массив byte[]
    public static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);
    
    // Вспомогательная функция для конвертации массива byte[] в строку
    public static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
}