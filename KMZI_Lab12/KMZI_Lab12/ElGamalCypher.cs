using System.Numerics;
namespace KMZI_Lab12;


class ElGamalCypher
{
    public static int obr(int a, int n)
    {
        int res = 0;
        for (int i = 0; i < 10000; i++)
        {
            if (((a * i) % n) == 1) return (i);
        }
        return (res);
    }

    public static byte[] GenerateElGamalSignature(int p, int g, int x, int k, int H)
    {
        int y = (int)BigInteger.ModPow(g, x, p);
        int m = p - 1;
        int k_1 = obr(k, p - 1);
        int a = (int)BigInteger.ModPow(g, k, p);
        var b = new BigInteger((k_1 * (H - (x * a) % m) % m) % m);

        byte[] signature = new byte[2 * sizeof(int)];
        Buffer.BlockCopy(BitConverter.GetBytes(a), 0, signature, 0, sizeof(int));
        Buffer.BlockCopy(BitConverter.GetBytes((int)b), 0, signature, sizeof(int), sizeof(int));

        return signature;
    }

    public static bool VerifyElGamalSignature(int p, int g, int y, int H, byte[] signature)
    {
        int a = BitConverter.ToInt32(signature, 0);
        int b = BitConverter.ToInt32(signature, sizeof(int));

        var ya = BigInteger.ModPow(y, a, p);
        var ab = BigInteger.ModPow(a, b, p);
        var pr1 = BigInteger.ModPow(ya * ab, 1, p);
        var pr2 = BigInteger.ModPow(g, H, p);

        return pr1 == pr2;
    }


}
