namespace KMZI_Lab4;
public class Cypher
{
    const string pathToFolder = "../../../Texts/";
    const string fileNameOpen = "open_text.txt";
    const string fileNameEncrypt = "encrypt_text.txt";

    const int k = 7;
    const string alphabet = "aäbcdefghijklmnoöpqrsßtuüvwxyz";



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
