namespace KMZI_Lab2;

public class Entropy
{
    // Кол-во появлений символов в строке
    public static Dictionary<char, int> GetSymbolAppearances(string str)
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


    // Энтропия Шеннона
    public static double GetShannonEntropy(string str)
    {
        var symbolAppearances = GetSymbolAppearances(str);
        var entropy = 0d;
        foreach (var item in symbolAppearances)
        {
            var P = (double)item.Value / str.Length;
            entropy -= P * Math.Log2(P);
        }
        return Math.Round(entropy, 3);
    }


    // Количество информации
    public static double GetInformationAmount(string alphabet, string str)
    {
        if (IsBinaryAlphabet(alphabet))
            return str.Length;
        var informationAmount = GetShannonEntropy(alphabet) * str.Length;
        return Math.Round(informationAmount, 3);
    }


    // Эффективная энтропия
    public static double GetEffectiveEntropy(string alphabet, double p)
    {
        var q = 1 - p;
        if (IsBinaryAlphabet(alphabet) && (p == 0 || q == 0))
            return 1;
        if (!IsBinaryAlphabet(alphabet) && p == 1)
            return 0;
        return 1 - (-p * Math.Log2(p) - q * Math.Log2(q));
    }


    // Количество информации при наличии вероятности ошибки
    public static double GetInformationAmount(string alphabet, string str, double p)
    {
        var informationAmount = GetShannonEntropy(alphabet) * str.Length * GetEffectiveEntropy(alphabet, p);
        return Math.Round(informationAmount, 3);
    }


    // Проверить, является ли алфавит бинарным
    private static bool IsBinaryAlphabet(string alphabet) => GetSymbolAppearances(alphabet).Count == 2;


    // Вспомогательный метод для чтения текста из файла
    public static string ReadFromFile(string fileName)
    {
        var pathToFolder = "../../../Alphabets/";
        var filePath = Path.Combine(pathToFolder, fileName);
        var text = "";
        using (var sr = new StreamReader(filePath))
            text = sr.ReadToEnd().ToLower(); 
        return text;
    }
}
