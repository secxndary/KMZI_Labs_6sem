using System.Text;
using System.Diagnostics;

namespace KMZI_Lab5;

public class Swap
{
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncryptRoute = "encrypt_route.txt";
    const string alphabet = "aäbcdefghijklmnoöpqrsßtuüvwxyz";


    // Зашифровать маршрутным перестановочным шифром
    public static char[] EncryptRouteSwap(int rows, int cols, string fileName = fileNameOpen)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var openText = SwapHelper.ReadFromFile(fileName);
        var data = SwapHelper.ConvertToTwoDimentionalArray(openText, rows, cols);
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

        var encryptedData = SwapHelper.ReadFromFile(fileName);
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

        var openText = SwapHelper.ReadFromFile(fileName);
        (var indexesRows, var indexesColumns) = GetRowsAndColsIndexesArrays(keyColumns, keyRows, openText);
        var rows = indexesRows.Length;
        var cols = indexesColumns.Length;
        var table = SwapHelper.ConvertToTwoDimentionalArray(openText, rows, cols);

        /// перестановка по строкам
        var tableWithSwappedRows = table.Clone() as char[,];
        for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
                tableWithSwappedRows[i, j] = table[indexesRows[i], j];

        /// перестановка по столбцам
        var tableWithSwappedRowsAndColumns = tableWithSwappedRows.Clone() as char[,];
        for (var j = 0; j < cols; j++)
            for (var i = 0; i < rows; i++)
                tableWithSwappedRowsAndColumns[i, j] = tableWithSwappedRows[i, indexesColumns[j]];

        /// считать по столбцам
        var encryptedTableByColumns = SwapHelper.GetTableByColumns(tableWithSwappedRowsAndColumns);

        stopWatch.Stop();
        Console.WriteLine($"Encrypt Multiple Swap:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return encryptedTableByColumns;
    }



    // Расшифровать множественной перестановкой
    public static char[,] DecryptMultiple(string keyColumns, string keyRows, char[,] tableEncrypted)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        (var indexesRows, var indexesColumns) = GetRowsAndColsIndexesArrays(keyColumns, keyRows, tableEncrypted);
        var rows = indexesRows.Length;
        var cols = indexesColumns.Length;

        /// перестановка по строкам
        var tableWithSwappedRows = tableEncrypted.Clone() as char[,];
        for (var i = 0; i < rows; i++)
            for (var j = 0; j < cols; j++)
                tableWithSwappedRows[indexesRows[i], j] = tableEncrypted[i, j];

        /// перестановка по столбцам
        var tableWithSwappedRowsAndColumns = tableWithSwappedRows.Clone() as char[,];
        for (var j = 0; j < cols; j++)
            for (var i = 0; i < rows; i++)
                tableWithSwappedRowsAndColumns[i, indexesColumns[j]] = tableWithSwappedRows[i, j];

        /// считать по столбцам
        var encryptedTableByColumns = SwapHelper.GetTableByColumns(tableWithSwappedRowsAndColumns);

        stopWatch.Stop();
        Console.WriteLine($"Decrypt Multiple Swap:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return encryptedTableByColumns;
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



    // Перегрузка вышеописанного метода для одномерного массива (для зашифрования)
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
}