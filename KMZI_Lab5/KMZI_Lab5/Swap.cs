using System.Diagnostics;
using System.Text;

namespace KMZI_Lab5;

public class Swap
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncryptRoute = "encrypt_route.txt";
    const string alphabet = "aäbcdefghijklmnoöpqrsßtuüvwxyz";


    // Зашифровать маршрутным перестановочным шифром
    public static char[] EncryptRouteSwap(int rows, int cols, string fileName = fileNameOpen)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var openText = ReadFromFile(fileName);
        var data = ConvertToTwoDimentionalArray(openText, rows, cols);
        var result = new char[rows * cols];
        var index = 0;

        for (var i = 0; i < cols; ++i)
        {
            if (i % 2 == 0)
                for (var j = 0; j < rows; ++j)
                    result[index++] = data[j, i];
            else
                for (var j = rows - 1; j >= 0; --j)
                    result[index++] = data[j, i];
        }

        stopWatch.Stop();
        Console.WriteLine($"Encrypt Route Swap:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return result;
    }



    // Расшифровать маршрутным перестановочным шифром
    public static char[,] DecryptRouteSwap(int rows, int cols, string fileName = fileNameEncryptRoute)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var encryptedData = ReadFromFile(fileName);
        var result = new char[rows, cols];
        var index = 0;

        for (var i = 0; i < cols; ++i)
        {
            if (i % 2 == 0)
                for (var j = 0; j < rows; ++j)
                    result[j, i] = encryptedData[index++];
            else
                for (var j = rows - 1; j >= 0; --j)
                    result[j, i] = encryptedData[index++];
        }

        stopWatch.Stop();
        Console.WriteLine($"Decrypt Route Swap:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return result;
    }



    public static int[] GetAlphabetIndexes(string str)
    {
        var index = 0;
        var arrayOfIndexes = new int[str.Length];

        for (var i = 0; i< alphabet.Length; ++i)
            for (var j = 0; j < str.Length; ++j)
                if (alphabet[i] == str[j])
                {
                    arrayOfIndexes[j] = index;
                    index++;
                }

        return arrayOfIndexes;
    }




    public static char[,] EncryptMultiple(string keyColumns, string keyRows, string fileName = fileNameOpen)
    {
        var openText = ReadFromFile(fileName);

        var keyColumnsInitial = keyColumns.ToLowerInvariant();
        var keyRowsInitial = keyRows.ToLowerInvariant();

        var rows = keyRows.Length;
        var cols = keyColumns.Length;

        var stringBuilderRows = new StringBuilder(keyRowsInitial);
        var stringBuilderColumns = new StringBuilder(keyColumnsInitial);

        while (rows * cols < openText.Length)
        {
            stringBuilderColumns.Append(keyColumnsInitial);
            stringBuilderRows.Append(keyRowsInitial);
            cols += keyColumnsInitial.Length;
            rows += keyRowsInitial.Length;
        }

        keyRows = stringBuilderRows.ToString();
        keyColumns = stringBuilderColumns.ToString();

        var indexesRows = GetAlphabetIndexes(keyRows);
        var indexesColumns = GetAlphabetIndexes(keyColumns);

        return new char[1, 1];
    }






    //// Зашифровать множественной перестановкой
    //public static char[,] EncryptMultiple(string keyColumns, string keyRows, string fileName = fileNameOpen)
    //{
    //    var openText = ReadFromFile(fileName);
    //    var keyColumnsInitial = keyColumns.ToLowerInvariant();
    //    var keyRowsInitial = keyRows.ToLowerInvariant();

    //    const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    //    int rows = keyRows.Length;
    //    int cols = keyColumns.Length;

    //    // Повторяем ключи, если необходимо
    //    while (rows * cols < openText.Length)
    //    {
    //        keyColumns += keyColumnsInitial;
    //        keyRows += keyRowsInitial;
    //        cols += keyColumnsInitial.Length;
    //        rows += keyRowsInitial.Length;
    //    }

    //    // Создаем таблицу для шифрования
    //    char[,] table = new char[rows, cols];
    //    int index = 0;
    //    foreach (char c in keyColumns)
    //    {
    //        int column = alphabet.IndexOf(c);
    //        for (int i = 0; i < rows; i++)
    //        {
    //            table[i, index] = openText[index];
    //            index++;
    //        }
    //        if (index >= openText.Length)
    //            break;
    //    }

    //    // Переставляем столбцы в соответствии с ключом для столбцов
    //    char[] sortedColumns = keyColumns.OrderBy(c => c).ToArray();
    //    char[,] sortedTable = new char[rows, cols];
    //    for (int i = 0; i < cols; i++)
    //    {
    //        int sortedIndex = Array.IndexOf(sortedColumns, keyColumns[i]);
    //        for (int j = 0; j < rows; j++)
    //            sortedTable[j, sortedIndex] = table[j, i];
    //    }

    //    // Переставляем строки в соответствии с ключом для строк
    //    char[] sortedRows = keyRows.OrderBy(c => c).ToArray();
    //    char[,] resultTable = new char[rows, cols];
    //    for (int i = 0; i < rows; i++)
    //    {
    //        int sortedIndex = Array.IndexOf(sortedRows, keyRows[i]);
    //        for (int j = 0; j < cols; j++)
    //            resultTable[sortedIndex, j] = sortedTable[i, j];
    //    }

    //    return resultTable;
    //}







    // Расшифровать множественной перестановкой
    public static char[,] DecryptMultiple(string keyColumns, string keyRows)
    {

        return new char[1, 1];
    }




    // Получить двумерный массив с исходным текстом
    public static char[] GetOpenText() => ReadFromFile(fileNameOpen);


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


    // Кол-во появлений символов в тексте
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


    // Запись двумерного массива символов char[,] в файл
    public static bool WriteToFile(char[,] text, string fileName) => WriteToFile(ConvertToOneDimentionalArray(text), fileName);


    // Конвертировать двумерный массив char[,] в одномерный массив char[]
    private static char[] ConvertToOneDimentionalArray(char[,] array) => array.Cast<char>().ToArray();


    // Конвертировать одномерный массив char[] в двумерный массив char[,]
    private static char[,] ConvertToTwoDimentionalArray(char[] array, int rows, int cols)
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
}