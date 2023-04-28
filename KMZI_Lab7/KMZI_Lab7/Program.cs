using KMZI_Lab7;

var firstKey  = "my1stKey";
var secondKey = "my2ndKey";
var text = "hello world hehehe";

var encryptEEE2 = Cypher.EncryptEEE2(Cypher.GetBytes(text), firstKey, secondKey);
var decryptEEE2 = Cypher.DecryptEEE2(encryptEEE2, firstKey, secondKey);
Console.WriteLine(Cypher.GetString(decryptEEE2));