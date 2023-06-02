using System.Security.Cryptography;
using KMZI_Lab10;


const string fileNameEncryptRSA = "encrypt_rsa.txt";
const string fileNameDecryptRSA = "decrypt_rsa.txt";
const string fileNameEncryptElGamal = "encrypt_el_gamal.txt";
const string fileNameDecryptElGamal = "decrypt_el_gamal.txt";

var openText = CypherHelper.GetOpenText();
RSAParameters publicKey;
RSAParameters privateKey;


using (var rsa = new RSACryptoServiceProvider(4096))
{
    publicKey = rsa.ExportParameters(false);
    privateKey = rsa.ExportParameters(true);
}


var encryptedTextRSA = RSACypher.Encrypt(openText, publicKey);
var decryptedTextRSA = RSACypher.Decrypt(encryptedTextRSA, privateKey);
CypherHelper.WriteToFile(encryptedTextRSA, fileNameEncryptRSA);
CypherHelper.WriteToFile(decryptedTextRSA, fileNameDecryptRSA);




var p = 29;
var q = 7;
var x = 10;
var elGamal = new ElGamalCypher(p, q, x);

var encryptedTextElGamal = elGamal.Encrypt(openText);
var decryptedTextElGamal = elGamal.Decrypt(encryptedTextElGamal);
CypherHelper.WriteToFile(encryptedTextElGamal, fileNameEncryptElGamal);
CypherHelper.WriteToFile(decryptedTextElGamal, fileNameDecryptElGamal);



RSACypher.FirstTask();