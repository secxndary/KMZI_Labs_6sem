using System.Security.Cryptography;
namespace KMZI_Lab12;


class RSACypher
{
    // Генерация ключей RSA
    public static void GenerateRSAKeys(out byte[] publicKey, out byte[] privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            publicKey = rsa.ExportRSAPublicKey();
            privateKey = rsa.ExportRSAPrivateKey();
        }
    }

    // Создание ЭЦП на основе алгоритма RSA
    public static byte[] CreateRSASignature(byte[] data, byte[] privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportRSAPrivateKey(privateKey, out _);
            return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }

    // Проверка ЭЦП на основе алгоритма RSA
    public static bool VerifyRSASignature(byte[] data, byte[] signature, byte[] publicKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportRSAPublicKey(publicKey, out _);
            return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}
