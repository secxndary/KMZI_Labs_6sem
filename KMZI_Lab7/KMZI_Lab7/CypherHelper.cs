using System.Text;
namespace KMZI_Lab7;


public class CypherHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt_eee2.txt";
    const string fileNameDecrypt = "decrypt_eee2.txt";



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


    // Чтение текста из файла
    public static byte[] ReadFromFile(string fileName = fileNameDecrypt)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        return File.ReadAllBytes(filePath);
    }


    // Запись текста в файл
    public static bool WriteToFile(byte[] text, string fileName = fileNameEncrypt)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        try
        {
            File.WriteAllBytes(filePath, text);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }


    // Вспомогательная функция для конвертации строки в массив byte[]
    public static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);


    // Вспомогательная функция для конвертации массива byte[] в строку
    public static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);


    // Получить массив byte[] с исходным текстом
    public static byte[] GetOpenText() => ReadFromFile(fileNameOpen);


    // Получить кол-во битов в массиве byte[]
    public static int GetTotalBits(byte[] bytes) => bytes.Length * 8;
}
