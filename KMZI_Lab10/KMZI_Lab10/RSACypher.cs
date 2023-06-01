using System.Security.Cryptography;
namespace KMZI_Lab10;

public class RSACypher
{
    public static byte[] Encrypt(byte[] plaintext, RSAParameters publicKey)
    {
        using var rsa = new RSACryptoServiceProvider();
        rsa.ImportParameters(publicKey);
        return rsa.Encrypt(plaintext, true);
    }


    public static byte[] Decrypt(byte[] ciphertext, RSAParameters privateKey)
    {
        using var rsa = new RSACryptoServiceProvider();
        rsa.ImportParameters(privateKey);
        return rsa.Decrypt(ciphertext, true);
    }
}
