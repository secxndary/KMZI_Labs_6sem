using System.Security.Cryptography;
using System.Text;
namespace KMZI_Lab7;
#pragma warning disable SYSLIB0021


class DESCypher
{
    //private static readonly byte[] Key = Encoding.UTF8.GetBytes("ThisIsA16ByteKey");



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




    public static byte[] Encrypt(string plainText, byte[] key)
    {
        using (var des = new DESCryptoServiceProvider())
        {
            des.Key = key;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            using (var encryptor = des.CreateEncryptor())
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                return cipherBytes;
            }
        }
    }


    public static string Decrypt(byte[] cipherText, byte[] key)
    {
        using (var des = new DESCryptoServiceProvider())
        {
            des.Key = key;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            using (var decryptor = des.CreateDecryptor())
            {
                var plainBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                var plainText = Encoding.UTF8.GetString(plainBytes);
                return plainText;
            }
        }
    }



    public static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);
}