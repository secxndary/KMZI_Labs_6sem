using System.Text.RegularExpressions;

namespace KMZI_Lab4;
public class Cypher
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt_text.txt";

    const int k = 7;
    const string alphabet = "aäbcdefghijklmnoöpqrsßtuüvwxyz";
    const string alphabetExtended = "aäbcdefghijklmnoöpqrsßtuüvwxyz .,\"!?";



    // Зашифрование с помощью моноалфавитного шифра подстановки
    public static char[] EncryptMonoAlphabet()
    {
        var str = ReadFromFile(fileNameOpen);
        var N = alphabet.Length;
        var length = str.Length;

        for (var i = 0; i < length; ++i)
            for (var j = 0; j < N; ++j)
                if (str[i] == alphabet[j])
                {
                    str[i] = alphabet[(j + k) % N];
                    break;
                }
        return str;
    }


    // Расшифрование с помощью моноалфавитного шифра подстановки
    public static char[] DecryptMonoAlphabet()
    {
        var str = ReadFromFile(fileNameEncrypt);
        var N = alphabet.Length;
        var length = str.Length;

        for (var i = 0; i < length; ++i)
            for (var j = 0; j < N; ++j)
                if (str[i] == alphabet[j])
                {
                    var index = ((j - k) % N) < 0 ? ((j - k) % N) + k : ((j - k) % N);
                    str[i] = alphabet[index];
                    break;
                }
        return str;
    }


    // Зашифрование таблицей Трисемуса
    public static char[,] EncryptTrithemius(string keyword)
    {
        var rows = 6;
        var columns = 6;
        var index = 0;
        
        keyword = RemoveDuplicatedSymbols(keyword);
        var table = new char[rows, columns];
        
        // заполняем ключевым словом
        foreach (var c in keyword.Distinct())
        {
            table[index / columns, index % columns] = c;
            index++;
        }

        // заполняем оставшуюся часть таблицы
        foreach (var c in alphabetExtended)
        {
            if (index >= rows * columns)    // достигли конца таблицы
                break; 
            if (!keyword.Contains(c))
            {
                table[index / columns, index % columns] = c;
                index++;
            }
        }
        return table;
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


    // Удалить из строки повторяющиеся символы
    private static string RemoveDuplicatedSymbols(string str)
    {
        var i = 0;
        while (true)
        {
            var tmp = str[i].ToString();
            str = str.Replace(tmp, "");
            str = str.Insert(i, tmp);
            i++;
            if (str.Length - 1 < i)
                break;
        }
        return str;
    }
}
