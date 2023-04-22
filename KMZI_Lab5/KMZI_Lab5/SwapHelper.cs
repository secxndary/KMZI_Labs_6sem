namespace KMZI_Lab5;

public class SwapHelper
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";


    // Посчитать кол-во появлений символов в тексте
    public static Dictionary<char, int> GetSymbolAppearances(char[] str)
    {
        var symbolAppearances = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (!symbolAppearances.ContainsKey(c))
                symbolAppearances.Add(c, 1);
            else
                symbolAppearances[c] += 1;
        }
        return symbolAppearances;
    }


    // Чтение текста из файла
    public static char[] ReadFromFile(string fileName)
    {
        var filePath = Path.Combine(pathToFolder, fileName);
        var text = "";
        using (var sr = new StreamReader(filePath))
            text = sr.ReadToEnd();
        return text.ToLower().ToCharArray();
    }


    // Запись одномерного массива символов char[] в файл
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


    // Конвертировать одномерный массив char[] в двумерный массив char[,]
    public static char[,] ConvertToTwoDimentionalArray(char[] array, int rows, int cols)
    {
        var length = array.Length;
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


    // Считать двумерный массив по строкам
    public static char[,] GetTableByColumns(char[,] inputArray)
    {
        var rows = inputArray.GetLength(0);
        var columns = inputArray.GetLength(1);
        var outputArray = new char[rows, columns];

        for (int j = columns - 1; j >= 0; j--)
            for (int i = 0; i < rows; i++)
                outputArray[i, j] = inputArray[i, j];
        return outputArray;
    }


    // Конвертировать двумерный массив char[,] в одномерный массив char[]
    public static char[] ConvertToOneDimentionalArray(char[,] array) => array.Cast<char>().ToArray();


    // Получить массив char[] с исходным текстом
    public static char[] GetOpenText() => ReadFromFile(fileNameOpen);


    // Запись двумерного массива символов char[,] в файл
    public static bool WriteToFile(char[,] text, string fileName) => WriteToFile(ConvertToOneDimentionalArray(text), fileName);
}
