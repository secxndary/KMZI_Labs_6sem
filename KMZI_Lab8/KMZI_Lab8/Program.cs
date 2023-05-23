using KMZI_Lab8;


// =========================================  BBS  =========================================

long p = 56155;
long q = 87151;
long x = 512;
var numberOfBits = 16;

var BBS = new BBS(p, q, x);
Console.WriteLine($"BBS random number:\t{BBS.GenerateBBSRandom(numberOfBits)}");
Console.WriteLine($"BBS number (binary):\t{Convert.ToString(BBS.GenerateBBSRandom(numberOfBits), 2)}\n");



// =========================================  RC4  =========================================

int n = 8;
var RC4 = new RC4(n);

var fileNameEncrypt = "encrypt_rc4.txt";
var fileNameDecrypt = "decrypt_rc4.txt";
var key = CypherHelper.GetBytes("my_RC4_key");
var openText = CypherHelper.GetOpenText();

var sBlock = RC4.InitializeSBox(key);
var keyStream = RC4.GenerateKeyStream(sBlock, openText.Length);
var encryptedText = RC4.Encrypt(openText, keyStream);
var decryptedText = RC4.Decrypt(encryptedText, keyStream);

CypherHelper.WriteToFile(encryptedText, fileNameEncrypt);
CypherHelper.WriteToFile(decryptedText, fileNameDecrypt);