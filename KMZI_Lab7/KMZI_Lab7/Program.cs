using KMZI_Lab7;

var fileNameEncrypt = "encrypt_eee2.txt";
var fileNameDecrypt = "decrypt_eee2.txt";
var firstKey  = CypherHelper.GetBytes("my1stKey");
var secondKey = CypherHelper.GetBytes("my2ndKey");
var plainText = CypherHelper.GetOpenText();







var diffCountEncrypt = 0;
var openText = CypherHelper.GetBytes("hello world hehehe");
var encrypt = Cypher.EncryptDES(openText, firstKey, out diffCountEncrypt);
Console.WriteLine($"diff = {diffCountEncrypt}");
Console.WriteLine(CypherHelper.GetString(encrypt) + "\n\n");

var avalance = 0;
var eee2 = Cypher.EncryptEEE2(openText, firstKey, secondKey, out avalance);
Console.WriteLine($"avalance = {avalance}");
Console.WriteLine(CypherHelper.GetString(eee2));



//var encryptedText = Cypher.EncryptEEE2(plainText, firstKey, secondKey);
//CypherHelper.WriteToFile(encryptedText, fileNameEncrypt);

//var decryptedText = Cypher.DecryptEEE2(encryptedText, firstKey, secondKey);
//CypherHelper.WriteToFile(decryptedText, fileNameDecrypt);