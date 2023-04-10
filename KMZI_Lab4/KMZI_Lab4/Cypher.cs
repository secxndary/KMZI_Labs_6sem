using System.Diagnostics;

namespace KMZI_Lab4;
public class Cypher
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt_monoalphabet.txt";
    const string fileNameEncryptTrithemius = "encrypt_trithemius.txt";

    const int k = 7;
    const string alphabet = "aäbcdefghijklmnoöpqrsßtuüvwxyz";
    const string alphabetExtended = "aäbcdefghijklmnoöpqrsßtuüvwxyz .,\"!?";

    const int rows = 6;
    const int columns = 6;
        

    // Зашифровать с помощью моноалфавитного шифра подстановки
    public static char[] EncryptMonoAlphabet(string fileName = fileNameOpen)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var str = ReadFromFile(fileName);
        var N = alphabet.Length;
        var length = str.Length;

        for (var i = 0; i < length; ++i)
            for (var j = 0; j < N; ++j)
                if (str[i] == alphabet[j])
                {
                    var index = (j + k) % N;
                    str[i] = alphabet[index];
                    break;
                }

        stopWatch.Stop();
        Console.WriteLine($"Encrypt Monoalphabet:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return str;
    }


    // Расшифровать с помощью моноалфавитного шифра подстановки
    public static char[] DecryptMonoAlphabet(string fileName = fileNameEncrypt)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var str = ReadFromFile(fileName);
        var N = alphabet.Length;
        var length = str.Length;

        for (var i = 0; i < length; ++i)
            for (var j = 0; j < N; ++j)
                if (str[i] == alphabet[j])
                {
                    var index = (j - k + N) % N;
                    str[i] = alphabet[index];
                    break;
                }

        stopWatch.Stop();
        Console.WriteLine($"Decrypt Monoalphabet:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return str;
    }


    // Заполнить таблицу Трисемуса
    public static char[,] FillTrithemiusTable(string keyword)
    {
        var table = new char[rows, columns];
        var index = 0;
        
        foreach (var c in keyword.Distinct())
        {
            table[index / columns, index % columns] = c;
            index++;
        }

        foreach (var c in alphabetExtended)
        {
            if (index >= rows * columns)
                break; 
            if (!keyword.Contains(c))
            {
                table[index / columns, index % columns] = c;
                index++;
            }
        }

        return table;
    }


    // Зашифровать по таблице Трисемуса
    public static char[] EncryptTrithemius(string keyword, string fileName = fileNameOpen)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        bool keepCycle;
        var text = ReadFromFile(fileName);
        var table = FillTrithemiusTable(keyword);

        for (var i = 0; i < text.Length; ++i)
        {
            keepCycle = true;
            for (var row = 0; row < rows && keepCycle; ++row)
                for (var column = 0; column < columns && keepCycle; ++column)
                    if (text[i] == table[row, column])
                    {
                        text[i] = (row != rows - 1) ? table[row + 1, column] : table[0, column];
                        keepCycle = false;
                        break;
                    }
        }

        stopWatch.Stop();
        Console.WriteLine($"Encrypt Trithemius:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return text;
    }


    // Расшифровать по таблице Трисемуса
    public static char[] DecryptTrithemius(string keyword, string fileName = fileNameEncryptTrithemius)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        bool keepCycle;
        var text = ReadFromFile(fileName);
        var table = FillTrithemiusTable(keyword);

        for (var i = 0; i < text.Length; ++i)
        {
            keepCycle = true;
            for (var row = 0; row < rows && keepCycle; ++row)
                for (var column = 0; column < columns && keepCycle; ++column)
                    if (text[i] == table[row, column])
                    {
                        text[i] = (row == 0) ? table[rows - 1, column] : table[row - 1, column];
                        keepCycle = false;
                        break;
                    }
        }

        stopWatch.Stop();
        Console.WriteLine($"Decrypt Trithemius:\t{stopWatch.ElapsedTicks} ticks ({stopWatch.ElapsedMilliseconds} ms)");
        return text;
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
    public static bool WriteToFile(char[] text, string fileName = fileNameEncrypt)
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
