namespace KMZI_Lab13;


public class EC
{
    public static List<(int, double)> GetPoints(int xMin, int xMax, int a, int b, int p)
    {
        var points = new List<(int, double)>();
        for (int x = xMin; x <= xMax; x++)
        {
            double y = Math.Round(Math.Sqrt((x * x * x + a * x + b) % p), 2);
            points.Add((x, y));
        }
        return points;
    }
}