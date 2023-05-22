namespace KMZI_Lab8;

public class BBS
{
    private long p;
    private long q;
    private long n;
    private long x;


    public BBS(long p, long q, long x)
    {
        if (p % 4 != 3 || q % 4 != 3)
            throw new Exception("p and q should give a remainder of 3 when divided by 4.");

        if (!CypherHelper.AreRelativelyPrime(p * q, x))
            throw new Exception("n and x should be relatively prime.");

        this.p = p;
        this.q = q;
        this.x = x;
        n = p * q;
    }


    public long GenerateBBSRandom(int numberOfBits)
    {
        long result = 0;
        long x = this.x;

        for (var i = 0; i < numberOfBits; ++i)
        {
            x = x * x % n;
            long bit = x & 1;
            result = (result << 1) | bit;
        }

        return result;
    }
}
