using KMZI_Lab7;


var key = Cypher.GetValidKey(Cypher.GetBytes("myKey"));
var encrypt = Cypher.Encrypt("hello world heheh", key);

var decrypt = Cypher.Decrypt(encrypt, key);
Console.WriteLine(decrypt);