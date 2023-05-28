using System.Text;
namespace KMZI_Lab9;


public class CypherHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt.txt";
    const string fileNameDecrypt = "decrypt.txt";


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



    // Получить строку с байтами (двоичная сс) по массиву byte[]
    public static string GetByteString(byte[] bytes) => 
        string.Join(string.Empty, bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

    // Получить массива byte[] с исходным текстом
    public static byte[] GetOpenText() => ReadFromFile(fileNameOpen);


    // Конвертация строки в массив byte[]
    public static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);


    // Конвертация массива byte[] в строку
    public static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
}