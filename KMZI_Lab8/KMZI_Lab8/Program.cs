using KMZI_Lab8;

long p = 56155;
long q = 87151;
long x = 512;
var numberOfBits = 16;


var BBS = new BBS(p, q, x);
Console.WriteLine($"BBS random number:\t{BBS.GenerateBBSRandom(numberOfBits)}");
Console.WriteLine($"BBS number (binary):\t{Convert.ToString(BBS.GenerateBBSRandom(numberOfBits), 2)}");
