using KMZI_Lab7;

var fileNameEncrypt = "encrypt_eee2.txt";
var fileNameDecrypt = "decrypt_eee2.txt";
var firstKey  = CypherHelper.GetBytes("myKeyDES");
var secondKey = CypherHelper.GetBytes("otherKey");
var plainText = CypherHelper.GetOpenText();
int totalBits, changedBits;


//var encryptedText = Cypher.EncryptDES(plainText, firstKey, out changedBits);
//CypherHelper.WriteToFile(encryptedText, fileNameEncrypt);

//var decryptedText = Cypher.DecryptDES(encryptedText, firstKey);
//CypherHelper.WriteToFile(decryptedText, fileNameDecrypt);

//Console.WriteLine();
//Console.WriteLine($"Total bits count:\t{totalBits = CypherHelper.GetTotalBits(plainText)} bits");
//Console.WriteLine($"Avalanche Effect:\t{changedBits} bits (changed)");
//Console.WriteLine($"Percentage ratio:\t{CypherHelper.GetPercentageRatio(totalBits, changedBits)}%");





int changedPlainToEncrypt;
var cypherTextInitial = CypherHelper.GetBytes("Ъ{КК\aц!(Bђu!r\r\n\u0014Е»W Џ—ОК%");
var key = CypherHelper.GetBytes("myKeyDES");
var newEncryptedText = Cypher.EncryptDES(cypherTextInitial, key, out changedPlainToEncrypt);
CypherHelper.WriteToFile(newEncryptedText, fileNameEncrypt);
Console.WriteLine();
Console.WriteLine($"Total bits count:\t{totalBits = CypherHelper.GetTotalBits(newEncryptedText)} bits");
Console.WriteLine($"Avalanche Effect:\t{changedPlainToEncrypt} bits (changed)");
Console.WriteLine($"Percentage ratio:\t{CypherHelper.GetPercentageRatio(totalBits, changedPlainToEncrypt)}%");







//var encryptedText = Cypher.EncryptDES(plainText, key, out changedPlainToEncrypt);
//CypherHelper.WriteToFile(encryptedText, fileNameEncrypt);

//var decryptedText = Cypher.DecryptDES(encryptedText, key);
//CypherHelper.WriteToFile(decryptedText, fileNameDecrypt);

//Console.WriteLine();
//Console.WriteLine($"Total bits count:\t{totalBits = CypherHelper.GetTotalBits(plainText)} bits");
//Console.WriteLine($"Avalanche Effect:\t{changedBits} bits (changed)");
//Console.WriteLine($"Percentage ratio:\t{CypherHelper.GetPercentageRatio(totalBits, changedBits)}%");