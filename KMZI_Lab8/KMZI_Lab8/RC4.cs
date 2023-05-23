namespace KMZI_Lab8;

public class RC4
{
    private int n;
    private double mod;

    public RC4(int n)
    {
        this.n = n;
        mod = Math.Pow(2, n);
    }



    // Инициализация S-блока
    public byte[] InitializeSBox(byte[] key)
    {
        var j = 0;
        var sBlock = new byte[256];

        for (var i = 0; i < 256; i++)
            sBlock[i] = (byte)i;

        for (var i = 0; i < 256; i++)
        {
            j = (j + key[i % key.Length] + sBlock[i]) % 256;
            Swap(sBlock, i, j);
        }

        return sBlock;
    }


    // Генерация К-слов с помощью ПСП
    public byte[] GenerateKeyStream(byte[] sBlock, int length)
    {
        var i = 0;
        var j = 0;
        var keyStream = new byte[length];

        for (var k = 0; k < length; k++)
        {
            i = (i + 1) % 256;
            j = (j + sBlock[i]) % 256;
            Swap(sBlock, i, j);
            keyStream[k] = sBlock[(sBlock[i] + sBlock[j]) % 256];
        }

        return keyStream;
    }


    // Зашифрование с помощью RC4
    public byte[] Encrypt(byte[] data, byte[] keyStream)
    {
        var encryptedData = new byte[data.Length];

        for (var i = 0; i < data.Length; i++)
            encryptedData[i] = (byte)(data[i] ^ keyStream[i]);

        return encryptedData;
    }


    // Расшифрование с помощью RC4
    public byte[] Decrypt(byte[] data, byte[] keyStream) => Encrypt(data, keyStream);


    // Вспомогательная функция для того, чтобы менять элементы местами
    private static void Swap(byte[] array, int i, int j)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }
}
