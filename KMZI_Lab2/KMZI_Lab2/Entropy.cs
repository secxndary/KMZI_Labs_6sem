namespace KMZI_Lab2;
public class Entropy
{

    public static double GetShannonEntropy(string s)
    {
        var symbolAppearances = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (!symbolAppearances.ContainsKey(c))
                symbolAppearances.Add(c, 1);
            else
                symbolAppearances[c] += 1;
        }

        double result = 0.0;
        int len = s.Length;
        foreach (var item in symbolAppearances)
        {
            var frequency = (double)item.Value / len;
            result -= frequency * (Math.Log(frequency) / Math.Log(2));
        }

        return result;
    }
}
