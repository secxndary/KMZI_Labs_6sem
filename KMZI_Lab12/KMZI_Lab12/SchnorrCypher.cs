using System.Security.Cryptography;
namespace KMZI_Lab12;


class SchnorrCypher
{
    // Генерация ключей Шнорра
    public static void GenerateSchnorrKeys(out byte[] publicKey, out byte[] privateKey)
    {
        using (var schnorr = new ECDsaCng())
        {
            publicKey = schnorr.ExportSubjectPublicKeyInfo();
            privateKey = schnorr.ExportPkcs8PrivateKey();
        }
    }

    // Создание ЭЦП на основе алгоритма Шнорра
    public static byte[] CreateSchnorrSignature(byte[] data, byte[] privateKey)
    {
        using (var schnorr = new ECDsaCng())
        {
            schnorr.ImportPkcs8PrivateKey(privateKey, out _);
            return schnorr.SignData(data, HashAlgorithmName.SHA256);
        }
    }

    // Проверка ЭЦП на основе алгоритма Шнорра
    public static bool VerifySchnorrSignature(byte[] data, byte[] signature, byte[] publicKey)
    {
        using (var schnorr = new ECDsaCng())
        {
            schnorr.ImportSubjectPublicKeyInfo(publicKey, out _);
            return schnorr.VerifyData(data, signature, HashAlgorithmName.SHA256);
        }
    }
}
