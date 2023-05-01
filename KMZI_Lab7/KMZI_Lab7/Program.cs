using KMZI_Lab7;

var fileNameEncrypt = "encrypt_eee2.txt";
var fileNameDecrypt = "decrypt_eee2.txt";
var firstKey  = CypherHelper.GetBytes("myKeyDES");
var secondKey = CypherHelper.GetBytes("otherKey");
var plainText = CypherHelper.GetOpenText();
int totalBits, changedBits;


var encryptedText = Cypher.EncryptEEE2(plainText, firstKey, secondKey, out changedBits);
CypherHelper.WriteToFile(encryptedText, fileNameEncrypt);

var decryptedText = Cypher.DecryptEEE2(encryptedText, firstKey, secondKey);
CypherHelper.WriteToFile(decryptedText, fileNameDecrypt);

Console.WriteLine();
Console.WriteLine($"Total bits count:\t{totalBits = CypherHelper.GetTotalBits(plainText)} bits");
Console.WriteLine($"Avalanche Effect:\t{changedBits} bits (changed)");
Console.WriteLine($"Percentage ratio:\t{CypherHelper.GetPercentageRatio(totalBits, changedBits)}%");