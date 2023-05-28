using KMZI_Lab9;

var z = 8;
var sizeBits = 2;
var initialNumber = Cypher.GenerateRandomNumber(sizeBits);
var privateKey = Cypher.GeneratePrivateKey(initialNumber, z);


var n = Cypher.Sum(privateKey) + 1;
var a = Cypher.GenerateCoprime(n);
var publicKey = Cypher.GeneratePublicKey(privateKey, a, n);


var openText = CypherHelper.GetOpenText();
var encryptedText = Cypher.Encrypt(publicKey, openText);
var decryptedText = Cypher.Decrypt(privateKey, encryptedText, a, n);


Console.WriteLine("Закрытый ключ: ");
privateKey.ForEach(x => Console.WriteLine(x));
Console.WriteLine("==================================");


Console.WriteLine("Открытый ключ: ");
publicKey.ForEach(x => Console.WriteLine(x));
Console.WriteLine("==================================");


Console.WriteLine("Шифротекст: ");
encryptedText.ForEach(x => Console.Write($"{x} "));
CypherHelper.WriteToFile(decryptedText);