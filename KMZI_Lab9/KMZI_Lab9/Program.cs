using KMZI_Lab9;

var z = 8;
var sizeBits = 4;
var initialNumber = Cypher.GenerateRandomNumber(sizeBits);
var privateKey = Cypher.GeneratePrivateKey(initialNumber, z);


var n = Cypher.Sum(privateKey) + 1;
var a = Cypher.GenerateCoprime(n);
var publicKey = Cypher.GeneratePublicKey(privateKey, a, n);


var openText = CypherHelper.GetOpenText();
var encryptedText = Cypher.Encrypt(publicKey, openText);



privateKey.ForEach(x => Console.WriteLine(x));
Console.WriteLine("==================================");


publicKey.ForEach(x => Console.WriteLine(x));
Console.WriteLine("==================================");


encryptedText.ForEach(x => Console.Write($"{x} "));
