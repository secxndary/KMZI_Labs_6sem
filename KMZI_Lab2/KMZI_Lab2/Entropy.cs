namespace KMZI_Lab2;
public class Entropy
{

    public static double GetShannonEntropy(string str)
    {
        var symbolAppearances = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (!symbolAppearances.ContainsKey(c))
                symbolAppearances.Add(c, 1);
            else
                symbolAppearances[c] += 1;
        }

        double entropy = 0;
        foreach (var item in symbolAppearances)
        {
            var P = (double)item.Value / str.Length;
            entropy -= P * Math.Log2(P);
        }

        return Math.Round(entropy, 3);
    }
}
