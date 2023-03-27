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


    public static double GetEffectiveEntropy(double p)
    {
        var q = 1 - p;
        if (p == 0 || q == 0)
            return 1;
        return 1 - (-p * Math.Log2(p) - q * Math.Log2(q));
    }
}
