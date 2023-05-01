package by.valdaitsevv;

public class DES {
    static byte[] weakKey0 = new byte[] { (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00 };
    static byte[] weakKey1 = new byte[] { (byte)0x01, (byte)0x01, (byte)0x01, (byte)0x01, (byte)0x01, (byte)0x01, (byte)0x01, (byte)0x01 };
    static byte[] weakKey4 = new byte[] { (byte)0xFE, (byte)0xFE, (byte)0xFE, (byte)0xFE, (byte)0xFE, (byte)0xFE, (byte)0xFE, (byte)0xFE };
    static byte[] weakKey2 = new byte[] { (byte)0x1F, (byte)0x1F, (byte)0x1F, (byte)0x1F, (byte)0x0E, (byte)0x0E, (byte)0x0E, (byte)0x0E };
    static byte[] weakKey3 = new byte[] { (byte)0xE0, (byte)0xE0, (byte)0xE0, (byte)0xE0, (byte)0xF1, (byte)0xF1, (byte)0xF1, (byte)0xF1 };




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
