using System.Text;
using System.Diagnostics;

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




    // Зашифровать множественной перестановкой
    public static char[,] EncryptMultiple(string keyColumns, string keyRows, string fileName = fileNameOpen)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var openText = ReadFromFile(fileName);

        (var indexesRows, var indexesColumns) = GetRowsAndColsIndexesArrays(keyColumns, keyRows, openText);

        var rows = indexesRows.Length;
        var cols = indexesColumns.Length;


        var table = ConvertToTwoDimentionalArray(openText, rows, cols);
        var tableWithSwappedRows = table.Clone() as char[,];

        for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
                tableWithSwappedRows[i, j] = table[indexesRows[i], j];


        var tableWithSwappedRowsAndColumns = tableWithSwappedRows.Clone() as char[,];
        
        for (var j = 0; j < cols; j++)
            for (var i = 0; i < rows; i++)
                tableWithSwappedRowsAndColumns[i, j] = tableWithSwappedRows[i, indexesColumns[j]];

        stopWatch.Stop();
        Console.WriteLine($"Encrypt Multiple Swap:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return tableWithSwappedRowsAndColumns;
    }



    // Расшифровать множественной перестановкой
    public static char[,] DecryptMultiple(string keyColumns, string keyRows, char[,] tableEncrypted)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        (var indexesRows, var indexesColumns) = GetRowsAndColsIndexesArrays(keyColumns, keyRows, tableEncrypted);

        var rows = indexesRows.Length;
        var cols = indexesColumns.Length;

        var tableWithSwappedRows = tableEncrypted.Clone() as char[,];
        
        for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
                tableWithSwappedRows[indexesRows[i], j] = tableEncrypted[i, j];


        var tableWithSwappedRowsAndColumns = tableWithSwappedRows.Clone() as char[,];

        for (var j = 0; j < cols; j++)
            for (var i = 0; i < rows; i++)
                tableWithSwappedRowsAndColumns[i, indexesColumns[j]] = tableWithSwappedRows[i, j];
        
        stopWatch.Stop();
        Console.WriteLine($"Decrypt Multiple Swap:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return tableWithSwappedRowsAndColumns;
    }




    // Получить кортеж с массивами индексов символов ключа для итогового ключа множественной перестановки
    public static (int[], int[]) GetRowsAndColsIndexesArrays(string keyColumns, string keyRows, char[,] tableEncrypted)
    {
        var keyRowsInitial = keyRows.ToLowerInvariant();
        var keyColumnsInitial = keyColumns.ToLowerInvariant();

        var sbRows = new StringBuilder(keyRowsInitial);
        var sbCols = new StringBuilder(keyColumnsInitial);

        while (sbCols.Length * sbRows.Length < tableEncrypted.Length)
        {
            sbRows.Append(keyRowsInitial);
            sbCols.Append(keyColumnsInitial);
        }

        keyRows = sbRows.ToString();
        keyColumns = sbCols.ToString();

        var indexesRows = GetAlphabetIndexes(keyRows);
        var indexesColumns = GetAlphabetIndexes(keyColumns);

        return (indexesRows, indexesColumns);
    }



    // Перегрузка вышеописанного метода с последним стркоовым параметром (для зашифрования)
    public static (int[], int[]) GetRowsAndColsIndexesArrays(string keyColumns, string keyRows, char[] openText)
    {
        var keyRowsInitial = keyRows.ToLowerInvariant();
        var keyColumnsInitial = keyColumns.ToLowerInvariant();

        var sbRows = new StringBuilder(keyRowsInitial);
        var sbCols = new StringBuilder(keyColumnsInitial);

        while (sbCols.Length * sbRows.Length < openText.Length)
        {
            sbRows.Append(keyRowsInitial);
            sbCols.Append(keyColumnsInitial);
        }

        keyRows = sbRows.ToString();
        keyColumns = sbCols.ToString();

        var indexesRows = GetAlphabetIndexes(keyRows);
        var indexesColumns = GetAlphabetIndexes(keyColumns);

        return (indexesRows, indexesColumns);
    }



    // Получить массив индексов символов
    // ключа для множественной перестановки
    public static int[] GetAlphabetIndexes(string str)
    {
        var index = 0;
        var arrayOfIndexes = new int[str.Length];

        for (var i = 0; i < alphabet.Length; ++i)
            for (var j = 0; j < str.Length; ++j)
                if (alphabet[i] == str[j])
                {
                    arrayOfIndexes[j] = index;
                    index++;
                }

        return arrayOfIndexes;
    }


    // Получить массив char[] с исходным текстом
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
    public static char[] ConvertToOneDimentionalArray(char[,] array) => array.Cast<char>().ToArray();


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