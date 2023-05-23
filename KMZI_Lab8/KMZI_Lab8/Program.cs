using KMZI_Lab8;


// =========================================  BBS  =========================================

long p = 56155;
long q = 87151;
long x = 512;
var numberOfBits = 16;

var BBS = new BBS(p, q, x);
var pseudoRandomNumberBBS = BBS.GenerateBBSRandom(numberOfBits);
Console.WriteLine($"BBS random number:\t{pseudoRandomNumberBBS}");
Console.WriteLine($"BBS number (binary):\t{Convert.ToString(pseudoRandomNumberBBS, 2)}");
Console.WriteLine();



// =========================================  RC4  =========================================

int n = 8;
var RC4 = new RC4(n);

var fileNameEncrypt = "encrypt_rc4.txt";
var fileNameDecrypt = "decrypt_rc4.txt";
var key = new byte[] { 12, 13, 90, 91, 240 };
var openText = CypherHelper.GetOpenText();

var sBlock = RC4.InitializeSBox(key);
var keyStream = RC4.GenerateKeyStream(sBlock, openText.Length);
var encryptedText = RC4.Encrypt(openText, keyStream);
var decryptedText = RC4.Decrypt(encryptedText, keyStream);

Console.WriteLine($"Encrypt RC4:\t\t{CypherHelper.WriteToFile(encryptedText, fileNameEncrypt)}");
Console.WriteLine($"Decrypt RC4:\t\t{CypherHelper.WriteToFile(decryptedText, fileNameDecrypt)}");