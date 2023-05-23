using System.Text;
namespace KMZI_Lab8;

public class CypherHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt_rc4.txt";
    const string fileNameDecrypt = "decrypt_rc4.txt";



    // Проверить, взаимно ли простые числа
    public static bool AreRelativelyPrime(long a, long b)
    {
        while (b != 0)
        {
            var remainder = a % b;
            a = b;
            b = remainder;
        }
        return a == 1;
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


    // Чтение текста из файла
    public static byte[] ReadFromFile(string fileName = fileNameDecrypt)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        return File.ReadAllBytes(filePath);
    }


    // Вспомогательная функция для получения массива byte[] с исходным текстом
    public static byte[] GetOpenText() => ReadFromFile(fileNameOpen);


    // Вспомогательная функция для конвертации строки в массив byte[]
    public static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);


    // Вспомогательная функция для конвертации массива byte[] в строку
    public static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);

}