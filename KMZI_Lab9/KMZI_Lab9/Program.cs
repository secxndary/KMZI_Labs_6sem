using KMZI_Lab9;

var z = 8;
var sizeBits = 100;
var initialNumber = Cypher.GenerateRandomNumber(sizeBits);
var privateKey = Cypher.GeneratePrivateKey(initialNumber, z);


var n = Cypher.Sum(privateKey) + 1;
var a = Cypher.GenerateCoprime(n);
var publicKey = Cypher.GeneratePublicKey(privateKey, a, n);

foreach (var term in privateKey)
    Console.WriteLine(term);

Console.WriteLine("===================================");

foreach (var term in publicKey)
    Console.WriteLine(term);
