package by.valdaitsevv;

public class DES {
    static byte[] weakKey1 = new byte[] { (byte)0x01, (byte)0x01, (byte)0x01,
            (byte)0x01, (byte)0x01, (byte)0x01, (byte)0x01, (byte)0x01 };
    static byte[] weakKey4 = new byte[] { (byte)0xFE, (byte)0xFE, (byte)0xFE,
            (byte)0xFE, (byte)0xFE, (byte)0xFE, (byte)0xFE, (byte)0xFE };
    static byte[] weakKey2 = new byte[] { (byte)0x1F, (byte)0x1F, (byte)0x1F,
            (byte)0x1F, (byte)0x0E, (byte)0x0E, (byte)0x0E, (byte)0x0E };
    static byte[] weakKey3 = new byte[] { (byte)0xE0, (byte)0xE0, (byte)0xE0,
            (byte)0xE0, (byte)0xF1, (byte)0xF1, (byte)0xF1, (byte)0xF1 };



    static byte[] semiWeakKey1 = new byte[] { (byte)0x01, (byte)0x23, (byte)0x45,
            (byte)0x67, (byte)0x89, (byte)0xab, (byte)0xcd, (byte)0xef };
    static byte[] semiWeakKey2 = new byte[] { (byte)0xfe, (byte)0xdc, (byte)0xba,
            (byte)0x98, (byte)0x76, (byte)0x54, (byte)0x32, (byte)0x10 };
    static byte[] semiWeakKey3 = new byte[] { (byte)0x01, (byte)0x31, (byte)0x61,
            (byte)0x91, (byte)0xC1, (byte)0xF1, (byte)0x21, (byte)0x51 };
    static byte[] semiWeakKey4 = new byte[] { (byte)0x01, (byte)0x1F, (byte)0x01,
            (byte)0x1F, (byte)0x01, (byte)0x0E, (byte)0x01, (byte)0x0E };




    // Получить количество изменённых битов в тексте (лавинный эффект)
    public static int GetAvalancheEffect(byte[] initialOpenText, byte[] encryptedText)
    {
        var changedBits = 0;
        for (int i = 0; i < initialOpenText.length; i++)
        {
            var originalByte = initialOpenText[i];
            var encryptedByte = encryptedText[i];
            int xor = originalByte ^ encryptedByte;
            while (xor != -1 & xor != 0)
            {
                if ((xor & 1) == 1)
                    changedBits++;
                xor >>= 1;
            }
        }
        return changedBits;
    }
}
