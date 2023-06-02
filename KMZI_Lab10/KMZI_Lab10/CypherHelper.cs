using System.Numerics;
namespace KMZI_Lab10;

public class CypherHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";


    // Запись текста в файл
    public static bool WriteToFile(byte[] text, string fileName)
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
    public static byte[] ReadFromFile(string fileName)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        return File.ReadAllBytes(filePath);
    }


    // Запись списка чисел в файл
    public static void WriteToFile(List<BigInteger> numbers, string fileName)
    {
        using (var writer = new StreamWriter(Path.Combine(pathToFolder, fileName)))
        {         
            foreach (BigInteger number in numbers)
                writer.Write(number.ToString() + " ");
        }
    }


    // Получить массив byte[] с исходным текстом
    public static byte[] GetOpenText() => ReadFromFile(fileNameOpen);
}