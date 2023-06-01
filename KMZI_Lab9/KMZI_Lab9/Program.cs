using KMZI_Lab9;
const string fileNameEncrypt = "encrypt.txt";
const string fileNameDecrypt = "decrypt.txt";

var z = 8;
var sizeBits = 100;
var initialNumber = Cypher.GenerateRandomNumber(sizeBits);
var privateKey = Cypher.GeneratePrivateKey(initialNumber, z);


var n = Cypher.Sum(privateKey) + 1;
var a = Cypher.GenerateCoprime(n);
var publicKey = Cypher.GeneratePublicKey(privateKey, a, n);


var openText = CypherHelper.GetOpenText();
var encryptedText = Cypher.Encrypt(publicKey, openText);
var decryptedText = Cypher.Decrypt(privateKey, encryptedText, a, n);
CypherHelper.WriteToFile(encryptedText, fileNameEncrypt);
CypherHelper.WriteToFile(decryptedText, fileNameDecrypt);


