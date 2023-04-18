namespace KMZI_Lab5;

public class Swap
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";


    // Зашифровать маршрутным перестановочным шифром
    public static char[] EncryptRouteSwap(char[,] data)
    {
        var index = 0;
        var rows = data.GetLength(0);
        var cols = data.GetLength(1);
        var result = new char[rows * cols];

        for (var i = 0; i < cols; i++)
        {
            if (i % 2 == 0)
                for (var j = 0; j < rows; ++j)
                    result[index++] = data[j, i];
            else
                for (var j = rows - 1; j >= 0; --j)
                    result[index++] = data[j, i];
        }

        return result;
    }


    // Расшифровать маршрутным перестановочным шифром
    public static char[] DecryptRouteSwap(char[,] data)
    {

        return new char[1];
    }


    // Конвертировать одномерный массив char[] в двумерный массив char[,]
    public static char[,] ConvertToTwoDimentionalArray(char[] array)
    {
        var length = array.Length;
        var rows = (int)Math.Ceiling(Math.Sqrt(length));
        var cols = (int)Math.Ceiling((double)length / rows);
        var result = new char[rows, cols];
        var index = 0;

        for (var i = 0; i < rows; ++i)
            for (var j = 0; j < cols && index < length; ++j)
            {
                result[i, j] = array[index];
                index++;
            }

        return result;
    }


    // Чтение текста из файла
    public static char[] ReadFromFile(string fileName = fileNameOpen)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        var text = "";
        using (var sr = new StreamReader(filePath))
            text = sr.ReadToEnd().ToLower();
        return text.ToCharArray();
    }


    // Запись массива символов в файл
    public static bool WriteToFile(char[] text, string fileName)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        try
        {
            using (var sw = new StreamWriter(filePath))
                sw.WriteLine(text);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}